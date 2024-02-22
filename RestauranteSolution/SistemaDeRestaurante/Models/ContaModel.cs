using SistemaDeRestaurante.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeRestaurante.Models
{
    public class ContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Você precisa digitar um nome para a conta!")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "Você precisa escolher um tipo para a conta!")]
        public EnumPerfil Perfil { get; set; }
        [Required(ErrorMessage = "Você precisa digitar uma senha para a conta!")]
        public string Senha { get; set; } = null!;
        public List<PedidosModel>? Pedidos { get; set; } 
    }
}
