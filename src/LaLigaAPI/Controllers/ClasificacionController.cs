using LaLigaApplication.Clasificacion.DTOs;
using LaLigaApplication.Clasificacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaAPI.Controllers
{
    /// <summary>
    /// Controlador para obtener la clasificación de equipos.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ClasificacionController : ControllerBase
    {
        private readonly IClasificacionService _service;

        /// <summary>
        /// Constructor del controlador de clasificación.
        /// </summary>
        /// <param name="service">Servicio de clasificación.</param>
        public ClasificacionController(IClasificacionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene la clasificación de equipos.
        /// </summary>
        /// <returns>Clasificación de equipos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetEquipoResponse), 200)]
        [Route("Get")]
        public async Task<IActionResult> GetClasificacion()
        {
            // Llama al servicio para obtener la clasificación
            var clasificacion = await _service.GetClasificacion();

            // Devuelve la clasificación como respuesta HTTP 200 OK
            return Ok(clasificacion);
        }
    }
}
