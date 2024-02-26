using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public interface IPedidosRepositorio
    {
        List<PedidosModel>? PegarTodosOsPedidos();
    }
}
