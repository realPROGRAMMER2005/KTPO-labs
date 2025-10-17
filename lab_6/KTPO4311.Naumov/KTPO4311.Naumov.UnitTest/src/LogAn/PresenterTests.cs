using KTPO4311.Naumov.Lib.src.LogAn;
using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Naumov.UnitTest.src.LogAn
{
    [TestFixture]
    public class PresenterTests

    {

        public event LogAnalyzerAction Analyzed = null;


        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender()
        {
            // 1. Подготовка теста (Arrange)
            FakeLogAnalyzer fakeLogAnalyzer = new FakeLogAnalyzer();
            IView mockView = Substitute.For<IView>();
            Presenter presenter = new Presenter(fakeLogAnalyzer, mockView);

            // 2. Воздействие на тестируемый объект (Act)
            fakeLogAnalyzer.CallRaiseAnalyzedEvent();

            // 3. Проверка ожидаемого результата (Assert)
            mockView.Received().Render("Обработка завершена");
        }

        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
        {
            // 1. Подготовка теста (Arrange)
            ILogAnalyzer stubLogAnalyzer = Substitute.For<ILogAnalyzer>();
            IView mockView = Substitute.For<IView>();
            Presenter presenter = new Presenter(stubLogAnalyzer, mockView);

            // 2. Воздействие на тестируемый объект (Act)
            
            stubLogAnalyzer.Analyzed += Raise.Event<LogAnalyzerAction>();

            // 3. Проверка ожидаемого результата (Assert)
            mockView.Received().Render("Обработка завершена");
        }

    }

    class FakeLogAnalyzer: LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();
        }
    }


}
