using Microsoft.AspNetCore.Mvc;
using SistemaDeRestaurante.Repositorio;

namespace SistemaDeRestaurante.ViewComponents
{
    public class ListaProdutos : ViewComponent
    {
        private readonly ISystemLog _log;
        private readonly IProdutoRepositorio _produtos;
        public ListaProdutos(ISystemLog log, IProdutoRepositorio produtoRepositorio)
        {
            _log = log;
            _produtos = produtoRepositorio;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var lista = _produtos.PegarTodosOsProdutos();
                if(lista == null)
                {
                    TempData["ErrorMessage"] = "Um erro ocorreu ao carregar a lista de produtos!";
                    return View("Index", "Admin");
                }
                return View(lista);
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ListaProdutos/InvokeAsync: " + ex.Message);
                return View("Index", "Admin");
            }
        }
    }
}
