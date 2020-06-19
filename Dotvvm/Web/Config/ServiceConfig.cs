using Microsoft.Extensions.DependencyInjection;
using Service;
using Identity;
using Service.Interfaces;
using Service.Models;
using Repository;
using Mailer.Interfaces;
using Mailer;

namespace Web.Config
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            // SERVICES
            services.AddTransient<IIdentityManager, IdentityManager>();
            services.AddTransient<IIdentityProvider, IdentityProvider>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmailService, EmailService>();

            // REPOSITORIES
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IReadWriteRepository<Email>, EmailRepository>();  

            // INTEGRATIONS
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
