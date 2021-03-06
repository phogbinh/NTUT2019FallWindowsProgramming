﻿using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.PresentationModels;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class MainForm : Form
    {
        private CreditCardPaymentForm _creditCardPaymentForm;
        private InventoryPresentationModel _inventoryPresentationModel;
        private MainPresentationModel _mainPresentationModel;
        private OrderPresentationModel _orderPresentationModel;
        private OrderModel _orderModel;
        private Model _model;

        public MainForm(CreditCardPaymentForm creditCardPaymentFormData, InventoryPresentationModel inventoryPresentationModelData, MainPresentationModel mainPresentationModelData, OrderPresentationModel orderPresentationModelData, OrderModel orderModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentForm = creditCardPaymentFormData;
            _inventoryPresentationModel = inventoryPresentationModelData;
            _mainPresentationModel = mainPresentationModelData;
            _orderPresentationModel = orderPresentationModelData;
            _orderModel = orderModelData;
            _model = modelData;
            _orderSystemButton.Click += ClickOrderSystemButton;
            _inventorySystemButton.Click += ClickInventorySystemButton;
            _exitButton.Click += ClickExitButton;
            RefreshControls();
        }

        /// <summary>
        /// Click order system button.
        /// </summary>
        private void ClickOrderSystemButton(object sender, System.EventArgs events)
        {
            OrderForm orderForm;
            orderForm = new OrderForm(_creditCardPaymentForm, _orderPresentationModel, _orderModel, _model);
            orderForm.FormClosed += CloseOrderForm;
            orderForm.Show();
            _mainPresentationModel.ClickOrderSystemButton();
            RefreshControls();
        }

        /// <summary>
        /// Close order form.
        /// </summary>
        private void CloseOrderForm(object sender, System.EventArgs events)
        {
            _mainPresentationModel.CloseOrderForm();
            RefreshControls();
        }

        /// <summary>
        /// Click inventory system button.
        /// </summary>
        private void ClickInventorySystemButton(object sender, System.EventArgs events)
        {
            InventoryForm inventoryForm;
            inventoryForm = new InventoryForm(_inventoryPresentationModel, _model);
            inventoryForm.FormClosed += CloseInventoryForm;
            inventoryForm.Show();
            _mainPresentationModel.ClickInventorySystemButton();
            RefreshControls();
        }

        /// <summary>
        /// Close inventory form.
        /// </summary>
        private void CloseInventoryForm(object sender, System.EventArgs events)
        {
            _mainPresentationModel.CloseInventoryForm();
            RefreshControls();
        }

        /// <summary>
        /// Click exit button.
        /// </summary>
        private void ClickExitButton(object sender, System.EventArgs events)
        {
            Application.Exit();
        }

        /// <summary>
        /// Refresh controls.
        /// </summary>
        private void RefreshControls()
        {
            _orderSystemButton.Enabled = _mainPresentationModel.OrderSystemButton.Enabled;
            _inventorySystemButton.Enabled = _mainPresentationModel.InventorySystemButton.Enabled;
        }
    }
}
