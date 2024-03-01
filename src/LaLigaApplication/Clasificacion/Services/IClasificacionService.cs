using LaLigaApplication.Clasificacion.DTOs;

namespace LaLigaApplication.Clasificacion.Services
{
    public interface IClasificacionService
    {
        Task<List<GetClasificacionResponse>> GetClasificacion();
    }
}
