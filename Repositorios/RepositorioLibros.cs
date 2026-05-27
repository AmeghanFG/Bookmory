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
            return await _context.Libros.Include(l => l.Autor).AsNoTracking().ToListAsync();
        }
    }
}
