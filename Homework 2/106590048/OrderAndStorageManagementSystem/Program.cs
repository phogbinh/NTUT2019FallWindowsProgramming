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
            PresentationModel presentationModel = new PresentationModel();
            Model model = new Model();
            MainForm mainForm = new MainForm();
            OrderForm orderForm = new OrderForm(presentationModel, model);
            Application.Run(mainForm);
        }
    }
}
