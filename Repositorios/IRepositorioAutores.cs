using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioAutores
    {
        Task<List<Autor>> ObtenerAutores();
        Task<Autor?> ObtenerAutorPorId(int id);
    }
}
