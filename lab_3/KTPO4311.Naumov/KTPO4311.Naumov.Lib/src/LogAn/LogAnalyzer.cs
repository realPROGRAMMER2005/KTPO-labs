namespace KTPO4311.Naumov.Lib.src.LogAn

{
    /// <summary> Анализатор log файлов </summary>

    public class LogAnalyzer
    {
        public LogAnalyzer() { }

        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
            var mgr = ExtensionManagerFactory.Create();
            try
            {
                return mgr.IsValid(fileName);
            }
            catch (Exception)
            {
                // При возникновении исключения возвращаем false
                return false;
            }
        }

        public void Analyze(string fileName) 
        {
            if (fileName.Length < 8)
            {
                IWebService service = WebServiceFactory.Create();
                service.LogError("Слишком короткое имя файла: " + fileName);
            }
        }
    }

}
