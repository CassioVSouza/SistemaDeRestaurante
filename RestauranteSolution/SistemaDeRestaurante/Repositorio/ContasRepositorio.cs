using SistemaDeRestaurante.Data;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public class ContasRepositorio : IContasRepositorio
    {
        private readonly DatabaseContext _dbContext;
        private readonly ISystemLog _log;
        public ContasRepositorio(DatabaseContext databaseContext, ISystemLog systemLog) 
        {
            _dbContext = databaseContext;
            _log = systemLog;
        }
        public bool AdicionarConta(ContaModel conta)
        {
            try
            {
                _dbContext.Contas.Add(conta);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ContasRepositorio/AdicionarConta: " + ex.Message);
                return false;
            }
        }

        public List<ContaModel> PegarTodasAsContas()
        {
            try
            {
                var Contas = _dbContext.Contas.ToList();
                return Contas;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ContasRepositorio/PegarTodasAsContas: " + ex.Message);
                return null;
            }
        }
    }
}
