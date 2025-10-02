namespace KTPO4311.Naumov.Lib.src.LogAn

{
    /// <summary> Анализатор log файлов </summary>
    public class LogAnalyzer


    {
        private readonly IExtensionManager _mgr;

        public LogAnalyzer(IExtensionManager mgr) { _mgr = mgr; }

        /// <summary> Проверка правильности имени файла </summary>

        public bool IsValidLogFileName(string fileName)
        {
            try
            {
                return _mgr.IsValid(fileName);
            }
            catch (Exception)
            {
                // При возникновении исключения возвращаем false
                return false;
            }
            
       }
    }
}
