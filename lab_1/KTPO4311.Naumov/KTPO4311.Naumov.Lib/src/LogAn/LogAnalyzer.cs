namespace KTPO4311.Naumov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName)) {
                throw new ArgumentException("Имя файла не может быть пустым");
            }
                


            if (!fileName.EndsWith(".NaumovDO", StringComparison.OrdinalIgnoreCase)) { 
                return false;
       
            }

            WasLastFileNameValid = true;
            return true;
       }
    }
}
