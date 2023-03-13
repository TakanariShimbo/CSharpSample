using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;
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

            var system = new SampleSystem();
            var viewModel = new ViewModel(system);
            var uiManager = new UserInterface(viewModel);

            return;
        }
    }
}
