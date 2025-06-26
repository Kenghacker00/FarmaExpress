namespace FarmaExpress_API.Dto
{
    public class PedidoUpdateDto
    {
        public int PedidoId { get; set; }
        public ICollection<ProductoDto> producto { get; set; }
        public int CantidadPedido { get; set; }
        public decimal PagoTotal { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
