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

        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
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




}
