using AspNetCoreHero.ToastNotification;
using HS14_MVCKitapEvi.Infrastructure.AppContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using System.Numerics;

namespace HS14_MVCKitapEvi.UI.Extentations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIService (this IServiceCollection services)
        {
            AddIdentityService(services);
            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true;
                config.DurationInSeconds = 5;
                config.Position = NotyfPosition.BottomRight;
                config.IsDismissable = true;

            });

            services.AddLocalization(opt => opt.ResourcesPath = "Resources");

                      
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supCultures = new List<CultureInfo>()
                {
                    new CultureInfo("tr"),
                    new CultureInfo("en")
                };
                opt.DefaultRequestCulture = new RequestCulture("tr");
                opt.SupportedUICultures = supCultures;
                opt.SupportedCultures = supCultures;
                
            });
            return services;
        }

        private static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            return services;
            
        }

       
    }
}
