using KTPO4311.Naumov.Lib.src.LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Naumov.Lib.src.SampleCommands
{
    public class FirstCommand : ISampleCommand
    {
        private readonly IView view;
        private int iExecute = 0;

        public FirstCommand(IView view) 
        {
            this.view = view;
        }
        public void Execute()
        {
            this.iExecute++;
            view.Render(this.GetType().ToString() + "\n iExecute = " + iExecute);

        }
    }
}
