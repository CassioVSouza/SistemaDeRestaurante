using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public interface IContasRepositorio
    {
        bool AdicionarConta(ContaModel conta);
        List<ContaModel> PegarTodasAsContas();
    }
}
