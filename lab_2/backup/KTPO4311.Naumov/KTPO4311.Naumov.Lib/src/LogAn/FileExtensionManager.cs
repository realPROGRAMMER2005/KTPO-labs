namespace KTPO4311.Naumov.Lib.src.LogAn
{
    /// <summary>
    /// Менеджер для проверки расширений файлов.
    /// Предоставляет функциональность для валидации файлов на основе их расширений.
    /// </summary>
    public class FileExtensionManager : IExtensionManager
    {
        /// <summary>
        /// Проверяет валидность расширения указанного файла.
        /// </summary>
        /// <param name="fileName">Имя файла для проверки.</param>
        /// <returns>
        /// Возвращает true, если расширение файла поддерживается конфигурацией,
        /// в противном случае - false.
        /// </returns>
        public bool IsValid(string fileName)
        {
            // читать конфигурационный файл
            // вернуть true
            // если конфигурация поддерживается
            throw new NotImplementedException();
        }
    }
}