using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomainDrivenDesign.UserInterface
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dispatcher = new Dispatcher();

            var systemStateInitial = new SystemStateInitial();
            var system = new SampleSystem(systemStateInitial, dispatcher);

            var uiManager = new UserInterface(dispatcher);

            Application.Run(uiManager);
        }
    }
}
