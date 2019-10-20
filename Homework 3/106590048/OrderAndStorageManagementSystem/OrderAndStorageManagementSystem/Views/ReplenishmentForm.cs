using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class ReplenishmentForm : Form
    {
        private const string PRODUCT_NAME_TEXT = "商品名稱： ";
        private const string PRODUCT_TYPE_TEXT = "商品類別： ";
        private const string PRODUCT_PRICE_TEXT = "商品單價： ";
        private const string PRODUCT_STORAGE_QUANTITY_TEXT = "庫存數量： ";
        private Model _model;
        private Product _product;

        public ReplenishmentForm(Model modelData, Product productData)
        {
            InitializeComponent();
            _model = modelData;
            _product = productData;
            // UI
            _productSupplyQuantityField.TextChanged += (sender, eventArguments) => RefreshControls();
            _productSupplyQuantityField.Leave += (sender, eventArguments) => RefreshControls();
            _submitButton.Click += ClickSubmitButton;
            _cancelButton.Click += (sender, eventArguments) => this.Close();
            InitializeInputLimit();
            // Initial UI States
            InitializeProductInfoView();
            RefreshControls();
        }

        /// <summary>
        /// Click submit button.
        /// </summary>
        private void ClickSubmitButton(object sender, EventArgs eventArguments)
        {
            this.Close();
            _model.SupplyProductStorageQuantity(_product, int.Parse(_productSupplyQuantityField.Text));
        }

        /// <summary>
        /// Initialize input limit.
        /// </summary>
        private void InitializeInputLimit()
        {
            _productSupplyQuantityField.KeyPress += InputHelper.InputNumbersOrBackSpace;
        }

        /// <summary>
        /// Initialize product info view.
        /// </summary>
        private void InitializeProductInfoView()
        {
            _productName.Text = PRODUCT_NAME_TEXT + _product.Name;
            _productType.Text = PRODUCT_TYPE_TEXT + _product.Type;
            _productPrice.Text = PRODUCT_PRICE_TEXT + _product.Price.GetCurrencyFormatWithCurrencyUnit(AppDefinition.TAIWAN_CURRENCY_UNIT);
            _productStorageQuantity.Text = PRODUCT_STORAGE_QUANTITY_TEXT + _product.StorageQuantity;
        }

        /// <summary>
        /// Refresh controls.
        /// </summary>
        private void RefreshControls()
        {
            _submitButton.Enabled = _productSupplyQuantityField.Text != "";
        }
    }
}
