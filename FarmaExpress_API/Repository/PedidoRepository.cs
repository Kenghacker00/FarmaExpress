using FarmaExpress_API.Repository.IRepositories;
using FarmaExpress_API.Repository;
using FarmaExpress_API.Data;
using Microsoft.EntityFrameworkCore;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    private readonly FarmaciaDbContext _context;

    public PedidoRepository(FarmaciaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Pedido> ObtenerPorUsuarioAsync(string usuario)
    {
        return await _context.pedidos
            .Include(p => p.Usuario)
            .Include(p => p.Detalles).ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(p => p.Usuario.Email.ToLower() == usuario.ToLower());

    }

    public async Task<List<Pedido>> GetAllWithDetallesAsync()
    {
        return await _context.pedidos
            .Include(p => p.Usuario)
            .Include(p => p.Detalles).ThenInclude(d => d.Producto)
            .ToListAsync();
    }

    public async Task<Pedido> GetByIdWithDetallesAsync(int id)
    {
        return await _context.pedidos
            .Include(p => p.Usuario)
            .Include(p => p.Detalles).ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(p => p.PedidoId == id);
    }
}
