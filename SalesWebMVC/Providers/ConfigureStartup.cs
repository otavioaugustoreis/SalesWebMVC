using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace SalesWebMVC.Providers
{
    public static class ConfigureStartup
    {
        public static IApplicationBuilder AddLanguageSystem(this IApplicationBuilder app)
        {
            var enus = new CultureInfo("en-US");
            var localizationOption = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enus),
                SupportedCultures = new List<CultureInfo> 
                {
                    enus
                },
                SupportedUICultures = new List<CultureInfo> { enus}
            };

            app.UseRequestLocalization(localizationOption);

            return app;
        }
    }
}
