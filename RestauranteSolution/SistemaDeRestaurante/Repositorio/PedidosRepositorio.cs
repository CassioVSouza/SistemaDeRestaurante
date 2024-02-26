using SistemaDeRestaurante.Data;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public class PedidosRepositorio : IPedidosRepositorio
    {
        private readonly DatabaseContext _dbContext;
        private readonly ISystemLog _log;
        public PedidosRepositorio(DatabaseContext databaseContext, ISystemLog systemLog)
        {
            _dbContext = databaseContext;
            _log = systemLog;
        }
        public List<PedidosModel>? PegarTodosOsPedidos()
        {
            try
            {
                var lista = _dbContext.Pedidos.ToList();
                if(lista == null)
                {
                    return null;
                }
                return lista;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em PedidosRepositorio/PegarTodosOsPedidos: " + ex.Message);
                return null;
            }
        }
    }
}
