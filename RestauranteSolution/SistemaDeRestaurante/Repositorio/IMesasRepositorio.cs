using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public interface IMesasRepositorio
    {
        public List<MesaModel> PegarMesas();
        public bool AdicionarMesa(MesaModel mesa);
        public bool DeletarMesa(int id);
    }
}
