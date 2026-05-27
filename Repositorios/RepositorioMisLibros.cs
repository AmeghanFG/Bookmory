using Bookmory.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookmory.Repositorios
{
    public class RepositorioMisLibros : IRepositorioMisLibros
    {
        private readonly DirectorioDBContext _context;

        public RepositorioMisLibros(DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task AgregarLibro(int libroId)
        {
            MiLibro miLibro = new()
            {
                LibroId = libroId,
                EstadoId = 1 // Estado por defecto "No empezado"
            };

            _context.MisLibros.Add(miLibro);

            await _context.SaveChangesAsync();
        }

        public async Task<List<MiLibro>> ObtenerMisLibros()
        {
            return await _context.MisLibros
                .Include(m => m.Libro)
                .Include(m => m.Estado)
                .ToListAsync();
        }
    }
}