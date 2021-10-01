using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using VuonDau.Business.Commons;

namespace UniPro.WebApi.App_Start
{
    public static class DependencyInjectionResolver
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.InitializerDI();
          
            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("vi")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "vi", uiCulture: "vi");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { Options = options } };
                });
        }
    }
}
