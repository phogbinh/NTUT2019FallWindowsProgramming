using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.Views.Utilities;
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
            InitializeInputHandler();
            // Initial UI States
            InitializeProductInfo();
        }

        // Protest on Dr.Smell
        private void InitializeInputHandler()
        {
            _productSupplyQuantityField.KeyPress += InputHelper.InputNumbersOrBackSpace;
        }

        // Protest on Dr.Smell
        private void InitializeProductInfo()
        {
            _productName.Text = PRODUCT_NAME_TEXT + _product.Name;
            _productType.Text = PRODUCT_TYPE_TEXT + _product.Type;
            _productPrice.Text = PRODUCT_PRICE_TEXT + _product.Price.GetStringWithCurrencyUnit(AppDefinition.TAIWAN_CURRENCY_UNIT);
            _productStorageQuantity.Text = PRODUCT_STORAGE_QUANTITY_TEXT + _product.StorageQuantity;
        }
    }
}
