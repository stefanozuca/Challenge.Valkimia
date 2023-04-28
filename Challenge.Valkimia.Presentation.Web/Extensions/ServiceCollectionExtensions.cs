using Challenge.Valkimia.Application;
using Challenge.Valkimia.Infrastructure.Resources.Services;
using Challenge.Valkimia.Presentation.Web.Mappings;
using Challenge.Valkimia.Presentation.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper.Extensions.ExpressionMapping;
using Challenge.Valkimia.Infrastructure.Extensions;

namespace Challenge.Valkimia.Presentation.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureLayer(configuration);
            services.AddApplicationCookie();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<AppProfile>();
                config.AddExpressionMapping();
            });

            services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<INotificationService, NotificationService>();
        }

        private static void AddApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Shared/AccessDenied";
                options.Cookie.Name = "Challenge.Valkimia.AUTH";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/auth/login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
        }
    }
}
