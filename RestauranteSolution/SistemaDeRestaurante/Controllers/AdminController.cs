using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaDeRestaurante.Logs;
using SistemaDeRestaurante.Models;
using SistemaDeRestaurante.Repositorio;

namespace SistemaDeRestaurante.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMesasRepositorio _mesas;
        private readonly IProdutoRepositorio _produto;
        private readonly ISystemLog _log;
        public AdminController(IMesasRepositorio mesasRepositorio, ISystemLog systemLog, IProdutoRepositorio produto) 
        {
            _mesas = mesasRepositorio;
            _log = systemLog;
            _produto = produto;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarMesa(MesaModel mesa)
        {
            try
            {
                if (ModelState.IsValid && _mesas.AdicionarMesa(mesa))
                {
                    TempData["SucessMessage"] = "Mesa adicionada!";
                    return RedirectToAction("Index");
                }
                return View("Index", mesa);
            }
            catch(Exception ex)
            {
                _log.ErrorMessage("Erro em AdminController/AdicionarMesa: " + ex.Message);
                return View("Index", mesa);
            }
        }

        public IActionResult AdicionarProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid && _produto.AdicionarProduto(produto))
                {
                    TempData["SucessMessage"] = "Produto adicionado!";
                    return RedirectToAction("Index");
                }
                return View("Index", produto);
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em AdminController/AdicionarProduto: " + ex.Message);
                return View("Index", produto);
            }
        }

        public IActionResult DeletarMesa(int id)
        {
            try
            {
                if (_mesas.DeletarMesa(id))
                {
                    TempData["SucessMessage"] = "Mesa deletada com sucesso!";
                    return View("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Não foi possível deletar a tabela!";
                    return View("Index");
                }
            }catch (Exception ex) {
                _log.ErrorMessage("Erro em AdminController/DeletarMesa: " + ex.Message);
                return View("Index");
            }
        }

        public IActionResult DeletarProduto(int id)
        {
            try
            {
                if (_produto.DeletarProduto(id))
                {
                    TempData["SucessMessage"] = "Produto deletado com sucesso!";
                    return View("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Não foi possível deletar o produto!";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em AdminController/DeletarProduto: " + ex.Message);
                return View("Index");
            }
        }

        public IActionResult Produtos()
        {
            return View();
        }

        public IActionResult TabelaMesas()
        {
            try
            {
                List<MesaModel> Mesas = _mesas.PegarMesas();
                if(Mesas == null || Mesas.Count < 0)
                {
                    _log.ErrorMessage("Erro em AdminController/TabelaMesas, a lista é nula");
                    TempData["ErrorMessage"] = "Você não adicionou nenhuma mesa ainda!";
                    return RedirectToAction("Index");
                }
                return View(Mesas);
            }catch (Exception ex)
            {
                _log.ErrorMessage("Erro em AdminController/TabelaMesas: " + ex.Message);
                return RedirectToAction("Index", "Admin");
            }
        }

        public IActionResult TabelaProdutos()
        {
            try
            {
                List<ProdutoModel> produtos = _produto.PegarProdutos();
                if (produtos == null)
                {
                    _log.ErrorMessage("Erro em AdminController/TabelaProdutos, a lista é nula");
                    TempData["ErrorMessage"] = "Você não adicionou nenhum produto ainda!";
                    return RedirectToAction("Index");
                }
                return View(produtos);
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em AdminController/TabelaProdutos: " + ex.Message);
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}
