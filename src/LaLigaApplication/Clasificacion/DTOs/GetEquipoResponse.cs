using LaLigaDomain.Clasificacion.Entities;

namespace LaLigaApplication.Clasificacion.DTOs
{
    public record GetEquipoResponse
    {
        public required Equipo Equipo { get; init; }
    }
}
