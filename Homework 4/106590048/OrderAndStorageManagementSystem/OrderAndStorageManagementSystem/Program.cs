﻿using OrderAndStorageManagementSystem.Models;
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
            OrderPresentationModel orderPresentationModel = new OrderPresentationModel(model);
            CreditCardPaymentForm creditCardPaymentForm = new CreditCardPaymentForm(model);
            MainForm mainForm = new MainForm(creditCardPaymentForm, new InventoryPresentationModel(model), new MainPresentationModel(), orderPresentationModel, model);
            Application.Run(mainForm);
        }
    }
}
