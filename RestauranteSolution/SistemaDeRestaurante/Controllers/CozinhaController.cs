using Microsoft.AspNetCore.Mvc;

namespace SistemaDeRestaurante.Controllers
{
    public class CozinhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
