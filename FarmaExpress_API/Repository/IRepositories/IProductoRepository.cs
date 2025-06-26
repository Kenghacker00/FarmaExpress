using FarmaExpress.Models;

namespace FarmaExpress_API.Repository.IRepositories
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<List<Producto>> GetAllWithCategoriaAsync();
        Task<Producto> GetByIdWithCategoriaAsync(int id);
    }

}
