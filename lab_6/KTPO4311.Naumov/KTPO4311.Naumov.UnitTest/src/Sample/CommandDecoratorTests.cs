using KTPO4311.Naumov.Lib.src.LogAn;
using KTPO4311.Naumov.Lib.src.SampleCommands;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KTPO4311.Naumov.UnitTest.src.Sample
{
    [TestFixture]
    public class CommandDecoratorTests
    {
        [Test]
        public void FirstCommand_Execute_CallsViewRender()
        {
            // Подготовка
            IView mockView = Substitute.For<IView>();
            FirstCommand firstCommand = new FirstCommand(mockView);

            // Действие
            firstCommand.Execute();

            // Проверка
            mockView.Received().Render(Arg.Is<string>
                (s => s.Contains("KTPO4311.Naumov.Lib.src.SampleCommands.FirstCommand") 
                && s.Contains("iExecute = 1")));
        }

        [Test]
        public void SampleCommandDecorator_Execute_CallsDecoratedCommand()
        {
            // Подготовка
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockCommand = Substitute.For<ISampleCommand>();
            SampleCommandDecorator decorator = 
                new SampleCommandDecorator(mockCommand, mockView);

            // Действие
            decorator.Execute();

            // Проверка
            mockCommand.Received().Execute();
        }

        [Test]
        public void SampleCommandDecorator_Execute_RendersStartAndEndText()
        {
            // Подготовка
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockCommand = Substitute.For<ISampleCommand>();
            SampleCommandDecorator decorator = 
                new SampleCommandDecorator(mockCommand, mockView);

            // Действие
            decorator.Execute();

            // Проверка
            mockView.Received().Render
                ("Начало: KTPO4311.Naumov.Lib.src.SampleCommands.SampleCommandDecorator");
            mockView.Received().Render
                ("Конец: KTPO4311.Naumov.Lib.src.SampleCommands.SampleCommandDecorator");
        }

        [Test]
        public void ExceptionHandlingDecorator_Execute_CallsDecoratedCommand()
        {
            // Подготовка
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockCommand = Substitute.For<ISampleCommand>();
            ExceptionHandlingDecorator decorator = 
                new ExceptionHandlingDecorator(mockCommand, mockView);

            // Действие
            decorator.Execute();

            // Проверка
            mockCommand.Received().Execute();
        }

        [Test]
        public void ExceptionHandlingDecorator_Execute_HandlesExceptionsFromDecoratedCommand()
        {
            // Подготовка
            IView mockView = Substitute.For<IView>();
            ISampleCommand mockCommand = Substitute.For<ISampleCommand>();
            mockCommand.When(x => x.Execute()).
                Do(x => { throw new Exception("Test exception"); });

            ExceptionHandlingDecorator decorator = 
                new ExceptionHandlingDecorator(mockCommand, mockView);

            // Действие
            decorator.Execute();

            // Проверка
            mockView.
                Received().
                Render(Arg.Is<string>(s =>
                s.Contains
                ("Исключение перехвачено в KTPO4311.Naumov.Lib.src.SampleCommands.ExceptionHandlingDecorator") &&
                s.Contains
                ("Test exception")));
        }
    }
}
