using Microsoft.EntityFrameworkCore;
namespace Bookmory.Data
{
    public class DirectorioDBContext(DbContextOptions<DirectorioDBContext> options) : DbContext(options)
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
