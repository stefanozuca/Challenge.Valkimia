using AutoMapper.Extensions.ExpressionMapping;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Infrastructure.DbContexts;
using Challenge.Valkimia.Infrastructure.Identity.Factories;
using Challenge.Valkimia.Infrastructure.Mappings;
using Challenge.Valkimia.Infrastructure.Models;
using Challenge.Valkimia.Infrastructure.Repositories;
using Challenge.Valkimia.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Valkimia.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabasePersistence(configuration);
            services.AddRepositories();
            services.AddIdentity();
            services.AddAutoMapper(config =>
            {
                config.AddExpressionMapping();
                config.AddProfile<UserProfile>();
                config.AddProfile<AppProfile>();
            });
        }
        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            services.AddDbContext<ChallengeValkimiaContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));
         
            services.AddScoped<IDbInitializerService, DbInitializerService>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityRepository<,>), typeof(DataEntityRepository<,>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICiudadRepository, CiudadRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
        }

        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>();

            var passwordOptions = new PasswordOptions()
            {
                RequireDigit = false, //in accordance with ASVS 4.0
                RequiredLength = 10, //in accordance with ASVS 4.0
                RequireUppercase = false, //in accordance with ASVS 4.0
                RequireLowercase = false //in accordance with ASVS 4.0
            };

            services.AddScoped(a => passwordOptions);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = passwordOptions;

            });
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
        }
    }
}
