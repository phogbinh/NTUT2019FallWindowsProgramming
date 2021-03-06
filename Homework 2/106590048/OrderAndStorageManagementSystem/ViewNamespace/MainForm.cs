﻿using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.PresentationModelNamespace;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public partial class MainForm : Form
    {
        private CreditCardPaymentForm _creditCardPaymentForm;
        private MainPresentationModel _mainPresentationModel;
        private OrderPresentationModel _orderPresentationModel;
        private OrderModel _orderModel;
        private Model _model;

        public MainForm(CreditCardPaymentForm creditCardPaymentFormData, MainPresentationModel mainPresentationModelData, OrderPresentationModel orderPresentationModelData, OrderModel orderModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentForm = creditCardPaymentFormData;
            _mainPresentationModel = mainPresentationModelData;
            _orderPresentationModel = orderPresentationModelData;
            _orderModel = orderModelData;
            _model = modelData;
            _orderSystemButton.Click += ClickOrderSystemButton;
            _inventorySystemButton.Click += ClickInventorySystemButton;
            _exitButton.Click += ClickExitButton;
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void ClickOrderSystemButton(object sender, System.EventArgs events)
        {
            OrderForm orderForm;
            orderForm = new OrderForm(_creditCardPaymentForm, _orderPresentationModel, _orderModel, _model);
            orderForm.FormClosed += CloseOrderForm;
            orderForm.Show();
            _mainPresentationModel.ClickOrderSystemButton();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void CloseOrderForm(object sender, System.EventArgs events)
        {
            _mainPresentationModel.CloseOrderForm();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void ClickInventorySystemButton(object sender, System.EventArgs events)
        {
            InventoryForm inventoryForm;
            inventoryForm = new InventoryForm();
            inventoryForm.FormClosed += CloseInventoryForm;
            inventoryForm.Show();
            _mainPresentationModel.ClickInventorySystemButton();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void CloseInventoryForm(object sender, System.EventArgs events)
        {
            _mainPresentationModel.CloseInventoryForm();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void ClickExitButton(object sender, System.EventArgs events)
        {
            Application.Exit();
        }

        // Protest on Dr.Smell
        private void RefreshControls()
        {
            _orderSystemButton.Enabled = _mainPresentationModel.OrderSystemButton.Enabled;
            _inventorySystemButton.Enabled = _mainPresentationModel.InventorySystemButton.Enabled;
        }
    }
}
