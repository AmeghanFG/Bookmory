using Bookmory.Data;

namespace Bookmory.Repositorios
{
    public interface IRepositorioUsuarios
    {
        Task<List<UsuarioLibro>> ObtenerLibrosPorUsuario(int usuarioId);
        Task AgregarLibrosPorUsuario(UsuarioLibro usuario);
    }
}
