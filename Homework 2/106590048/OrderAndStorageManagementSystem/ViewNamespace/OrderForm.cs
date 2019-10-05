﻿using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.PresentationModelNamespace;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public partial class OrderForm : Form
    {
        public PresentationModel PresentationModel
        {
            get
            {
                return _presentationModel;
            }
        }
        public Model Model
        {
            get
            {
                return _model;
            }
        }
        private PresentationModel _presentationModel;
        private Model _model;
        private ProductTabPagesManager _tabPagesManager;

        public OrderForm(PresentationModel presentationModelData, Model modelData)
        {
            InitializeComponent(); // [Automatically generated by Windows Form Designer]
            _presentationModel = presentationModelData;
            _model = modelData;
            _productTabControl.SelectedIndexChanged += new EventHandler(ChangeProductTabPage);
            _tabPagesManager = new ProductTabPagesManager(this, _productTabControl.TabPages);
            _tabPagesManager.InitializeTabPages();
            SelectNoProduct();
            ShowCartTotalPrice();
        }

        /// <summary>
        /// Change tab page event handler.
        /// </summary>
        private void ChangeProductTabPage(object sender, EventArgs events)
        {
            SelectNoProduct();
        }

        /// <summary>
        /// Add the product to cart on add button clicked.
        /// </summary>
        private void ClickAddButton(object sender, System.EventArgs events)
        {
            string productName = _presentationModel.CurrentSelectedProduct.Name;
            string productType = _presentationModel.CurrentSelectedProduct.Type;
            string productPrice = _presentationModel.CurrentSelectedProduct.Price.ToString();
            _cartDataGridView.Rows.Add(productName, productType, productPrice);
            _model.AddTotalPrice(_presentationModel.CurrentSelectedProduct.Price);
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
            _presentationModel.SelectProduct(product);
            RefreshControls();
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        public void SelectNoProduct()
        {
            _presentationModel.SelectNoProduct();
            RefreshControls();
        }

        /// <summary>
        /// Referesh controls.
        /// </summary>
        public void RefreshControls()
        {
            _productNameAndDescription.Text = _presentationModel.ProductNameAndDescription.Text;
            _productPrice.Text = _presentationModel.ProductPrice.Text;
            _addButton.Enabled = _presentationModel.AddButton.Enabled;
        }
    }
}
