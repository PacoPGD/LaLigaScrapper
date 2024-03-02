using LaLigaApplication.Clasificacion.DTOs;

namespace LaLigaApplication.Clasificacion.Services
{
    /// <summary>
    /// Interfaz para el servicio de clasificación de equipos.
    /// </summary>
    public interface IClasificacionService
    {
        /// <summary>
        /// Obtiene la clasificación de equipos.
        /// </summary>
        /// <returns>Lista de equipos con su clasificación.</returns>
        Task<List<GetEquipoResponse>> GetClasificacion();
    }
}
