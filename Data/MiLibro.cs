using System.ComponentModel.DataAnnotations;

namespace Bookmory.Data
{
    public class MiLibro
    {
        public int Id { get; set; }

        // Relación con Libro
        public int LibroId { get; set; }
        public virtual Libro? Libro { get; set; }

        // Relación con Estado
        public int EstadoId { get; set; }
        public virtual Estado? Estado { get; set; }
    }
}