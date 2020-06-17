using Microsoft.Extensions.DependencyInjection;
using Service;
using Identity;
using Service.Interfaces;
using Service.Models;
using Repository;

namespace Web.Config
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityManager, IdentityManager>();
            services.AddTransient<IIdentityProvider, IdentityProvider>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<IReadWriteRepository<Email>, EmailRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
