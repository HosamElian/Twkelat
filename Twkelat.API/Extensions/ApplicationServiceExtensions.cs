using Microsoft.EntityFrameworkCore;
using Twkelat.BusinessLogic.Services;
using Twkelat.EF;
using Twkelat.EF.Repository;
using Twkelat.Persistence.Interfaces.IRepository;
using Twkelat.Persistence.Interfaces.IServices;

namespace Twkelat.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITwkelatService, TwkelatService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IApplicationInitializer, ApplicationInitializer>();

			services.AddCors();
            return services;
        }
    }
}
