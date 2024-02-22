namespace SistemaDeRestaurante.Logs
{
    public class SystemLog : ISystemLog
    {
        public void ErrorMessage(string message)
        {
            using(StreamWriter sw = new StreamWriter(GetFilePath())) 
            {
                sw.Write(message);
                sw.Close();
            }
        }

        public string GetFilePath()
        {
            string directory = "Logs";
            string fileName = "Logs.txt";
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
