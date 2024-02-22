using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Repositorio;
using System.ComponentModel;

namespace SistemaDeRestaurante.ViewComponents
{
    public class ListaContas : ViewComponent
    {
        private readonly IContasRepositorio _contas;
        private readonly ISystemLog _log;

        public ListaContas(IContasRepositorio contasRepositorio, ISystemLog log)
        {
            _contas = contasRepositorio;
            _log = log; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var Contas = _contas.PegarTodasAsContas();
                if(Contas != null) 
                {
                    return View(Contas);
                }
                TempData["ErrorMessage"] = "Houve um erro ao carregar as contas!";
                _log.ErrorMsg("Erro ao carregar as contas em ListaContas/InvokeAsync");
                return View("Index", "Admin");
            }
            catch(Exception ex)
            {
                _log.ErrorMsg("Erro em ListaContas/InvokeAsync: " + ex.Message);
                return View("Index", "Admin");
            }
        }
    }
}
