using Microsoft.EntityFrameworkCore;
using Bookmory.Data;
using Bookmory.Repositorios;

namespace Bookmory.Repositorios
{
    public class RepositorioAutores : IRepositorioAutores
    {
        readonly DirectorioDBContext _context;

        public RepositorioAutores(DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<Autor?> ObtenerAutorPorId(int id)
        {
            return await _context.Autores.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Autor>> ObtenerAutores()
        {
            return await _context.Autores.AsNoTracking().ToListAsync();
        }
    }
}
