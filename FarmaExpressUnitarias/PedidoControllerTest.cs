using AutoMapper;
using FarmaExpress_API.Controllers;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

public class PedidoControllerTest
{
    private readonly Mock<IPedidoRepository> _mockPedidoRepo;
    private readonly Mock<IProductoRepository> _mockProductoRepo;
    private readonly Mock<IUsuarioRepository> _mockUsuarioRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ILogger<PedidoController>> _mockLogger;
    private readonly PedidoController _pedidoController;

    public PedidoControllerTest()
    {
        _mockPedidoRepo = new Mock<IPedidoRepository>();
        _mockProductoRepo = new Mock<IProductoRepository>();
        _mockUsuarioRepo = new Mock<IUsuarioRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockLogger = new Mock<ILogger<PedidoController>>();

        _pedidoController = new PedidoController(
            _mockPedidoRepo.Object,
            _mockProductoRepo.Object,
            _mockUsuarioRepo.Object,
            _mockMapper.Object,
            _mockLogger.Object
        );
    }

    [Fact]
    public async Task CrearPedido_UsuarioNoExiste_ReturnsBadRequest()
    {
        // Arrange
        var pedidoDto = new PedidoCreateDto
        {
            UsuarioId = 99, // Usuario que no existe
            Fecha = DateTime.Now,
            PagoTotal = 100,
            Detalles = new List<PedidoDetalleCreateDto>() 
        };

        _mockUsuarioRepo.Setup(r => r.ExistsAsync(u => u.UsuarioId == pedidoDto.UsuarioId)).ReturnsAsync(false);

        // Act
        var result = await _pedidoController.CrearPedido(pedidoDto);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("El usuario no existe.", badRequest.Value);
    }
}
