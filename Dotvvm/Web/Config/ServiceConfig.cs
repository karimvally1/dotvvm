using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Models;
using Service.Interfaces;
using Identity;

namespace Web.Config
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserManager<User>, UserManager>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
