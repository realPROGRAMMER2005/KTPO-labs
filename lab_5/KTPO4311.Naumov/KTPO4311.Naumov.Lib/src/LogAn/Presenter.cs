namespace KTPO4311.Naumov.Lib.src.LogAn
{
    public class Presenter

    {

        public LogAnalyzer logAnalyzer;
        public IView view;

        public Presenter(LogAnalyzer logAnalyzer, IView view)
        {
            this.logAnalyzer = logAnalyzer;
            this.view = view;
            this.logAnalyzer.Analyzed += OnLogAnalyzed;
        }

        private void OnLogAnalyzed()
        {
            this.view.Render("Обработка завершена");
        }
    }
}
