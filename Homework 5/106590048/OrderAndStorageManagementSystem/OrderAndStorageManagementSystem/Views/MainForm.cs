using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.PresentationModels;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class MainForm : Form
    {
        private CreditCardPaymentForm _creditCardPaymentForm;
        private OrderPresentationModel _orderPresentationModel;
        private ProductManagementPresentationModel _productManagementPresentationModel;
        private ProductTypesManagementTabPagePresentationModel _productTypesManagementTabPagePresentationModel;
        private Model _model;

        public MainForm(CreditCardPaymentForm creditCardPaymentFormData, OrderPresentationModel orderPresentationModelData, ProductManagementPresentationModel productManagementPresentationModelData, ProductTypesManagementTabPagePresentationModel productTypesManagementTabPagePresentationModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentForm = creditCardPaymentFormData;
            _orderPresentationModel = orderPresentationModelData;
            _productManagementPresentationModel = productManagementPresentationModelData;
            _productTypesManagementTabPagePresentationModel = productTypesManagementTabPagePresentationModelData;
            _model = modelData;
            _orderSystemButton.Click += ClickOrderSystemButton;
            _inventorySystemButton.Click += ClickInventorySystemButton;
            _productManageSystemButton.Click += ClickProductManageSystemButton;
            _exitButton.Click += ClickExitButton;
        }

        /// <summary>
        /// Click order system button.
        /// </summary>
        private void ClickOrderSystemButton(object sender, System.EventArgs eventArguments)
        {
            OrderForm orderForm;
            orderForm = new OrderForm(_creditCardPaymentForm, _orderPresentationModel, _model);
            orderForm.FormClosed += (formClosedSender, formClosedEventArguments) => _orderSystemButton.Enabled = true;
            orderForm.Show();
            _orderSystemButton.Enabled = false;
        }

        /// <summary>
        /// Click inventory system button.
        /// </summary>
        private void ClickInventorySystemButton(object sender, System.EventArgs eventArguments)
        {
            InventoryForm inventoryForm;
            inventoryForm = new InventoryForm(_model);
            inventoryForm.FormClosed += (formClosedSender, formClosedEventArguments) => _inventorySystemButton.Enabled = true;
            inventoryForm.Show();
            _inventorySystemButton.Enabled = false;
        }

        /// <summary>
        /// Click product manage system button.
        /// </summary>
        private void ClickProductManageSystemButton(object sender, System.EventArgs eventArguments)
        {
            ProductManagementForm productManagementForm;
            productManagementForm = new ProductManagementForm(_productManagementPresentationModel, _productTypesManagementTabPagePresentationModel, _model);
            productManagementForm.FormClosed += (formClosedSender, formClosedEventArguments) => _productManageSystemButton.Enabled = true;
            productManagementForm.Show();
            _productManageSystemButton.Enabled = false;
        }

        /// <summary>
        /// Click exit button.
        /// </summary>
        private void ClickExitButton(object sender, System.EventArgs eventArguments)
        {
            Application.Exit();
        }
    }
}
