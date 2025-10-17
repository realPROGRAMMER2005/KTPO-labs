using KTPO4311.Naumov.Lib.src.LogAn;

namespace KTPO4311.Naumov.Lib.src.SampleCommands
{
    public class ExceptionHandlingDecorator : ISampleCommand
    {
        private readonly ISampleCommand sampleCommand;
        private readonly IView view;

        public ExceptionHandlingDecorator(ISampleCommand sampleCommand, IView view)
        {
            this.sampleCommand = sampleCommand;
            this.view = view;
        }

        public void Execute()
        {
            try
            {
                sampleCommand.Execute();
            }
            catch (Exception ex)
            {
                view.Render($"Исключение перехвачено в {this.GetType().ToString()}: {ex.Message}");
            }
        }
    }
}
