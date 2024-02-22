using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeRestaurante.Models
{
    public class MesaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public List<PedidosModel> Pedidos { get; set; } = null!;
        public int IDPedidos { get; set; }
        public int Sessao { get; set; }
    }
}
