using System.ComponentModel.DataAnnotations;

namespace FarmaExpress_API.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Gmail { get; set; }

        [Required]
        public string ContraseñaHash { get; set; }
        public ICollection<PedidoDto> PedidosRealizados { get; set; }
    }
}
