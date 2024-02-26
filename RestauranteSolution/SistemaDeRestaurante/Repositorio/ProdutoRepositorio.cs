using SistemaDeRestaurante.Data;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DatabaseContext _dbContext;
        private readonly ISystemLog _log;
        public ProdutoRepositorio(DatabaseContext databaseContext, ISystemLog log)
        {
            _dbContext = databaseContext;
            _log = log;
        }
        public bool AdicionarProduto(ProdutosModel produtos)
        {
            try
            {
                _dbContext.Produtos.Add(produtos);
                _dbContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ProdutoRepositorio/AdicionarProduto: " + ex.Message);
                return false;
            }
        }
    }
}
