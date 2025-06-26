using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaExpress.Models
{
    public class Usuario
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
        public string Email { get; set; }

        [Required]
        public string ContraseñaHash { get; set; }

        public ICollection<Pedido> PedidosRealizados { get; set; } = new List<Pedido>();

        public string? CodigoRecuperacion { get; set; }
        public DateTime? CodigoGeneradoEn { get; set; }

    }
}
