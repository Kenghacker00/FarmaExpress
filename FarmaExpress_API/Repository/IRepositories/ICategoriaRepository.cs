using FarmaExpress.Models;
using FarmaExpress_API.Repository.IRepositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<List<Categoria>> GetAllWithProductosAsync();
    Task<Categoria> GetByIdWithProductosAsync(int id);
}
