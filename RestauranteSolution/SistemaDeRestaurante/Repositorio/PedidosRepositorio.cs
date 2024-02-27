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

        public void SalvarPedido(PedidosModel pedidosModel)
        {
            try
            {
                _dbContext.Pedidos.Add(pedidosModel);
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {
                _log.ErrorMsg("Erro em PedidosRepositorio/SalvarPedido");
            }
        }

        public PedidosModel? VerificarPedido()
        {
            try
            {
                var pedidoAberto = _dbContext.Pedidos.FirstOrDefault(o => o.StatusPedido == Enums.StatusPedido.Pedindo);
                if(pedidoAberto == null)
                {
                    return null;
                }
                return pedidoAberto;
            }
            catch(Exception ex)
            {
                _log.ErrorMsg("Erro em PedidosRepositorio/VerificarPedido: " + ex.Message);
                return null;
            }
        }
    }
}
