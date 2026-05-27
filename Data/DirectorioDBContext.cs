using Bookmory.Components.Pages;
using Microsoft.EntityFrameworkCore;
namespace Bookmory.Data
{
    public class DirectorioDBContext(DbContextOptions<DirectorioDBContext> options) : DbContext(options)
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<MiLibro> MisLibros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
    }
}
