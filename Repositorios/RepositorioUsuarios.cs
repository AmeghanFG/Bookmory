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
                .Include(ul => ul.Estado)
                .AsNoTracking()
                .ToListAsync();
        }
        //public async Task AgregarLibrosPorUsuario(UsuarioLibro usuario)
        //{
        //    await _context.AddAsync(usuario);
        //    await _context.SaveChangesAsync();
        //}

        public async Task AgregarLibroPorUsuario(UsuarioLibro usuarioLibro)
        {
            _context.UsuarioLibros.Add(usuarioLibro);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarLibroPorUsuario(int id)
        {
            await _context.UsuarioLibros.Where(l => l.Id == id).ExecuteDeleteAsync();
        }

        public async Task<bool> ExisteLibroUsuario(int usuarioId, int libroId)
        {
            return await _context.UsuarioLibros.AnyAsync(u => u.UsuarioId == usuarioId && u.LibroId == libroId);
        }
        public async Task<UsuarioLibro> ObtenerUsuarioLibro(int id)
        {
            return await _context.UsuarioLibros.Include(ul => ul.Libro).Include(ul => ul.Estado).FirstOrDefaultAsync(ul => ul.Id == id);
        }

        public async Task ActualizarEstado(int ulid, int estadoid)
        {
            var ul = await ObtenerUsuarioLibro(ulid);
            ul.EstadoId = estadoid;
            await _context.SaveChangesAsync();
        }
    }
}