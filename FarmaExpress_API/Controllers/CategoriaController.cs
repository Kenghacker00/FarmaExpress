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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper, ILogger<CategoriaController> logger)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriaRepository.GetAllWithProductosAsync();
            var categoriasDto = _mapper.Map<List<CategoriaDto>>(categorias);
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetByIdWithProductosAsync(id);
            if (categoria == null)
                return NotFound("Categoría no encontrada.");

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return Ok(categoriaDto);
        }
    }
}
