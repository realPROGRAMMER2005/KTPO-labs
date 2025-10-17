namespace KTPO4311.Naumov.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика диспетчеров расширений файлов
    /// </summary>
    public static class ExtensionManagerFactory
    {
        private static IExtensionManager _customManager = null;

        /// <summary>
        /// Создание объектов
        /// </summary>
        public static IExtensionManager Create()
        {
            return _customManager ?? new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager mgr)
        {
            _customManager = mgr;
        }
    }
}
