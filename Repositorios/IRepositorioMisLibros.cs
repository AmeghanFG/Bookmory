using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioMisLibros
    {

        // Aquí se usa bien el crud
        Task<bool> AgregarLibro(int libroId);

        Task EliminarLibro(int miLibroId);

        Task CambiarEstado(int miLibroId, string nuevoEstado);

        Task<List<MiLibro>> ObtenerMisLibros();
    }
}