using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Data;
using SistemaDeRestaurante.Models;
using SistemaDeRestaurante.Repositorio;

namespace SistemaDeRestaurante.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DatabaseContext _dbContext;
        private readonly ISystemLog _log;
        private readonly IProdutoRepositorio _produtos;
        private readonly IPedidosRepositorio _pedidos;
        public ClienteController(IPedidosRepositorio pedidosRepositorio ,DatabaseContext databaseContext, ISystemLog systemLog, IProdutoRepositorio produtos)
        {
            _dbContext = databaseContext;
            _log = systemLog;
            _produtos = produtos;
            _pedidos = pedidosRepositorio;
        }
        public IActionResult Index()
        {
            try 
            {
                var lista = _produtos.PegarTodosOsProdutos();
                return View(lista);
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ClienteController/Index: " + ex.Message);
                return View();
            }
        }

        public IActionResult AdicionarAoCarrinho(int id)
        {
            try
            {
                ProdutosModel? produto = _produtos.EncontrarProduto(id);
                var pedido = _pedidos.VerificarPedido();
                if(pedido == null)
                {
                    PedidosModel pedidoAtual = new PedidosModel();
                    pedidoAtual.Produtos.Add(produto);
                    _pedidos.SalvarPedido(pedidoAtual);
                    return View("Index");
                }
                pedido.Produtos.Add(produto);
                _pedidos.SalvarPedido(pedido);
                return View("Index");
            }
            catch(Exception ex)
            {
                _log.ErrorMsg("Erro em ClienteController/AdicionarAoCarrinho: " + ex.Message);
                return View("Index");
            }
        }
    }
}
