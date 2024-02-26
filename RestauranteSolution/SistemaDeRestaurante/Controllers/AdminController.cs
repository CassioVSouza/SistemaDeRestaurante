using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Models;
using SistemaDeRestaurante.Repositorio;
using System.Diagnostics;

namespace SistemaDeRestaurante.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISystemLog _log;
        private readonly IContasRepositorio _contas;
        private readonly IPedidosRepositorio _pedidos;
        private readonly IProdutoRepositorio _produtos;

        public AdminController(ISystemLog systemLog, IContasRepositorio contasRepositorio, IPedidosRepositorio pedidosRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _log = systemLog;
            _contas = contasRepositorio;
            _pedidos = pedidosRepositorio;
            _produtos = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdicionarConta(ContaModel contaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_contas.AdicionarConta(contaModel))
                    {
                        TempData["SucessMessage"] = "Conta criada com sucesso!";
                        return View("Index");
                    }
                }
                return View("Index", contaModel);
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em HomeController/AdicionarConta: " + ex.Message);
                return View("Index", contaModel);
            }
        }

        public IActionResult DeletarConta(int id)
        {
            try
            {
                if (_contas.DeletarConta(id))
                {
                    TempData["SucessMessage"] = "Conta deletada com sucesso!";
                    return View("Index");
                }
                TempData["ErrorMessage"] = "Não foi possível deletar a conta!";
                _log.ErrorMsg("Erro ao tentar deletar uma conta, função do repositório retornou false");
                return View("Index");
            }catch(Exception ex)
            {
                _log.ErrorMsg("Erro em AdminController/DeletarConta: " + ex.Message);
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult AdicionarProdutos(ProdutosModel produtos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_produtos.AdicionarProduto(produtos)){
                        TempData["SucessMessage"] = "Produto Adicionado com sucesso!";
                        return View();
                    }
                    TempData["ErrorMessage"] = "Não foi possível adicionar o produto!";
                    _log.ErrorMsg("Erro em AdicionarProdutos, O metodo de adicionar retornou falso");
                    return View();
                }
                TempData["ErrorMessage"] = "Não foi possível adicionar o produto!";
                _log.ErrorMsg("Erro em AdicionarProdutos, O modelo enviado não é valido");
                return View();
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em AdminController/AdicionarProduto: " + ex.Message);
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
