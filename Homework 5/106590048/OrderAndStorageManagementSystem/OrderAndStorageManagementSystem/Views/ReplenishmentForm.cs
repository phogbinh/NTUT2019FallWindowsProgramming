using InputInspectingElements;
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
            _submitButton.Click += ClickSubmitButton;
            _cancelButton.Click += (sender, eventArguments) => this.Close();
            _productSupplyQuantityField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _productSupplyQuantityField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _productSupplyQuantityField.TextBoxInspectorsCollectionChanged += () => UpdateErrorProviderAndSubmitButtonView(_productSupplyQuantityField, _productSupplyQuantityField.GetInputInspectorsError());
            // Initial UI States
            InitializeProductInfoView();
            UpdateSubmitButtonView();
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
        /// Update the view of the error provider and the submit button.
        /// </summary>
        private void UpdateErrorProviderAndSubmitButtonView(Control control, string controlInputInspectorsError)
        {
            _errorProvider.SetError(control, controlInputInspectorsError);
            UpdateSubmitButtonView();
        }

        /// <summary>
        /// Update the enabled state of the submit button.
        /// </summary>
        private void UpdateSubmitButtonView()
        {
            _submitButton.Enabled = _productSupplyQuantityField.IsValid();
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
    }
}
