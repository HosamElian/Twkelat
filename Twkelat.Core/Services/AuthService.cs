using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Twkelat.Persistence;
using Twkelat.Persistence.Helpers;
using Twkelat.Persistence.Interfaces.IRepository;
using Twkelat.Persistence.Interfaces.IServices;
using Twkelat.Persistence.Models;
using Twkelat.Persistence.NotDbModels;

namespace Twkelat.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JWT _jwt;

        public AuthService(UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IOptions<JWT> Jwt,
                            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _jwt = Jwt.Value;
        }

        public async Task<AuthModelResponse> RegisterAsync(RegisterModel registerModel)
        {
            if (await _unitOfWork.User.GetbyCivilIdAsync(registerModel.CivilId) is not null)
            {
                return new AuthModelResponse() { Message = "CIVIL is Already register" };
            }
            if (await _userManager.FindByNameAsync(registerModel.Username) is not null)
            {
                return new AuthModelResponse() { Message = "Username is Already register" };
            }

            var user = new ApplicationUser()
            {
                UserName = registerModel.Username,
                CivilId = registerModel.CivilId,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                SecretKey = GenerateRandomString()
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                var errors = String.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModelResponse() { Message = errors };
            }
            if (!_roleManager.RoleExistsAsync(SD.Role_User).Result)
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.Role_User));
                await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            }
            await _userManager.AddToRoleAsync(user, SD.Role_User);

            var jwtSecurityToken = await CreateJwtToken(user);

            var userRole = await _userManager.GetRolesAsync(user);

            var text = jwtSecurityToken.ValidTo.ToString();

            return new AuthModelResponse()
            {
                CivilId = user.CivilId,
                ExpiresOn = text,
                IsAuthenticated = true,
                Username = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Image = user.Image,
                Roles = userRole
            };
        }

        public async Task<AuthModelResponse> GetTokenAsync(LoginModel tokenRequestModel)
        {
            var authModel = new AuthModelResponse();
            var user = await _unitOfWork.User.GetbyCivilIdAsync(tokenRequestModel.CivilId);

            if (user is null || !await _userManager.CheckPasswordAsync(user, tokenRequestModel.Password))
            {
                authModel.IsAuthenticated = false;
                authModel.Message = "Civil ID or Password is incorrect";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var userRole = await _userManager.GetRolesAsync(user);

            var text = jwtSecurityToken.ValidTo.ToString();
            authModel.CivilId = user.CivilId;
            authModel.ExpiresOn = text;
            authModel.IsAuthenticated = true;
            authModel.Username = user.UserName;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Image = user.Image;
            authModel.Roles = userRole.ToList();

            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleModel addRoleModel)
        {
            var user = await _userManager.FindByIdAsync(addRoleModel.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(addRoleModel.Role))
            {
                return "Invalid user ID or  Role Name";
            }

            if (await _userManager.IsInRoleAsync(user, addRoleModel.Role))
            {
                return "User Already assigned to this Role";
            }

            var result = await _userManager.AddToRoleAsync(user, addRoleModel.Role);

            return result.Succeeded ? String.Empty : "Something Went Wrong";
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;

        }


        public string GenerateRandomString(int length=10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

    }
}
