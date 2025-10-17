namespace KTPO4311.Naumov.Lib.src.LogAn
{
    /// <summary>
    /// Интерфейс для анализатора log файлов
    /// </summary>
    public interface ILogAnalyzer
    {
        /// <summary>
        /// Событие, возникающее при завершении анализа
        /// </summary>
        event LogAnalyzerAction Analyzed;

        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        bool IsValidLogFileName(string fileName);

        /// <summary>
        /// Анализ файла
        /// </summary>
        void Analyze(string fileName);
    }
}
