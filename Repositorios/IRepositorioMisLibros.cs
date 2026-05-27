using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioMisLibros
    {
        Task AgregarLibro(int libroId);

        Task<List<MiLibro>> ObtenerMisLibros();
    }
}