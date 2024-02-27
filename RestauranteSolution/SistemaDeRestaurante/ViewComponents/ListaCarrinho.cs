using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Models;
using SistemaDeRestaurante.Repositorio;

namespace SistemaDeRestaurante.ViewComponents
{
    public class ListaCarrinho : ViewComponent
    {
        private readonly IPedidosRepositorio _pedidos;
        private readonly ISystemLog _log;
        public ListaCarrinho(IPedidosRepositorio pedidosRepositorio, ISystemLog log)
        {
            _pedidos = pedidosRepositorio;
            _log = log; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var pedido = _pedidos.VerificarPedido();
                if(pedido == null)
                {
                    PedidosModel pedidoAtual = new PedidosModel();
                    ProdutosModel produtosModel = new ProdutosModel();
                    produtosModel.ID = 3;
                    produtosModel.Preco = 0;
                    produtosModel.Nome = "Nenhum Produto Ainda Foi Adicionado";
                    pedidoAtual.Produtos.Add(produtosModel);
                    return View(pedidoAtual);
                }
                return View(pedido);
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ListaCarrinhos/InvokeAsync: " + ex.Message);
                return View();
            }
        }
    }
}
