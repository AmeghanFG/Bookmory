using Microsoft.EntityFrameworkCore;
using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public class RepositorioEditoriales : IRepositorioEditoriales
    {
        readonly DirectorioDBContext _context;

        public RepositorioEditoriales(DirectorioDBContext context)
        {
            _context = context;
        }

        public async Task<Editorial?> ObtenerEditorialPorId(int id)
        {
            return await _context.Editoriales.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Editorial>> ObtenerEditoriales()
        {
            return await _context.Editoriales.AsNoTracking().Include(e => e.Libros).ToListAsync();
        }

        public Task<Editorial> ObtenerEditorialPorID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
