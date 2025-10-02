using Microsoft.Extensions.Configuration;

namespace KTPO4311.Naumov.Lib.src.LogAn
{
    public class FileExtensionManager : IExtensionManager
    {
        private readonly string[] _allowedExtensions;

        public FileExtensionManager()
        {
            try
            {
                // Используйте BaseDirectory вместо CurrentDirectory
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

                _allowedExtensions = configuration.GetSection("AllowedExtensions").Get<string[]>();
                if (_allowedExtensions == null || _allowedExtensions.Length == 0)
                {
                    _allowedExtensions = new[] { ".txt", ".log", ".config" };
                }
            }
            catch (Exception)
            {
                _allowedExtensions = new[] { ".txt", ".log", ".config" };
            }
        }

        /// <summary>
        /// Проверка правильности расширения
        /// </summary>
        public bool IsValid(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;

            var extension = Path.GetExtension(fileName);
            return Array.Exists(_allowedExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }
    }
}