namespace LaLigaApplication.Clasificacion.Services
{
    /// <summary>
    /// Excepción personalizada para manejar errores específicos relacionados con el servicio de clasificación.
    /// </summary>
    public class ClasificacionServiceException : Exception
    {
        public ClasificacionServiceException() { }

        public ClasificacionServiceException(string message) : base(message) { }

        public ClasificacionServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
