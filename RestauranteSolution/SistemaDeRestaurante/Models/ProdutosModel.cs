using System.ComponentModel.DataAnnotations;

namespace SistemaDeRestaurante.Models
{
    public class ProdutosModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Informe o nome do produto!")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "Informe o preço do produto!")]
        public double Preco { get; set; }
    }
}
