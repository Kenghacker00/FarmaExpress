public class PedidoCreateDto
{
    public int UsuarioId { get; set; }
    public List<PedidoDetalleCreateDto> Detalles { get; set; }
    public decimal PagoTotal { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
}
