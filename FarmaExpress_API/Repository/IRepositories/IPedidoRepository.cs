using FarmaExpress.Models;

namespace FarmaExpress_API.Repository.IRepositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<List<Pedido>> GetAllWithDetallesAsync();
        Task<Pedido> GetByIdWithDetallesAsync(int id);
        Task<Pedido> ObtenerPorUsuarioAsync(string usuario);
    }
}
