using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FarmaExpress.Models.Dto
{
    public class LoginDto
    {

        [JsonPropertyName("gmail")]
        [Required]
        public string Gmail { get; set; }

        [JsonPropertyName("contraseña")]
        [Required]
        public string Contraseña { get; set; }

    }
}
