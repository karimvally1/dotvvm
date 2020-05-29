using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Interfaces;
using Service.Models;
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
