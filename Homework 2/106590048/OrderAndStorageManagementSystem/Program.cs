using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace;
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
            OrderPresentationModel orderPresentationModel = new OrderPresentationModel(orderModel, model);
            CreditCardPaymentForm creditCardPaymentForm = new CreditCardPaymentForm(new CreditCardPaymentPresentationModel(new CreditCardPaymentModel()));
            MainForm mainForm = new MainForm(creditCardPaymentForm, new MainPresentationModel(), orderPresentationModel, orderModel, model);
            Application.Run(mainForm);
        }
    }
}
