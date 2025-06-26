using AutoMapper;
using FarmaExpress_API.Controllers;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using FarmaExpress.Models;
using FarmaExpress_API.Dto;
using Microsoft.AspNetCore.Mvc;


namespace FarmaExpressUnitarias
{
    public class CategoriaControllerTest
    {
        private readonly Mock<ICategoriaRepository> _mockRepo;
        private readonly Mock<IMapper> _mockmapper;
        private readonly Mock<ILogger<CategoriaController>> _mockLogger;
        private readonly CategoriaController _MockCategoriaController;

        public  CategoriaControllerTest()
        {
            _mockRepo = new Mock<ICategoriaRepository>();
            _mockmapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<CategoriaController>>();
            _MockCategoriaController = new CategoriaController(
                _mockRepo.Object,
                _mockmapper.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task GetCategoria_ReturnsOkResult_WithCategoria()
        {
            // Arrange
            var categoria = new Categoria { CategoriaId = 1, Nombre = "Analgésicos" };
            var categoriaDto = new CategoriaDto { CategoriaId = 1, Nombre = "Analgésicos" };

            _mockRepo.Setup(repo => repo.GetByIdWithProductosAsync(1)).ReturnsAsync(categoria);
            _mockmapper.Setup(mapper => mapper.Map<CategoriaDto>(categoria)).Returns(categoriaDto);

            // Act
            var result = await _MockCategoriaController.GetCategoria(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CategoriaDto>(okResult.Value);
            Assert.Equal("Analgésicos", returnValue.Nombre);
        }

        [Fact]
        public async Task GetCategoria_ReturnsNotFound_WhenCategoriaDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdWithProductosAsync(999)).ReturnsAsync((Categoria)null);

            // Act
            var result = await _MockCategoriaController.GetCategoria(999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Categoría no encontrada.", notFoundResult.Value);
        }

    }
}
