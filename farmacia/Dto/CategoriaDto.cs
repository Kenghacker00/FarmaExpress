using System.ComponentModel.DataAnnotations;

namespace FarmaExpress_API.Dto
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public ICollection<ProductoDto> Productos { get; set; }
    }
}
