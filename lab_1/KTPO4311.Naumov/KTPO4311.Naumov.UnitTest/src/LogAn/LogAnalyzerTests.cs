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
        public void IsValidFileName_BadExtension_ReturnsFalse()


        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.That(result, Is.False);
        }


        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new();
            bool result = analyzer.IsValidLogFileName("file.NAUMOVDO");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new();
            bool result = analyzer.IsValidLogFileName("file.naumovdo");
            Assert.That(result, Is.True);
        }


        [TestCase("file.NAUMOVDO")]
        [TestCase("file.naumovdo")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string fileName)
        {
            LogAnalyzer analyzer = new();
            bool result = analyzer.IsValidLogFileName(fileName);
            Assert.That(result, Is.True);
        }


        [Test]
        public void IsValidLogFileName_emptyFileName_Throws()
        {
            LogAnalyzer analyzer = new();

            var ex = Assert.Catch<ArgumentException>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("Имя файла не может быть пустым", ex.Message);
        }

        [TestCase("file.NaumovDO", true)]
        [TestCase("file.txt", false)]
        public void IsValidLogFileName_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer analyzer = new();
            analyzer.IsValidLogFileName(fileName);

            Assert.That(analyzer.WasLastFileNameValid, Is.EqualTo(expected));
        }




    }


}
