using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Logs;
using SistemaDeRestaurante.Models;
using SistemaDeRestaurante.Repositorio;

namespace SistemaDeRestaurante.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IProdutoRepositorio _produto;
        private readonly ISystemLog _log;
        public ClienteController(IProdutoRepositorio produtoRepositorio, ISystemLog systemLog)
        {
            _produto = produtoRepositorio;
            _log = systemLog;
        }
        public IActionResult Index()
        {
            try
            {
                List<ProdutoModel> produtos = _produto.PegarProdutos();
                return View(produtos);
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em ClienteController/Index: " + ex.Message);
                return RedirectToAction("Index", "Admin");
            }
        }

        public IActionResult AdicionarAoCarrinho(int id)
        {
            try
            {
                List<ProdutoModel> produtos = new List<ProdutoModel>();
                produtos.Add(_produto.PegarProdutoPorId(id));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em ClienteController/AdicionarCarrinho: " + ex.Message);
                return RedirectToAction("Index");
            }
            
        }
    }
}
