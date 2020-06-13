using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using Web.Constants;

namespace Web
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)     
        {
            config.RouteTable.Add(Routes.Register, Paths.Register, "Views/Register.dothtml");
            config.RouteTable.Add(Routes.Login, Paths.Login, "Views/Login.dothtml");
            config.RouteTable.Add(Routes.Logout, Paths.Logout, "Views/Logout.dothtml");
            config.RouteTable.Add(Routes.Home, Paths.Home, "Views/Home.dothtml");
            config.RouteTable.Add(Routes.ConfirmEmail, Paths.ConfirmEmail, "Views/Account/ConfirmEmail.dothtml");
            config.RouteTable.Add(Routes.Activate, Paths.Activate, "Views/Account/Activate.dothtml");
            config.RouteTable.Add(Routes.ServerError, Paths.ServerError, "Views/ServerError.dothtml");
            config.RouteTable.Add(Routes.NotFound, Paths.NotFound, "Views/NotFoundError.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }  

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        { }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        { }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
		}
    }
}
