using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public interface IProdutoRepositorio
    {
        public List<ProdutoModel> PegarProdutos();
        public bool AdicionarProduto(ProdutoModel produto);
        public bool DeletarProduto(int id);
        public ProdutoModel PegarProdutoPorId(int id);
    }
}
