using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress.Models.Dto;
using FarmaExpress_API.Controllers;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmaExpress_API.Dto;

namespace FarmaExpressUnitarias
{
    public class AuthControllerTest
    {
        private readonly Mock<IUsuarioRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IConfiguration> _mockConfig;
        private readonly AuthController _authController;

        public AuthControllerTest()
        {
            _mockRepo = new Mock<IUsuarioRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockConfig = new Mock<IConfiguration>();

            _authController = new AuthController(
                _mockRepo.Object,
                _mockMapper.Object,
                _mockConfig.Object
            );
        }

        [Fact]
        public async Task Register_EmailAlreadyExists_ReturnsBadRequest()
        {
            // Arrange
            var userDto = new UsuarioCreateDto
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan@correo.com",
                Contraseña = "1234"
            };

            _mockRepo.Setup(r => r.ObtenerPorGmailAsync(userDto.Email))
                     .ReturnsAsync(new Usuario());

            // Act
            var result = await _authController.Register(userDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("Esta cuenta ya existe", badRequest.Value.ToString());
        }
    }
}
