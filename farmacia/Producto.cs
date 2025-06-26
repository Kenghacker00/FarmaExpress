using FarmaExpress.Models;
using System.ComponentModel.DataAnnotations;

public class Producto
{
    public int ProductoId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Range(0, 99999)]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    [StringLength(255)]
    public string ImagenUrl { get; set; }
}
