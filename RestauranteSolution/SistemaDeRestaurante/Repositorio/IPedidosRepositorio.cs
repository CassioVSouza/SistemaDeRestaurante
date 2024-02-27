using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public interface IPedidosRepositorio
    {
        List<PedidosModel>? PegarTodosOsPedidos();
        PedidosModel? VerificarPedido();
        void SalvarPedido(PedidosModel pedidosModel);
    }
}
