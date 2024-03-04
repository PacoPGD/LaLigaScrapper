using LaLigaApplication.Clasificacion.Services;
using LaLigaInfraestructure.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace LaLigaApplication._Shared.Extensions
{
    public static class ServicecollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddBusinessServices(services);
            AddInfraServices(services, configuration);
            return services;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddScoped<IClasificacionService, ClasificacionService>();
        }

        private static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Redis
            services.AddSingleton<IConnectionMultiplexer>(x =>
            {
                var connectionString = configuration.GetConnectionString("Redis");
                var configurationOptions = ConfigurationOptions.Parse(connectionString);
                return ConnectionMultiplexer.Connect(configurationOptions);
            });

            return services.AddScoped<IRedisService, RedisService>();
        }
    }
}
