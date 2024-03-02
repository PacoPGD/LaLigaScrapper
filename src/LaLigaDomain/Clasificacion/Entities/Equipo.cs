namespace LaLigaDomain.Clasificacion.Entities
{
    /// <summary>
    /// Representa un equipo en la clasificación.
    /// </summary>
    public class Equipo
    {
        /// <summary>
        /// Nombre del equipo.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Posición del equipo en la clasificación.
        /// </summary>
        public int Posicion { get; set; }

        /// <summary>
        /// Partidos jugados.
        /// </summary>
        public int PartidosJugados { get; set; }

        /// <summary>
        /// Partidos ganados.
        /// </summary>
        public int PartidosGanados { get; set; }

        /// <summary>
        /// Partidos empatados.
        /// </summary>
        public int PartidosEmpatados { get; set; }

        /// <summary>
        /// Partidos perdidos.
        /// </summary>
        public int PartidosPerdidos { get; set; }

        /// <summary>
        /// Puntos obtenidos.
        /// </summary>
        public int Puntos { get; set; }

        /// <summary>
        /// Goles a favor.
        /// </summary>
        public int GolesFavor { get; set; }

        /// <summary>
        /// Goles en contra.
        /// </summary>
        public int GolesContra { get; set; }
    }
}
