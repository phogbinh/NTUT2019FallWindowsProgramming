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
            Model model = new Model();
            OrderModel orderModel = new OrderModel(model.Products);
            MainForm mainForm = new MainForm(new MainPresentationModel(), new OrderPresentationModel(orderModel), orderModel, model);
            Application.Run(mainForm);
        }
    }
}
