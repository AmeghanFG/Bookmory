using Microsoft.EntityFrameworkCore;
using Bookmory.Data;
using Bookmory.Repositorios;

namespace Bookmory.Repositorios
{
    public class RepositorioGeneros : IRepositorioGeneros
    {
        readonly DirectorioDBContext _context;

        public RepositorioGeneros(DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<List<Genero>> ObtenerGeneros()
        {
            return await _context.Generos.Include(g => g.Libros).ToListAsync();
        }
        public async Task<List<Libro>> ObtenerLibrosPorGeneros(int id)
        {
            return await _context.Libros.Where(l=> l.Generos.Any(gen=>gen.Id == id)).Include(l=>l.Generos).ToListAsync();
        }

    }
}
