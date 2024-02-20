using SistemaDeRestaurante.Data;
using SistemaDeRestaurante.Logs;
using SistemaDeRestaurante.Models;

namespace SistemaDeRestaurante.Repositorio
{
    public class MesasRepositorio : IMesasRepositorio
    {
        private readonly DatabaseContext _dbContext;
        private readonly ISystemLog _log;
        public MesasRepositorio(DatabaseContext databaseContext, ISystemLog systemLog) 
        {
            _dbContext = databaseContext;
            _log = systemLog;
        }

        public bool AdicionarMesa(MesaModel mesa)
        {
            try
            {
                _dbContext.Mesa.Add(mesa);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em MesasRepositorio/AdicionarMesa: " + ex.Message);
                return false;
            }
        }

        public bool DeletarMesa(int id)
        {
            try
            {
                MesaModel mesa = EncontrarMesa(id);
                if(mesa == null)
                {
                    return false;
                }
                _dbContext.Mesa.Remove(mesa);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em MesasRepositorio/DeletarMesa: " + ex.Message);
                return false;
            }
        }

        private MesaModel EncontrarMesa(int id)
        {
            try
            {
                MesaModel? mesa = _dbContext.Mesa.FirstOrDefault(x => x.Id == id);
                if (mesa == null)
                {
                    _log.ErrorMessage("Usuario tentou deletar uma mesa, porém o ID não foi encontrado!");
                    return null;
                }
                return mesa;
            }
            catch (Exception ex)
            {
                _log.ErrorMessage("Erro em MesasRepositorio/EncontrarMesas: " + ex.Message);
                return null;
            }
        }

        public List<MesaModel> PegarMesas()
        {
            try
            {
                var ListaMesas = _dbContext.Mesa.ToList();
                return ListaMesas;
            }
            catch(Exception ex)
            {
                _log.ErrorMessage("Erro em MesasRepositorio/PegarMesas: " + ex.Message);
                return null;
            }
        }
    }
}
