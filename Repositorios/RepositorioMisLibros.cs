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

        public async Task<bool> AgregarLibro(int libroId)
        {
            bool yaAgregado = await _context.MisLibros
                .AnyAsync(m => m.LibroId == libroId);

            if (yaAgregado)
            {
                return false;
            }

            MiLibro miLibro = new()
            {
                LibroId = libroId,
                EstadoId = 1 // Por defecto, inicia con el estado "No empezado"
            };

            _context.MisLibros.Add(miLibro);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task EliminarLibro(int miLibroId)
        {
            MiLibro? miLibro = await _context.MisLibros.FirstOrDefaultAsync(m => m.Id == miLibroId);

            if (miLibro == null) return;

            _context.MisLibros.Remove(miLibro);

            await _context.SaveChangesAsync();
        }

        public async Task CambiarEstado(int miLibroId, string nuevoEstado)
        {
            MiLibro? miLibro = await _context.MisLibros
                .FirstOrDefaultAsync(m => m.Id == miLibroId);

            if (miLibro == null)
                return;

            Estado? estado = await _context.Estados.FirstOrDefaultAsync(e => e.TipoEstado == nuevoEstado);

            if (estado == null) return;

            miLibro.EstadoId = estado.Id;

            await _context.SaveChangesAsync();
        }

        public async Task<List<MiLibro>> ObtenerMisLibros()
        {
            // Poner .ThenInclude para cargar el autor del libro (es para relación anidada, si no me da null, no se muestra nada, tener cuidado por que es error sutil, me dio un quebradero de cabeza, documentación por si se me olvida: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.theninclude?view=efcore-10.0)
            return await _context.MisLibros.Include(m => m.Libro).ThenInclude(l => l.Autor).Include(m => m.Estado).AsNoTracking().ToListAsync();
        }
    }
}