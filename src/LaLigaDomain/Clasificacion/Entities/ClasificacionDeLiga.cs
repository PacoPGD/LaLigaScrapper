namespace LaLigaDomain.Clasificacion.Entities
{
    /// <summary>
    /// Representa la clasificacion
    /// </summary>
    public class ClasificacionDeLiga
    {
        public required List<Equipo> Equipos { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
