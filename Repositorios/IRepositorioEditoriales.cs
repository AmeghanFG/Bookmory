using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioEditoriales
    {
        Task<List<Editorial>> ObtenerEditoriales();
        Task<Editorial> ObtenerEditorialPorID(int id);
    }
}
