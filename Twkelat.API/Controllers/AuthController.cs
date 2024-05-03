using Microsoft.AspNetCore.Mvc;
using Twkelat.Persistence.Consts;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Interfaces.IServices;
using Twkelat.Persistence.NotDbModels;

namespace Twkelat.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            //check if data completed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if data correct
            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            //check if data completed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if data correct
            var result = await _authService.Login(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
		[HttpPost("checkCode")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CheckCode(CheckRequestDTO model)
		{
			//check if data completed
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//check if data correct
			var result = await _authService.CheckRequest(model);
			if (result)
			{
				return Ok(new APIResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    IsSuccess = true,
                });
			}
			return Ok(new APIResponse{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    IsSuccess = false,
                });
		}

		[HttpPost("changeCode")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> ChangeCode(ChangeCodeRequestDTO model)
		{
			//check if data completed
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//check if data correct
			var result = await _authService.ChangeCodeRequest(model);
			if (result)
			{
				return Ok(new APIResponse
				{
					StatusCode = System.Net.HttpStatusCode.OK,
					IsSuccess = true,
				});
			}
			return Ok(new APIResponse
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				IsSuccess = false,
			});
		}

		[HttpPost("addrole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {

            //check if data completed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if data correct
            var result = await _authService.AddRoleAsync(model);
            if (!String.IsNullOrWhiteSpace(result))
            {
                return BadRequest(result);
            }
            return Ok(model);
        }

    }
}
