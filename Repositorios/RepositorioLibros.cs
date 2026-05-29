using Microsoft.EntityFrameworkCore;
using Bookmory.Data;
using Bookmory.Repositorios;

namespace Bookmory.Repositorios
{
    public class RepositorioLibros : IRepositorioLibros
    {
        readonly DirectorioDBContext _context;

        public RepositorioLibros(DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<List<Libro>> ObtenerLibros()
        {
            return await _context.Libros.Include(l => l.Autor).Include(l=> l.Editorial).AsNoTracking().ToListAsync();
        }

        // hay q mandar el obteto, no id
        public async Task AgregarLibroUsuario(UsuarioLibro usuarioLibro)
        {
            _context.UsuarioLibros.Add(usuarioLibro);
            await _context.SaveChangesAsync();
        }
    }
}
