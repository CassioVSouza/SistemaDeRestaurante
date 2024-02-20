using System.ComponentModel.DataAnnotations;

namespace SistemaDeRestaurante.Models
{
    public class MesaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, insira um nome para a mesa!")]
        public string Nome { get; set; } = null!;
        public ICollection<PedidosModel>? Pedidos { get; set; }
        public int? IDPedidos { get; set; }
        public int? Sessao { get; set; }
    }
}
