using NUnit.Framework;
using KTPO4311.Naumov.Lib.src.LogAn;
using NUnit.Framework.Legacy;
using System;

namespace KTPO4311.Naumov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {


        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            // Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            // Воздействие на тестируемый объект
            bool result = logAnalyzer.IsValidLogFileName("test.ext");

            // Проверка ожидаемого результата
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            // Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            // Воздействие на тестируемый объект
            bool result = logAnalyzer.IsValidLogFileName("test.bad");

            // Проверка ожидаемого результата
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            // Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception("Test exception");

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            // Воздействие на тестируемый объект
            bool result = logAnalyzer.IsValidLogFileName("test.txt");

            // Проверка ожидаемого результата
            Assert.That(result, Is.False);
        }

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            // Подготовка теста веб-сервиса
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            // Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            // Проверка ожидаемого результата
            Assert.That(mockWebService.lastError, Does.Contain("Слишком короткое имя файла: abc.ext"));
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            // Подготовка теста
            FakeWebService stubWebService = new FakeWebService();
            stubWebService.WillThrow = new Exception("Web service exception");
            WebServiceFactory.SetService(stubWebService);

            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.SetService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.ext";

            // Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            // Проверка ожидаемого результата
            // Здесь будет несколько утверждений
            // поэтому здесь допустимо несколько утверждений
            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("Web service exception", mockEmail.Body);
            StringAssert.Contains("Невозможно вызвать веб-сервис", mockEmail.Subject);
        }

        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetService(null);
            EmailServiceFactory.SetService(null);
        }


    }

    /// <summary>Поддельный менеджер расширений</summary>
    internal class FakeExtensionManager : IExtensionManager
    {
        /// <summary>Это поле позволяет настроить
        /// поддельный результат для метода IsValid</summary>
        public bool WillBeValid = false;

        /// <summary>
        /// Это поле позволяет настроить поддельное исключение
        /// вызываемое в методе IsValid
        /// </summary>
        public Exception WillThrow = null;

        
        public bool IsValid(string fileName)
        {
            if (WillThrow != null) { 
                throw WillThrow;
            }
            return WillBeValid;
        }


        
    }

    /// <summary>Поддельный веб-сервис</summary>
    internal class FakeWebService : IWebService
    {
        public string lastError;
        public Exception WillThrow = null;

        public void LogError(string message)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            lastError = message;
        }
    }

    /// <summary>Поддельный почтовый сервис</summary>
    internal class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;

        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }




}
