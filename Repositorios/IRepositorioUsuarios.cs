using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioUsuarios
    {
        Task<List<UsuarioLibro>> ObtenerLibrosPorUsuario(int usuarioId);
        Task AgregarLibroPorUsuario(UsuarioLibro usuarioLibro);
        Task<bool> ExisteLibroUsuario(int usuarioId, int libroId);
    }
}
