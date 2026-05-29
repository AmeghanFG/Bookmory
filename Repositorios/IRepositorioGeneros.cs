using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioGeneros
    {
        Task<List<Genero>> ObtenerGeneros();
        Task<List<Libro>> ObtenerLibrosPorGeneros(int id);
    }
}
