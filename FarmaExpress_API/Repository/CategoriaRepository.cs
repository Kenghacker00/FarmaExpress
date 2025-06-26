using FarmaExpress.Models;
using FarmaExpress_API.Data;
using FarmaExpress_API.Repository;
using Microsoft.EntityFrameworkCore;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private readonly FarmaciaDbContext _context;

    public CategoriaRepository(FarmaciaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> GetAllWithProductosAsync()
    {
        return await _context.categorias.Include(c => c.Productos).ToListAsync();
    }

    public async Task<Categoria> GetByIdWithProductosAsync(int id)
    {
        return await _context.categorias
            .Include(c => c.Productos)
            .FirstOrDefaultAsync(c => c.CategoriaId == id);
    }
}
