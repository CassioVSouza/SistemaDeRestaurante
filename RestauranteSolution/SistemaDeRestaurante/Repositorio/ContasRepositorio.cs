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

        public bool DeletarConta(int id)
        {
            try
            {
                var Conta = EncontrarConta(id);
                if(Conta == null)
                {
                    return false;
                }
                _dbContext.Contas.Remove(Conta);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _log.ErrorMsg("Erro em ContasRepositorio/DeletarConta: " + ex.Message);
                return false;
            }
        }

        private ContaModel? EncontrarConta(int id)
        {
            try
            {
                var Conta = _dbContext.Contas.FirstOrDefault(o => o.Id == id);
                if (Conta == null)
                {
                    _log.ErrorMsg("Não foi possível encontrar uma conta com o ID informado em ContasRepositorio/EncontrarConta");
                    return null;
                }
                return Conta;
            }
            catch (Exception ex)
            {
                _log.ErrorMsg("Erro em ContasRepositorio/EncontrarConta: " + ex.Message);
                return null;
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
