using System.ComponentModel.DataAnnotations;

namespace Bookmory.Data
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int AñoPublicacion { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;

        // Relaciones
        public int AutorId { get; set; }
        virtual public Autor? Autor { get; set; }
        public int EditorialId { get; set; }
        virtual public Editorial? Editorial { get; set; }
        virtual public List<Genero?> Generos { get; set; }

        public virtual List<UsuarioLibro> UsuarioLibros { get; set; } = new();
    }
}
