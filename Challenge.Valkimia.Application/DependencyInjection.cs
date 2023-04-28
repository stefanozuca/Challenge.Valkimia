using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Challenge.Valkimia.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => 
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
