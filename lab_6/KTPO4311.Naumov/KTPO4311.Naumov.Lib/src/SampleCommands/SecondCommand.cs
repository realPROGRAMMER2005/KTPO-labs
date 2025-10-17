using KTPO4311.Naumov.Lib.src.LogAn;


namespace KTPO4311.Naumov.Lib.src.SampleCommands
{
    public class SecondCommand : ISampleCommand
    {
        private readonly IView view;
        private int iExecute = 0;

        public SecondCommand(IView view) 
        {
            this.view = view;
        }
        public void Execute()
        {
            this.iExecute++;
            view.Render(this.GetType().ToString() + "\n iExecute = " + iExecute);

            // Генерируем исключение для тестирования декоратора перехвата исключений
            throw new Exception("Тестовое исключение из SecondCommand");
        }
    }
}
