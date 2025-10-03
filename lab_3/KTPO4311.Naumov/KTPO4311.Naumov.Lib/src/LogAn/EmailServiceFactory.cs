namespace KTPO4311.Naumov.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика почтовых служб
    /// </summary>
    public static class EmailServiceFactory
    {
        private static IEmailService _customService = null;

        /// <summary>
        /// Создание объектов
        /// </summary>
        public static IEmailService Create()
        {
            return _customService ?? new EmailService();
        }

        public static void SetService(IEmailService service)
        {
            _customService = service;
        }
    }
}
