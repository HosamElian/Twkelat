using Microsoft.AspNetCore.Identity;
using Twkelat.Persistence;
using Twkelat.Persistence.Interfaces.IRepository;
using Twkelat.Persistence.Interfaces.IServices;
using Twkelat.Persistence.Models;

namespace Twkelat.BusinessLogic.Services
{
	public class ApplicationInitializer : IApplicationInitializer
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IEmailSender _emailSender;

		public ApplicationInitializer(
			IUnitOfWork unitOfWork,
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IEmailSender emailSender)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
			_roleManager = roleManager;
			_emailSender = emailSender;
		}
		public void Initialize()
		{
			if (!_roleManager.RoleExistsAsync(SD.Role_User).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
			}

			var user = new ApplicationUser()
			{
				UserName = "Mohamed01",
				CivilId = "000111222333",
				Name = "Mohamed",
				Email = "mohammedartie@gmail.com",
			};

			var result = _userManager.CreateAsync(user, "000111222333").GetAwaiter().GetResult();
			_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
			return;
		}
	}
}
