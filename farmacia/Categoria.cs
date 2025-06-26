using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaExpress.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        // Relación uno a muchos: una categoría puede tener muchos productos
        public ICollection<Producto> Productos { get; set; }
    }
}
