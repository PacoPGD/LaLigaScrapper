using LaLigaApplication.Clasificacion.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LaLigaApplication._Shared.Extensions
{
    public static class ServicecollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return AddBusinessServices(services);
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddScoped<IClasificacionService, ClasificacionService>();
        }
    }
}
