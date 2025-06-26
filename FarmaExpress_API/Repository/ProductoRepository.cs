using FarmaExpress.Models;
using FarmaExpress_API.Data;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FarmaExpress_API.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly FarmaciaDbContext _context;

        public ProductoRepository(FarmaciaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllWithCategoriaAsync()
        {
            return await _context.productos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Producto> GetByIdWithCategoriaAsync(int id)
        {
            return await _context.productos.Include(p => p.Categoria)
                                            .FirstOrDefaultAsync(p => p.ProductoId == id);
        }
    }
}
