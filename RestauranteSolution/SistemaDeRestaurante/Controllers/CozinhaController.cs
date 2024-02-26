using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Repositorio;

namespace SistemaDeRestaurante.Controllers
{
    public class CozinhaController : Controller
    {
        private readonly IPedidosRepositorio _pedidos;
        private readonly ISystemLog _log;
        public CozinhaController(IPedidosRepositorio pedidosRepositorio, ISystemLog systemLog)
        {
            _pedidos = pedidosRepositorio;
            _log = systemLog;
        }
        public IActionResult Index()
        {
            try
            {
                var lista = _pedidos.PegarTodosOsPedidos();
                return View(lista);
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em CozinhaController/Index: " + ex.Message);
                return View();
            }
        }
    }
}
