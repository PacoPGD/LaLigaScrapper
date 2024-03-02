using HtmlAgilityPack;
using LaLigaApplication.Clasificacion.DTOs;
using LaLigaDomain.Clasificacion.Entities;

namespace LaLigaApplication.Clasificacion.Services
{
    /// <summary>
    /// Servicio para obtener la clasificación de equipos.
    /// </summary>
    public class ClasificacionService : IClasificacionService
    {
        /// <summary>
        /// Obtiene la clasificación de equipos desde una URL externa.
        /// </summary>
        /// <returns>Lista de equipos con su clasificación.</returns>
        public async Task<List<GetEquipoResponse>> GetClasificacion()
        {
            // URL de la página que contiene la clasificación
            string url = "https://www.sport.es/resultados/futbol/primera-division/clasificacion-liga.html";

            // Cargar la página web
            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url);

            // Lista para almacenar los equipos y su clasificación
            var equipos = new List<GetEquipoResponse>();

            // Obtener las filas de la tabla que contienen la clasificación de los equipos
            var rows = document.DocumentNode.SelectNodes("//tr[@id and contains(@class, 'table-ranking__row')]");

            // Verificar si se encontraron filas
            if (rows != null)
            {
                // Iterar sobre cada fila para obtener la información de los equipos
                foreach (var row in rows)
                {
                    // Obtener el nombre del equipo
                    var nombreNode = row.SelectSingleNode(".//span[@class='table-ranking__team-text']");
                    if (nombreNode != null)
                    {
                        string nombreEquipo = nombreNode.InnerText.Trim();

                        // Obtener la posición del equipo
                        var posicionNode = row.SelectSingleNode(".//span[@class='table-ranking__position']");
                        int posicion = posicionNode != null ? int.Parse(posicionNode.InnerText.Trim()) : 0;

                        // Obtener los partidos jugados, ganados, empatados y perdidos
                        var cells = row.SelectNodes(".//td[contains(@class, 'table-ranking-total')]");
                        int pj = int.Parse(cells[0].InnerText.Trim());
                        int pg = int.Parse(cells[1].InnerText.Trim());
                        int pe = int.Parse(cells[2].InnerText.Trim());
                        int pp = int.Parse(cells[3].InnerText.Trim());

                        // Obtener los puntos
                        int pts = int.Parse(cells[4].InnerText.Trim());

                        // Obtener los goles a favor y en contra
                        int gf = int.Parse(cells[5].InnerText.Trim());
                        int gc = int.Parse(cells[6].InnerText.Trim());

                        // Crear una instancia de GetEquipoResponse y añadirla a la lista
                        var equipo = new GetEquipoResponse
                        {
                            Equipo = new Equipo
                            {
                                Nombre = nombreEquipo,
                                Posicion = posicion,
                                PartidosJugados = pj,
                                PartidosGanados = pg,
                                PartidosEmpatados = pe,
                                PartidosPerdidos = pp,
                                Puntos = pts,
                                GolesFavor = gf,
                                GolesContra = gc
                            }
                        };
                        equipos.Add(equipo);
                    }
                }
            }

            // Devolver la lista de equipos con su clasificación
            return equipos;
        }
    }
}
