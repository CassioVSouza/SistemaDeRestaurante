using Microsoft.EntityFrameworkCore;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        
        }

        public DbSet<MesaModel> Mesa { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
