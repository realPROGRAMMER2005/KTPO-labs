namespace KTPO4311.Naumov.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика веб-сервисов
    /// </summary>
    public static class WebServiceFactory
    {
        private static IWebService _customService = null;

        /// <summary>
        /// Создание объектов
        /// </summary>
        public static IWebService Create()
        {
            return _customService ?? new WebService();
        }

        public static void SetService(IWebService service)
        {
            _customService = service;
        }
    }
}
