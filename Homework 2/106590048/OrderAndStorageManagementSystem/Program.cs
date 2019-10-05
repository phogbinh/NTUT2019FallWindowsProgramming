using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.PresentationModelNamespace;
using OrderAndStorageManagementSystem.ViewNamespace;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm(new MainPresentationModel(), new OrderPresentationModel(), new Model());
            Application.Run(mainForm);
        }
    }
}
