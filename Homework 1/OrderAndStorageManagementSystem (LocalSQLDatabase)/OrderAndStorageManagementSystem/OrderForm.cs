using OrderAndStorageManagementSystem.Model;
using OrderAndStorageManagementSystem.View;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem
{
    public partial class OrderForm : Form
    {
        public RichTextBox ProductNameAndDescription
        {
            get
            {
                return _productNameAndDescription;
            }
        }
        public RichTextBox ProductPrice
        {
            get
            {
                return _productPrice;
            }
        }
        public TabControl ProductTabControl
        {
            get
            {
                return _productTabControl;
            }
        }
        public AppModel Model
        {
            get
            {
                return _model;
            }
        }
        private AppModel _model;
        private ProductTabPagesManager _tabPagesManager;
        private Product _currentSelectedProduct;
        public OrderForm(AppModel modelData)
        {
            InitializeComponent(); // [Windows Form App]
            _model = modelData;
            _tabPagesManager = new ProductTabPagesManager(this);
            _tabPagesManager.InitializeTabPages();
            SelectNoProduct();
            ShowCartTotalPrice();
        }

        /// <summary>
        /// Add the product to cart on add button clicked.
        /// </summary>
        private void ClickAddButton(object sender, System.EventArgs events)
        {
            string productName = _currentSelectedProduct.Name;
            ProductTypes productType = _currentSelectedProduct.Type;
            int productPrice = _currentSelectedProduct.Price;
            _cartDataGridView.Rows.Add(productName, _model.ProductTypesTypeToStringMap[ productType ], productPrice.ToString());
            _model.AddTotalPrice(productPrice);
            ShowCartTotalPrice();
        }

        /// <summary>
        /// Show the cart total price.
        /// </summary>
        private void ShowCartTotalPrice()
        {
            _cartTotalPrice.Text = "總金額： " + _model.CartTotalPrice.ToString();
        }

        /// <summary>
        /// Select a product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _currentSelectedProduct = product;
            SetProductInfoText(product.GetProductNameAndDescription(), AppDefinition.PRODUCT_PRICE_TEXT + product.Price.ToString());
            _addButton.Enabled = true;
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        public void SelectNoProduct()
        {
            _currentSelectedProduct = null;
            SetProductInfoText("", "");
            _addButton.Enabled = false;
        }

        /// <summary>
        /// Set product info text, including product name, description and price.
        /// </summary>
        private void SetProductInfoText(string productNameAndDescription, string productPrice)
        {
            _productNameAndDescription.Text = productNameAndDescription;
            _productPrice.Text = productPrice;
            _productPrice.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
