namespace SistemaDeRestaurante.Logs
{
    public interface ISystemLog
    {
        public string GetFilePath();
        public void ErrorMessage(string message);
    }
}
