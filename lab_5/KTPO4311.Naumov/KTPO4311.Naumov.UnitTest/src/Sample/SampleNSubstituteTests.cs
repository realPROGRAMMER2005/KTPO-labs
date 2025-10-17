

using KTPO4311.Naumov.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;

namespace KTPO4311.Naumov.UnitTest.src.Sample
{
    public class SampleNSubstituteTests
    {


        [Test]
        public void Returns_ParticularArg_Works()
        {
            // Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            // Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            // Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("validfile.ext");

            // Проверка ожидаемого результата
            Assert.That(result, Is.True);
        }
    

        [Test]
        public void Returns_ArgAny_Works()
        {
            // Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            // Настроить объект, чтобы метод возвращал true независимо от параметров
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            // Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("anyfile.ext");

            // Проверка ожидаемого результата
            Assert.That(result, Is.True);
    }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            // Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            // Настроить объект, чтобы метод вызывал исключение независимо от входных аргументов
            fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>())).Do(context => { throw new Exception("fake exception"); });

            // Проверка, что было выброшено исключение
            Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anything"));
        }

        [Test]
        public void Received_ParticularArg_Saves()
        {
            // Создать поддельный объект
            IWebService mockWebService = Substitute.For<IWebService>();

            // Воздействие на поддельный объект
            mockWebService.LogError("Поддельное сообщение");

            // Проверка, что поддельный объект получил вызов
            mockWebService.Received().LogError("Поддельное сообщение");
        }


    }
}