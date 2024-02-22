namespace SistemaDeRestaurante.Repositorio
{
    public class SystemLog : ISystemLog
    {
        public void ErrorMsg(string message)
        {
            using(StreamWriter sw = new StreamWriter(GetLogPath()))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }

        private string GetLogPath()
        {
            string directory = "Log";
            string fileName = "Log.txt";
            string filePath = Path.Combine(directory, fileName);

            if(!File.Exists(filePath))
            {
                if(!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.Create(filePath).Close();
            }

            return filePath;
        }
    }
}
