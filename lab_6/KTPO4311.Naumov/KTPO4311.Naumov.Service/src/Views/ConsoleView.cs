using KTPO4311.Naumov.Lib.src.LogAn;


namespace KTPO4311.Naumov.Service.src.Views
{
    public class ConsoleView : IView
    {
        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
