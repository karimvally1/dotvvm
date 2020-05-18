using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Models;
using Repository;
using Service.Interfaces;

namespace Web.Config
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAppUserManager<User>, AppUserManager>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
