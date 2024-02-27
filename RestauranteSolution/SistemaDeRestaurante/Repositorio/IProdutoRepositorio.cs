using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public interface IProdutoRepositorio
    {
        bool AdicionarProduto(ProdutosModel produto);
        List<ProdutosModel>? PegarTodosOsProdutos();

        bool DeletarProdutos(int id);
    }
}
