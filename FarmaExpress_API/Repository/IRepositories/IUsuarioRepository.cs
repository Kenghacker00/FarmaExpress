using FarmaExpress.Models;

namespace FarmaExpress_API.Repository.IRepositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> AutenticarAsync(string gmail, string plainPassword);
        Task<bool> CorreoExisteAsync(string gmail);
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task ActualizarAsync(Usuario usuario);
        Task CambiarPasswordPorCorreoAsync(string gmail, string nuevoPassword);
        Task CrearConHashAsync(Usuario usuario, string contraseña);

        Task<Usuario> GetByUserNameAsync(string username);

        Task<Usuario> ObtenerPorGmailAsync(string email);
        Task<bool> VerificarUsuario(string gmail, string password);
    }
}
