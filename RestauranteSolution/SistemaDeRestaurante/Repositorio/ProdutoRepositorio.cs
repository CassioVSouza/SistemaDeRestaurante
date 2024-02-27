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
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ProdutoRepositorio/AdicionarProduto: " + ex.Message);
                return false;
            }
        }

        public bool DeletarProdutos(int id)
        {
            try
            {
                var Produto = EncontrarProduto(id);
                if (Produto == null)
                {
                    return false;
                }
                _dbContext.Produtos.Remove(Produto);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ProdutoRepositorio/DeletarProduto: " + ex.Message);
                return false;
            }
        }

        public ProdutosModel? EncontrarProduto(int id)
        {
            try
            {
                var Produto = _dbContext.Produtos.FirstOrDefault(o => o.ID == id);
                if (Produto == null)
                {
                    _log.ErrorMsg("Não foi possível encontrar um produto com o ID informado em ProdutoRepositorio/EncontrarProduto");
                    return null;
                }
                return Produto;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ProdutoRepositorio/EncontrarProduto: " + ex.Message);
                return null;
            }
        }

        public List<ProdutosModel>? PegarTodosOsProdutos()
        {
            try
            {
                var lista = _dbContext.Produtos.ToList();
                return lista;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ProdutoRepositorio/PegarTodosOsProdutos: " + ex.Message);
                return null;
            }
        }
    }
}
