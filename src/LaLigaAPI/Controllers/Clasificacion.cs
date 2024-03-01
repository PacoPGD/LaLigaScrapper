using LaLigaApplication.Clasificacion.DTOs;
using LaLigaApplication.Clasificacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Clasificacion : ControllerBase
    {
        private readonly IClasificacionService _service;

        public Clasificacion(IClasificacionService service) 
        { 
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetClasificacionResponse), 200)]
        [Route("Get")]
        public async Task<IActionResult> GetClasificacion()
        {
            var clasificacion = await _service.GetClasificacion();
            return Ok(clasificacion);
        }
    }
}
