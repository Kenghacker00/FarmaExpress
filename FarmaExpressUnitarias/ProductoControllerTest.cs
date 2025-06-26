using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress_API.Controllers;
using FarmaExpress_API.Dto;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FarmaExpressUnitarias
{
    public class ProductoControllerTest
    {
        private readonly Mock<IProductoRepository> _mockProductoRepo;
        private readonly Mock<ICategoriaRepository> _mockCategoriaRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<ProductoController>> _mockLogger;
        private readonly ProductoController _controller;

        public ProductoControllerTest()
        {
            _mockProductoRepo = new Mock<IProductoRepository>();
            _mockCategoriaRepo = new Mock<ICategoriaRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<ProductoController>>();

            _controller = new ProductoController(
                _mockProductoRepo.Object,
                _mockCategoriaRepo.Object,
                _mockMapper.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public async Task GetProductos_ReturnsOk_WithProductoList()
        {
            // Arrange
            var productos = new List<Producto> {
                new Producto { ProductoId = 1, Nombre = "Paracetamol" }
            };
            var productosDto = new List<ProductoDto> {
                new ProductoDto { CategoriaId = 1, Nombre = "Paracetamol" }
            };

            _mockProductoRepo.Setup(r => r.GetAllWithCategoriaAsync()).ReturnsAsync(productos);
            _mockMapper.Setup(m => m.Map<List<ProductoDto>>(productos)).Returns(productosDto);

            // Act
            var result = await _controller.GetProductos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProductoDto>>(okResult.Value);
            Assert.Single(returnValue);
            Assert.Equal("Paracetamol", returnValue[0].Nombre);
        }


        [Fact]
        public async Task GetProducto_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            int productoId = 99;
            _mockProductoRepo.Setup(r => r.GetByIdWithCategoriaAsync(productoId))
                             .ReturnsAsync((Producto)null);

            // Act
            var result = await _controller.GetProducto(productoId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Producto no encontrado.", notFoundResult.Value);
        }
    }
}

