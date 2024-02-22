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

        public AdminController(ISystemLog systemLog, IContasRepositorio contasRepositorio)
        {
            _log = systemLog;
            _contas = contasRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarConta(ContaModel contaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_contas.AdicionarConta(contaModel))
                    {
                        TempData["SucessMessage"] = "Conta criada com sucesso!";
                        return View("Privacy");
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
