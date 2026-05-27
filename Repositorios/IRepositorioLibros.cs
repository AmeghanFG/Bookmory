using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioLibros
    {
        Task<List<Libro>> ObtenerLibros();
    }
}
