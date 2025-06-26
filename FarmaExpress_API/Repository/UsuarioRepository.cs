using FarmaExpress.Models;
using FarmaExpress_API.Data;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;

namespace FarmaExpress_API.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly FarmaciaDbContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UsuarioRepository(FarmaciaDbContext context, IPasswordHasher<Usuario> passwordHasher)
            : base(context)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Usuario> AutenticarAsync(string gmail, string plainPassword)
        {
            var usuario = await GetAsync(u => u.Email == gmail);
            if (usuario != null && _passwordHasher.VerifyHashedPassword(usuario, usuario.ContraseñaHash, plainPassword) == PasswordVerificationResult.Success)
            {
                return usuario;
            }
            return null;
        }

        public async Task CambiarPasswordPorCorreoAsync(string gmail, string nuevoPassword)
        {
            var usuario = await GetAsync(u => u.Email == gmail);
            if (usuario != null)
            {
                usuario.ContraseñaHash = _passwordHasher.HashPassword(usuario, nuevoPassword);
                await SaveChangesAsync();
            }
        }

        public async Task<bool> CorreoExisteAsync(string gmail)
        {
            return await ExistsAsync(u => u.Email == gmail);
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await GetAsync(u => u.UsuarioId == id);
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            var existente = await GetByIdAsync(usuario.UsuarioId);
            if (existente == null) return;

            existente.Nombre = usuario.Nombre;
            existente.Apellido = usuario.Apellido;
            existente.Email = usuario.Email;

            existente.ContraseñaHash = usuario.ContraseñaHash;

            await SaveChangesAsync();
        }


        public async Task CrearConHashAsync(Usuario usuario, string password)
        {
            usuario.ContraseñaHash = _passwordHasher.HashPassword(usuario, password);
            await _context.usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetByUserNameAsync(string username)
        {
            return await _context.usuarios.SingleOrDefaultAsync(u => u.Nombre == username);
        }

        public async Task<Usuario> ObtenerPorGmailAsync(string email)
        {
            return await _context.usuarios.SingleOrDefaultAsync(u => u.Email.ToLower() == email);
        }

        public async Task<bool> VerificarUsuario(string gmail, string password)
        {
            var user = await ObtenerPorGmailAsync(gmail);
            if (user == null) return false;

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.ContraseñaHash, password);
            return verificationResult == PasswordVerificationResult.Success;
        }
    }
}
