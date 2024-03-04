using HtmlAgilityPack;
using LaLigaApplication.Clasificacion.DTOs;
using LaLigaDomain.Clasificacion.Entities;
using LaLigaInfraestructure.Redis;
using Microsoft.Extensions.Logging;

namespace LaLigaApplication.Clasificacion.Services
{
    /// <summary>
    /// Servicio para obtener la clasificación de equipos.
    /// </summary>
    public class ClasificacionService(ILogger<ClasificacionService> logger, IRedisService redisService) : IClasificacionService
    {
        private readonly ILogger<ClasificacionService> _logger = logger;
        private readonly IRedisService _redisService = redisService;

        /// <summary>
        /// Obtiene la clasificación de equipos desde una URL externa.
        /// </summary>
        /// <returns>Lista de equipos con su clasificación.</returns>
        public async Task<List<GetEquipoResponse>> GetClasificacion()
        {
            try
            {
                var equiposData = await _redisService.GetFromRedis<List<Equipo>>("LaLiga");

                if (equiposData == null)
                {
                    string url = "https://www.sport.es/resultados/futbol/primera-division/clasificacion-liga.html";
                    var document = await LoadDocumentFromUrl(url);
                    equiposData = ExtractEquiposData(document);
                    await _redisService.SaveInRedis("LaLiga", equiposData);
                }

                return equiposData.Select(equipo =>
                {
                    return new GetEquipoResponse
                    {
                        Equipo = equipo
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la clasificación");
                throw new ClasificacionServiceException("Error al obtener la clasificación", ex);
            }
        }
       

        /// <summary>
        /// Carga la página web a partir de la url proporcionada
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static async Task<HtmlDocument> LoadDocumentFromUrl(string url)
        {
            var web = new HtmlWeb();
            return await web.LoadFromWebAsync(url);
        }

        /// <summary>
        /// Extrae los datos de los equipos a partir del documento Html
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        internal static List<Equipo> ExtractEquiposData(HtmlDocument document)
        {
            var equipos = new List<Equipo>();
            var rows = document.DocumentNode.SelectNodes("//tr[@id and contains(@class, 'table-ranking__row')]");
            if (rows != null)
            {
                foreach (var row in rows)
                {
                    var equipoData = ExtractEquipoDataFromRow(row);
                    if (equipoData != null)
                    {
                        equipos.Add(equipoData);
                    }
                }
            }
            return equipos;
        }


        /// <summary>
        /// Extrae los datos de un equipo a partir de la fila concreta del documento html
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal static Equipo? ExtractEquipoDataFromRow(HtmlNode row)
        {
            // Obtener el nombre del equipo
            var nombreNode = row.SelectSingleNode(".//span[@class='table-ranking__team-text']");
            var posicionNode = row.SelectSingleNode(".//span[@class='table-ranking__position']");
            var cells = row.SelectNodes(".//td[contains(@class, 'table-ranking-total')]");

            if (nombreNode != null)
            {
                return new Equipo
                {
                    Nombre = nombreNode.InnerText.Trim(),
                    Posicion = posicionNode != null ? int.Parse(posicionNode.InnerText.Trim()) : 0,
                    PartidosJugados = int.Parse(cells[0].InnerText.Trim()),
                    PartidosGanados = int.Parse(cells[1].InnerText.Trim()),
                    PartidosEmpatados = int.Parse(cells[2].InnerText.Trim()),
                    PartidosPerdidos = int.Parse(cells[3].InnerText.Trim()),
                    Puntos = int.Parse(cells[4].InnerText.Trim()),
                    GolesFavor = int.Parse(cells[5].InnerText.Trim()),
                    GolesContra = int.Parse(cells[6].InnerText.Trim())
                };
            }

            return null;
        }
    }
}
