using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress.Models.Dto;
using FarmaExpress_API.Controllers;
using FarmaExpress_API.Repository.IRepositories;
using FarmaExpress_API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FarmaExpressUnitarias
{
    public class UsuarioControllerTest
    {
        private readonly Mock<IUsuarioRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<UsuarioController>> _mockLogger;
        private readonly Mock<IPasswordHasher<Usuario>> _mockHasher;
        private readonly Mock<IEmailService> _mockEmail;
        private readonly UsuarioController _controller;

        public UsuarioControllerTest()
        {
            _mockRepo = new Mock<IUsuarioRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<UsuarioController>>();
            _mockHasher = new Mock<IPasswordHasher<Usuario>>();
            _mockEmail = new Mock<IEmailService>();

            _controller = new UsuarioController(
                _mockRepo.Object,
                _mockLogger.Object,
                _mockMapper.Object,
                _mockHasher.Object,
                _mockEmail.Object
            );
        }

        [Fact]
        public async Task CambiarPasswordPatch_Retorna204CuandoExitoso()
        {
            // Arrange
            int id = 1;
            var usuario = new Usuario { UsuarioId = id, ContraseñaHash = "viejaHash" };
            var nuevaContraseña = "nuevaSegura123";

            _mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(usuario);
            _mockRepo.Setup(r => r.ActualizarAsync(It.IsAny<Usuario>())).Returns(Task.CompletedTask);
            _mockRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);
            _mockHasher.Setup(h => h.HashPassword(usuario, nuevaContraseña)).Returns("nuevaHash");

            var patchDoc = new JsonPatchDocument<RestablecerPasswordDto>();
            patchDoc.Replace(x => x.NuevaContraseña, nuevaContraseña);

            // Act
            var resultado = await _controller.CambiarPasswordPatch(id, patchDoc);

            // Assert
            var resultadoNoContent = Assert.IsType<NoContentResult>(resultado);
            _mockRepo.Verify(r => r.ActualizarAsync(It.IsAny<Usuario>()), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
