using FarmaExpress_API.Dto;

public class PedidoDto
{
    public int PedidoId { get; set; }
    public UsuarioDto Usuario { get; set; }
    public List<PedidoDetalleDto> Detalles { get; set; }
    public decimal PagoTotal { get; set; }
    public DateTime Fecha { get; set; }
}
