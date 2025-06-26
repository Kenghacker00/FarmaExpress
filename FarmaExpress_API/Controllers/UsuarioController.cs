using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress.Models.Dto;
using FarmaExpress_API.Dto;
using FarmaExpress_API.Repository.IRepositories;
using FarmaExpress_API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FarmaExpress_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UsuarioController(IUsuarioRepository usuarioRepo, ILogger<UsuarioController> logger, IMapper mapper, IPasswordHasher<Usuario> Hasher, IEmailService emailService)
        {
            _usuarioRepo = usuarioRepo;
            _logger = logger;
            _mapper = mapper;
            _passwordHasher = Hasher;
            _emailService = emailService;
            
        }

        // GET: api/usuario/id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
               
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var usuario = await _usuarioRepo.ObtenerPorIdAsync(id);
            if (usuario == null) return NotFound("Usuario no encontrado.");
            return Ok(usuario);
        }

        [HttpPatch("cambiar-password/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CambiarPasswordPatch(
            int id,
            [FromBody] JsonPatchDocument<RestablecerPasswordDto> patchDto)
        {
            if (id <= 0)
                return BadRequest("ID de usuario no válido.");

            try
            {
                var usuario = await _usuarioRepo.GetByIdAsync(id);
                if (usuario == null)
                    return NotFound("Usuario no encontrado.");

                var cambiarPasswordDto = new RestablecerPasswordDto();
                patchDto.ApplyTo(cambiarPasswordDto, ModelState);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                usuario.ContraseñaHash = _passwordHasher.HashPassword(usuario, cambiarPasswordDto.NuevaContraseña);

                await _usuarioRepo.ActualizarAsync(usuario);
                await _usuarioRepo.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inesperado al aplicar el parche: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inesperado.");
            }
        }


        [HttpPost("solicitar-recuperacion")]
        public async Task<IActionResult> SolicitarRecuperacion(SolicitudRecuperacionDto dto)
        {
            var usuario = await _usuarioRepo.ObtenerPorGmailAsync(dto.Email);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            var codigo = new Random().Next(100000, 999999).ToString();

            usuario.CodigoRecuperacion = codigo;
            usuario.CodigoGeneradoEn = DateTime.UtcNow;

            await _usuarioRepo.SaveChangesAsync();

            await _emailService.EnviarCodigoVerificacion(dto.Email, codigo);

            return Ok("Código enviado");
        }


        [HttpPost("verificar-codigo")]
        public async Task<IActionResult> VerificarCodigo([FromBody] VerificacionCodigoDto dto)
        {
            var usuario = await _usuarioRepo.ObtenerPorGmailAsync(dto.Email);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            if (usuario.CodigoRecuperacion != dto.Codigo.ToString())
                return BadRequest("Código incorrecto");

            var minutosTranscurridos = (DateTime.UtcNow - usuario.CodigoGeneradoEn.Value).TotalMinutes;

            if (minutosTranscurridos > 10)
            {
                usuario.CodigoRecuperacion = null;
                usuario.CodigoGeneradoEn = null;
                await _usuarioRepo.SaveChangesAsync();

                return BadRequest("El código ha expirado");
            }

            usuario.CodigoRecuperacion = null;
            usuario.CodigoGeneradoEn = null;
            await _usuarioRepo.SaveChangesAsync();

            return Ok("Código correcto");
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> ObtenerPorEmail(string email)
        {
            var usuario = await _usuarioRepo.ObtenerPorGmailAsync(email);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            var dto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(dto);
        }

    }
}
