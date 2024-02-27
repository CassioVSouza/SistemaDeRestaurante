using SistemaDeRestaurante.Enums;

namespace SistemaDeRestaurante.Models
{
    public class PedidosModel
    {
        public PedidosModel() 
        {
            StatusPedido = StatusPedido.Pedindo;
        }
        public int Id { get; set; }
        public List<ProdutosModel> Produtos { get; set; } = null!;
        public StatusPedido StatusPedido { get; set; }
    }
}
