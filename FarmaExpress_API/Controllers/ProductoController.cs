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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(IProductoRepository productoRepository, ICategoriaRepository categoriaRepository, IMapper mapper, ILogger<ProductoController> logger)
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var productos = await _productoRepository.GetAllWithCategoriaAsync();
                var productosDto = _mapper.Map<List<ProductoDto>>(productos);
                return Ok(productosDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los productos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los productos");
            }
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productoRepository.GetByIdWithCategoriaAsync(id);
            if (producto == null)
                return NotFound("Producto no encontrado.");

            var productoDto = _mapper.Map<ProductoDto>(producto);
            return Ok(productoDto);
        }

        
    }
}
