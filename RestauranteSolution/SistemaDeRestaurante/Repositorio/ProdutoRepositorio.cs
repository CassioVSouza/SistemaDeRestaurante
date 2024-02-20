using SistemaDeRestaurante.Data;
using SistemaDeRestaurante.Logs;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DatabaseContext _dbContext;
        private readonly ISystemLog _log;
        public ProdutoRepositorio(DatabaseContext databaseContext, ISystemLog systemLog)
        {
            _dbContext = databaseContext;
            _log = systemLog;
        }

        public bool AdicionarProduto(ProdutoModel produto)
        {
            try
            {
                _dbContext.Produtos.Add(produto);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em ProdutoRepositorio/AdicionarProduto: " + ex.Message);
                return false;
            }
        }

        public bool DeletarProduto(int id)
        {
            try
            {
                ProdutoModel produto = EncontrarProdutos(id);
                if (produto == null)
                {
                    return false;
                }
                _dbContext.Produtos.Remove(produto);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em ProdutoRepositorio/DeletarProduto: " + ex.Message);
                return false;
            }
        }

        private ProdutoModel EncontrarProdutos(int id)
        {
            try
            {
                ProdutoModel? produto = _dbContext.Produtos.FirstOrDefault(x => x.ID == id);
                if (produto == null)
                {
                    _log.ErrorMessage("Usuario tentou deletar um produto, porém o ID não foi encontrado!");
                    return null;
                }
                return produto;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em ProdutoRepositorio/EncontrarProdutos: " + ex.Message);
                return null;
            }
        }

        public List<ProdutoModel> PegarProdutos()
        {
            try
            {
                var listaProdutos = _dbContext.Produtos.ToList();
                return listaProdutos;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em ProdutoRepositorio/PegarProdutos: " + ex.Message);
                return null;
            }
        }

        public ProdutoModel PegarProdutoPorId(int id)
        {
            try
            {
                ProdutoModel? produto = _dbContext.Produtos.FirstOrDefault(o => o.ID == id);
                if(produto == null)
                {
                    _log.ErrorMessage("Erro em ProdutoRepositorio/PegarProdutosPorID: um cliente tentou adicionar um produto, porém o ID não foi encontrado!");
                    return null;
                }
                return produto;
            }catch(Exception ex)
            {
                _log.ErrorMessage("Erro em ProdutoRepositorio/PegarProdutoPorId: " + ex.Message);
                return null;
            }
        }
    }
}
