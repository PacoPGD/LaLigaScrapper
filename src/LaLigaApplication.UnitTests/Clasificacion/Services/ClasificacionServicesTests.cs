using HtmlAgilityPack;
using LaLigaApplication.Clasificacion.DTOs;
using LaLigaApplication.Clasificacion.Services;
using LaLigaInfraestructure.Redis;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace LaLigaApplication.UnitTests.Clasificacion.Services
{
    /// <summary>
    /// Clase de test para servicio para obtener la clasificación de equipos.
    /// </summary>
    [TestFixture]
    public class ClasificacionServiceTests
    {
        /// <summary>
        /// Prueba llamando al metodo padre para obtener la clasificación de equipos desde una URL externa.
        /// </summary>
        /// <returns>Lista de equipos con su clasificación.</returns>
        [Test]
        public async Task GetClasificacionShouldReturnListOfGetEquipoResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ClasificacionService>>();
            var redisMock = new Mock<IRedisService>();
            var service = new ClasificacionService(loggerMock.Object, redisMock.Object);

            // Act
            var result = await service.GetClasificacion();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<GetEquipoResponse>>());
            Assert.That(result, Is.Not.Empty);
        }


        /// <summary>
        /// Prueba general para comprobar que el metodo carga las Url
        /// </summary>
        /// <returns>Documento html con la web</returns>
        [Test]
        public async Task LoadDocumentFromUrlShouldLoadHtmlDocument()
        {
            // Arrange
            var url = "https://google.com";

            // Act
            var document = await ClasificacionService.LoadDocumentFromUrl(url);

            // Assert
            Assert.That(document, Is.Not.Null);
            Assert.That(document, Is.InstanceOf<HtmlDocument>());
        }
    }
}
