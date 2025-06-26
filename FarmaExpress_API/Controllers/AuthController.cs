using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress.Models.Dto;
using FarmaExpress_API.Dto;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Bcpg;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FarmaExpress_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController( IUsuarioRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("registro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UsuarioCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
 
            
            var existingUser = await _userRepository.ObtenerPorGmailAsync(model.Email);
            if (existingUser != null) return BadRequest(new { message = "Esta cuenta ya existe" });

            var user = _mapper.Map<Usuario>(model);

            try
            {
                await _userRepository.CrearConHashAsync(user, model.Contraseña);
                return Ok("Usuario registrado de forma exitosa");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string gmail = model.Gmail.Trim().ToLower();
            var user = await _userRepository.ObtenerPorGmailAsync(gmail);

            if (user == null)
            {
                return Unauthorized("Credenciales invalidas.");
            }

            bool esValida = await _userRepository.VerificarUsuario(gmail, model.Contraseña);

            if (!esValida)
            {
                return Unauthorized("Contraseña incorrecta.");
            }

            var token = GenerateJwtToken(user);
            return Ok(new
            {
                token = token,
                usuarioId = user.UsuarioId
            });

        }

        private string GenerateJwtToken(Usuario user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("Key"));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Name, user.Nombre),
                }),
                Issuer = jwtSettings.GetValue<string>("Issuer"),
                Audience = jwtSettings.GetValue<string>("Audience"),
                Expires = DateTime.UtcNow.AddHours(1), //Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
