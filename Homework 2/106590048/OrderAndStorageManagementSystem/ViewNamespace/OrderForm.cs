﻿using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.PresentationModelNamespace;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public partial class OrderForm : Form
    {
        private const string TAB_PAGE_LAYOUT_NAME = "_productTabPageLayout";
        private const int TAB_PAGE_LAYOUT_ROW_COUNT = 2;
        private const int TAB_PAGE_LAYOUT_COLUMN_COUNT = 3;
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
        private List<Product> _products;
        private List<Button> _productButtons;

        public OrderForm(PresentationModel presentationModelData, Model modelData)
        {
            InitializeComponent(); // [Automatically generated by Windows Form Designer]
            _presentationModel = presentationModelData;
            _model = modelData;
            _products = _model.Products;
            InitializeProductTabPages();
            _productTabControl.SelectedIndexChanged += new EventHandler(ChangeProductTabPage);
            SelectNoProduct();
            ShowCartTotalPrice();
            RefreshControls();
        }

        /// <summary>
        /// Initialize tab pages.
        /// </summary>
        public void InitializeProductTabPages()
        {
            InitializeProductButtons();
            TabControl.TabPageCollection tabPages = _productTabControl.TabPages;
            for ( int index = 0; index < tabPages.Count; index++ )
            {
                TabPage tabPage = tabPages[ index ];
                tabPage.Controls.Add(Model.CreateTableLayout(TAB_PAGE_LAYOUT_NAME, TAB_PAGE_LAYOUT_ROW_COUNT, TAB_PAGE_LAYOUT_COLUMN_COUNT));
                PopulateProductTabPage(tabPage, AppDefinition.ConvertTabPageIndexToProductType(index));
            }
        }

        /// <summary>
        /// Initialize product tab page buttons. Button index corresponds to products index.
        /// </summary>
        private void InitializeProductButtons()
        {
            _productButtons = new List<Button>();
            for ( int i = 0; i < _products.Count; i++ )
            {
                Product product = _products[ i ];
                Button button = new Button();
                button.Image = DataBaseManager.GetProductImageFromResources(product.Id);
                button.Click += (sender, events) => SelectProduct(product);
                _productButtons.Add(button);
            }
        }

        /// <summary>
        /// Populate tab page with products of corresponding type.
        /// </summary>
        private void PopulateProductTabPage(TabPage tabPage, string tabPageType)
        {
            TableLayoutPanel tabPageLayout = ( TableLayoutPanel )tabPage.Controls[ TAB_PAGE_LAYOUT_NAME ];
            int tabPageItemCount = 0;
            for ( int i = 0; i < _products.Count; i++ )
            {
                if ( _products[ i ].Type == tabPageType )
                {
                    AddItemToTabPage(_productButtons[ i ], tabPageLayout, tabPageItemCount);
                    tabPageItemCount++;
                }
            }
        }

        /// <summary>
        /// Add button into proper table cell.
        /// </summary>
        private void AddItemToTabPage(Button button, TableLayoutPanel tabPageLayout, int tabPageItemIndex)
        {
            int row;
            int column;
            Model.GetArrayEntryRowAndColumn(tabPageItemIndex, TAB_PAGE_LAYOUT_COLUMN_COUNT, out row, out column);
            tabPageLayout.Controls.Add(button, column, row);
            button.Dock = DockStyle.Fill; // Make button fill in table cell
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
            _model.Order.AddTotalPrice(_presentationModel.CurrentSelectedProduct.Price);
            ShowCartTotalPrice();
        }

        /// <summary>
        /// Show the cart total price.
        /// </summary>
        private void ShowCartTotalPrice()
        {
            _cartTotalPrice.Text = "總金額： " + _model.Order.TotalPrice.ToString();
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
