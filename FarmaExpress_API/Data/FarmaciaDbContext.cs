using FarmaExpress.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaExpress_API.Data
{
    public class FarmaciaDbContext : DbContext
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options) { }

        public DbSet<Producto> productos { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Categoria> categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PagoTotal)
                    .HasPrecision(18, 2);  // Aquí defines precisión y escala
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio)
                    .HasPrecision(18, 2);
            });
            modelBuilder.Entity<PedidoDetalle>()
                .Property(p => p.PrecioUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.PagoTotal)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
