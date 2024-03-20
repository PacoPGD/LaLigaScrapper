using LaLigaDomain.Clasificacion.Entities;

namespace LaLigaApplication.Clasificacion.DTOs
{
    public record GetClasificacionResponse
    { 
        public required ClasificacionDeLiga Clasificacion { get; init; }
    }
}
