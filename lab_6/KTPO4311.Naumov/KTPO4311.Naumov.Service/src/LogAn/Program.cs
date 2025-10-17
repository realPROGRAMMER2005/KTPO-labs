using KTPO4311.Naumov.Lib.src.LogAn;

namespace KTPO4311.Naumov.Service.src.LogAn
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing LogAnalyzer with real file extension manager");
            Console.WriteLine("=================================================");

            var logAnalyzer = new LogAnalyzer();

            // Тестируем разные расширения
            var testFiles = new[]
            {
            "document.txt",
            "application.log",
            "config.config",
            "image.jpg",
            "video.mp4",
            "script.js"
        };

            foreach (var file in testFiles)
            {
                bool isValid = logAnalyzer.IsValidLogFileName(file);
                string status = isValid ? "VALID" : "INVALID";
                Console.WriteLine($"{file} -> {status}");
            }

            Console.WriteLine("=================================================");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
