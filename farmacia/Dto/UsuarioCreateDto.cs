using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FarmaExpress_API.Dto
{
    public class UsuarioCreateDto
    {
        [JsonPropertyName("nombre")]
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [JsonPropertyName("apellido")]
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [JsonPropertyName("email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonPropertyName("contraseña")]
        [Required]
        public string Contraseña { get; set; }
    }
}
