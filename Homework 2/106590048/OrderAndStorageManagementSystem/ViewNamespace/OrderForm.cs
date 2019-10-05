﻿using OrderAndStorageManagementSystem.ModelNamespace;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public partial class OrderForm : Form
    {
        public Model Model
        {
            get
            {
                return _model;
            }
        }
        private Model _model;
        private ProductTabControlManager _tabControlManager;
        private Product _currentSelectedProduct;

        public OrderForm(Model modelData)
        {
            InitializeComponent(); // [Automatically generated by Windows Form Designer]
            _model = modelData;
            _tabControlManager = new ProductTabControlManager(this, _productTabControl);
            _tabControlManager.InitializeTabControl();
            SelectNoProduct();
            ShowCartTotalPrice();
        }

        /// <summary>
        /// Add the product to cart on add button clicked.
        /// </summary>
        private void ClickAddButton(object sender, System.EventArgs events)
        {
            string productName = _currentSelectedProduct.Name;
            string productType = _currentSelectedProduct.Type;
            string productPrice = _currentSelectedProduct.Price.ToString();
            _cartDataGridView.Rows.Add(productName, productType, productPrice);
            _model.AddTotalPrice(_currentSelectedProduct.Price);
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
