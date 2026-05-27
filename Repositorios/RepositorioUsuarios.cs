using Microsoft.EntityFrameworkCore;
using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        readonly DirectorioDBContext _context;

        public RepositorioUsuarios(DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioLibro>> ObtenerLibrosPorUsuario(int usuarioId)
        {
            return await _context.UsuarioLibros
                .Where(ul => ul.UsuarioId == usuarioId)
                .Include(ul => ul.Libro)
                    .ThenInclude(l => l.Autor)
                .Include(ul => ul.Libro)
                    .ThenInclude(l => l.Editorial)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task AgregarLibrosPorUsuario(UsuarioLibro usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
    }
}