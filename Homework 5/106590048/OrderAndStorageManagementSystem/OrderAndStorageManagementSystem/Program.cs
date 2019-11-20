using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Properties;
using OrderAndStorageManagementSystem.Views;
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
            Model model = new Model(Resources.ProductsTable);
            OrderPresentationModel orderPresentationModel = new OrderPresentationModel(model);
            CreditCardPaymentForm creditCardPaymentForm = new CreditCardPaymentForm(model);
            MainForm mainForm = new MainForm(creditCardPaymentForm, orderPresentationModel, new ProductManagementPresentationModel(model), model);
            Application.Run(mainForm);
        }
    }
}
