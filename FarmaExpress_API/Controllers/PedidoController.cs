using AutoMapper;
using FarmaExpress.Models;
using FarmaExpress_API.Dto;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaExpress_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(IPedidoRepository pedidoRepository,
                                 IProductoRepository productoRepository,
                                 IUsuarioRepository usuarioRepository,
                                 IMapper mapper,
                                 ILogger<PedidoController> logger)
        {
            _pedidoRepository = pedidoRepository;
            _productoRepository = productoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _logger = logger;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                var pedidos = await _pedidoRepository.GetAllWithDetallesAsync();
                var pedidosDto = _mapper.Map<List<PedidoDto>>(pedidos);
                return Ok(pedidosDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los pedidos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los pedidos");
            }
        }

       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPedido(int id)
        {
            var pedido = await _pedidoRepository.GetByIdWithDetallesAsync(id);
            if (pedido == null)
                return NotFound("Pedido no encontrado.");

            var pedidoDto = _mapper.Map<PedidoDto>(pedido);
            return Ok(pedidoDto);
        }

     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearPedido([FromBody] PedidoCreateDto pedidoDto)
        {
            
            var usuarioExiste = await _usuarioRepository.ExistsAsync(u => u.UsuarioId == pedidoDto.UsuarioId);
            if (!usuarioExiste)
                return BadRequest("El usuario no existe.");

            
            var pedido = new Pedido
            {
                UsuarioId = pedidoDto.UsuarioId,
                Fecha = pedidoDto.Fecha,
                PagoTotal = pedidoDto.PagoTotal,
                Detalles = new List<PedidoDetalle>()
            };

            foreach (var detalleDto in pedidoDto.Detalles)
            {
                
                var producto = await _productoRepository.GetByIdAsync(detalleDto.ProductoId);
                if (producto == null)
                    return BadRequest($"El producto con ID {detalleDto.ProductoId} no existe.");

                if (producto.Stock < detalleDto.Cantidad)
                    return BadRequest($"No hay stock suficiente para el producto {producto.Nombre}.");

                producto.Stock -= detalleDto.Cantidad;

                pedido.Detalles.Add(new PedidoDetalle
                {
                    ProductoId = detalleDto.ProductoId,
                    Cantidad = detalleDto.Cantidad,
                    PrecioUnitario = detalleDto.PrecioUnitario
                });
            }

            await _pedidoRepository.CreateAsync(pedido);
            await _pedidoRepository.SaveChangesAsync();
            await _productoRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.PedidoId }, null);
        }
    }
}
