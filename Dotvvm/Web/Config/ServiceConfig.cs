using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Models;
using Identity;

namespace Web.Config
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityManager<User>, IdentityManager>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
