using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioUsuarios
    {
        Task<List<UsuarioLibro>> ObtenerLibrosPorUsuario(int usuarioId);
        Task AgregarLibroPorUsuario(UsuarioLibro usuarioLibro);
        Task EliminarLibroPorUsuario(int libroId);
        Task<bool> ExisteLibroUsuario(int usuarioId, int libroId);
        Task<UsuarioLibro> ObtenerUsuarioLibro(int id);
        Task ActualizarEstado(int ulid, int estadoid);
    }
}
