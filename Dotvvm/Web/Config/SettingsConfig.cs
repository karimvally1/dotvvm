using Mailer.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Config
{
    public static class SettingsConfig
    {
        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            // SENDGRID SETTINGS
            EmailSettings sendGridSettings = new EmailSettings();
            configuration.GetSection("SendGrid").Bind(sendGridSettings);
            services.AddSingleton(sendGridSettings);
        }
    }
}
