using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Bookmory.Data
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;

        public virtual List<Libro> Libros { get; set; } = new();
    }
}
