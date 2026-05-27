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
            return await _context.Generos.ToListAsync();
        }
    }
}
