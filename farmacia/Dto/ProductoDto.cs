namespace FarmaExpress_API.Dto
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public string ImagenUrl { get; set; }
    }

}
