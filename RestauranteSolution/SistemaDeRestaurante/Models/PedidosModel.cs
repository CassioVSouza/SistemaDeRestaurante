using SistemaDeRestaurante.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeRestaurante.Models
{
    public class PedidosModel
    {
        public int ID { get; set; }
        public List<ProdutoModel> Produtos { get; set; } = null!;
        public MesaModel Mesa { get; set; } = null!;
        public int IDMesa { get; set; }
        public int Sessao { get; set; }
        public StatusPedido Status { get; set; }

        public PedidosModel()
        {
            Status = StatusPedido.Pendente;
        }
    }
}
