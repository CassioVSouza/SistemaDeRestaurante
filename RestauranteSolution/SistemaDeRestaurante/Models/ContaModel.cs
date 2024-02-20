using SistemaDeRestaurante.Enums;

namespace SistemaDeRestaurante.Models
{
    public class ContaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public PerfilConta PerfilConta { get; set; }
        public string Senha { get; set; } = null!;
    }
}
