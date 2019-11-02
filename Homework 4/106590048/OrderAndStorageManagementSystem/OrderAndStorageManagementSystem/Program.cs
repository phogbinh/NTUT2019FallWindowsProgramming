using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.PresentationModels;
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
            Model model = new Model();
            OrderModel orderModel = new OrderModel(model.Products);
            OrderPresentationModel orderPresentationModel = new OrderPresentationModel(orderModel, model);
            CreditCardPaymentModel creditCardPaymentModel = new CreditCardPaymentModel();
            CreditCardPaymentForm creditCardPaymentForm = new CreditCardPaymentForm(new CreditCardPaymentPresentationModel(creditCardPaymentModel), creditCardPaymentModel, model);
            MainForm mainForm = new MainForm(creditCardPaymentForm, new InventoryPresentationModel(model), new MainPresentationModel(), orderPresentationModel, orderModel, model);
            Application.Run(mainForm);
        }
    }
}
