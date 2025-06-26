using FarmaExpress_API.Dto;


public class PedidoDetalleDto
{
    public int PedidoDetalleId { get; set; }
    public ProductoDto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
