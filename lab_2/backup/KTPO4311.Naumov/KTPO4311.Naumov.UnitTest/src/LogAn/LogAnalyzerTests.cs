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

            LogAnalyzer log = new LogAnalyzer(fakeManager);

            // Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.ext");

            // Проверка ожидаемого результата
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            var fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;

            var logAnalyzer = new LogAnalyzer(fakeManager);

            bool result = logAnalyzer.IsValidLogFileName("test.bad");

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            // Подготовка теста
            var fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception("Fake exception");

            var logAnalyzer = new LogAnalyzer(fakeManager);

            // Воздействие на тестируемый объект
            bool result = logAnalyzer.IsValidLogFileName("anyfile.any");

            // Проверка ожидаемого результата - должно быть FALSE
            Assert.That(result, Is.False);
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
