namespace KTPO4311.Naumov.Lib.src.LogAn

{
    /// <summary> Анализатор log файлов </summary>

    public class LogAnalyzer : ILogAnalyzer
    {
        public LogAnalyzer() { }

        public event LogAnalyzerAction Analyzed = null;

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
                try
                {
                    IWebService srv = WebServiceFactory.Create();
                    srv.LogError("Слишком короткое имя файла: " + fileName);
                }
                catch (Exception e)
                {
                    IEmailService email = EmailServiceFactory.Create();
                    email.SendEmail("someone@somewhere.com", "Невозможно вызвать веб-сервис", e.Message);
                }
            }

            if (Analyzed != null)
            {
                Analyzed();
            }
        }

        protected void RaiseAnalyzedEvent()
        {
            if (Analyzed != null)
            {
                Analyzed();
            }

        }
    }

}
