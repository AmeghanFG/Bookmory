namespace Bookmory.Data
{
    public class UsuarioLibro
    {
        public int Id { get; set; }

        // Relación con Usuario
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

        // Relación con Libro
        public int LibroId { get; set; }
        public virtual Libro? Libro { get; set; }

        // Opcional
        public string Estado { get; set; } = string.Empty;
    }
}