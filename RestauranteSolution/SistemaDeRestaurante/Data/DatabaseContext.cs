using Microsoft.EntityFrameworkCore;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        
        }

       public DbSet<ContaModel> Contas { get; set; }
       public DbSet<PedidosModel> Pedidos { get; set; }
       public DbSet<ProdutosModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaModel>()
                .HasMany(o => o.Pedidos)
                .WithOne()
                .HasForeignKey(o => o.Id);

            modelBuilder.Entity<PedidosModel>()
                .HasMany(o => o.Produtos)
                .WithOne()
                .HasForeignKey(o => o.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
