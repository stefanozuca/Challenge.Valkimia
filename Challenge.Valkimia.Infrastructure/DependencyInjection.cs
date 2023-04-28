using Challenge.Valkimia.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Valkimia.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionStr = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ChallengeValkimiaContext>(options =>
                options.UseSqlServer(sqlConnectionStr));

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ChallengeValkimiaContext>());
        }

    }
}
