using HtmlAgilityPack;
using LaLigaApplication.Clasificacion.DTOs;

namespace LaLigaApplication.Clasificacion.Services
{
    public class ClasificacionService : IClasificacionService
    {
        public async Task<List<GetClasificacionResponse>> GetClasificacion()
        {
            string url = "https://www.sport.es/resultados/futbol/primera-division/clasificacion-liga.html/";

            var web = new HtmlWeb();
            var document = web.Load(url);

            var equipos = new List<GetClasificacionResponse>();

            var rows = document.DocumentNode.SelectNodes("//tr[contains(@class, 'table-ranking__row')]");

            if (rows != null)
            {
                foreach (var row in rows)
                {
                    // Obtener el nombre del equipo
                    var nombreNode = row.SelectSingleNode(".//span[@class='table-ranking__team-text']");
                    if (nombreNode != null)
                    {
                        string clas = nombreNode.InnerText.Trim();
                    }

                    // Puedes continuar extrayendo otros datos aquí, como PJ, PG, PE, PP, Pts, etc.

                    //equipos.Add(equipo);
                }
            }

            // Imprimir la información de los equipos
            foreach (var equipo in equipos)
            {
                Console.WriteLine($"Clasificacion: {equipo.Clasificacion}");
            }

            return equipos;
        }
    }
}
