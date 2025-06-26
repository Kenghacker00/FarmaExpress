using FarmaExpress.Models;

public class Pedido
{
    public int PedidoId { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    public decimal PagoTotal { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
}
