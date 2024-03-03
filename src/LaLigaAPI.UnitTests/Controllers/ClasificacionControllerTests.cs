using LaLigaAPI.Controllers;
using LaLigaApplication.Clasificacion.DTOs;
using LaLigaApplication.Clasificacion.Services;
using LaLigaDomain.Clasificacion.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace LaLigaAPI.UnitTests.Controllers
{
    /// <summary>
    /// Clase de test de controlador para obtener la clasificación de equipos.
    /// </summary>
    [TestFixture]
    public class ClasificacionControllerTests
    {
        /// <summary>
        /// Verifica que el método GetClasificacion devuelva un OkObjectResult con datos cuando el servicio retorna una lista válida.
        /// </summary>
        [Test]
        public async Task GetClasificacionWhenServiceReturnsDataReturnsOkObjectResultWithData()
        {
            // Arrange
            var mockService = new Mock<IClasificacionService>();
            mockService.Setup(service => service.GetClasificacion())
                       .ReturnsAsync([
                           new GetEquipoResponse
                           {
                                Equipo = new Equipo
                                {
                                    Nombre = "Los satanases del infierno",
                                    Posicion = 1,
                                    PartidosJugados = 0,
                                    PartidosGanados = 0,
                                    PartidosEmpatados = 0,
                                    PartidosPerdidos = 0,
                                    Puntos = 0,
                                    GolesFavor = 0,
                                    GolesContra = 0
                                }
                           }
                       ]);

            var controller = new ClasificacionController(mockService.Object);

            // Act
            var result = await controller.GetClasificacion();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.Value, Is.Not.Null);
            Assert.That(okResult.Value, Is.InstanceOf<List<GetEquipoResponse>>());

        }
    }
}
