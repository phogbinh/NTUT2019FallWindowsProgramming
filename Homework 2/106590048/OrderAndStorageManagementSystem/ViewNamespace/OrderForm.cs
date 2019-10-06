﻿using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.PresentationModelNamespace;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public partial class OrderForm : Form
    {
        private const string TAB_PAGE_LAYOUT_NAME = "_productTabPageLayout";
        private OrderPresentationModel _orderPresentationModel;
        private OrderModel _orderModel;
        private Model _model;
        private List<Product> _products;
        private List<List<OrderProductTabPageItem>> _productTabPageItemsContainers;

        public OrderForm(OrderPresentationModel orderPresentationModelData, OrderModel orderModelData, Model modelData)
        {
            InitializeComponent(); // [Automatically generated by Windows Form Designer]
            _orderPresentationModel = orderPresentationModelData;
            _orderModel = orderModelData;
            _model = modelData;
            _products = _model.Products;
            InitializeProductTabPageItemsContainers();
            // UI
            _addButton.Click += ClickAddButton;
            _productTabControl.SelectedIndexChanged += (sender, events) => SelectProductTabPage(_productTabControl.SelectedIndex);
            _productTabControl.SelectedIndexChanged += (sender, events) => ResetCurrentProductPageIndex();
            _productTabControl.SelectedIndexChanged += (sender, events) => SelectNoProduct();
            InitializeProductTabPages();
            // Initial UI States
            SelectProductTabPage(AppDefinition.MOTHER_BOARD_INDEX);
            ResetCurrentProductPageIndex();
            SelectNoProduct();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void InitializeProductTabPageItemsContainers()
        {
            _productTabPageItemsContainers = new List<List<OrderProductTabPageItem>>();
            for ( int i = 0; i < AppDefinition.TAB_PAGES_COUNT; i++ )
            {
                _productTabPageItemsContainers.Add(CreateProductTabPageItems());
            }
        }

        // Protest on Dr.Smell
        private List<OrderProductTabPageItem> CreateProductTabPageItems()
        {
            var productTabPageItems = new List<OrderProductTabPageItem>();
            for ( int i = 0; i < AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT; i++ )
            {
                OrderProductTabPageItem item = new OrderProductTabPageItem(this, new Button());
                productTabPageItems.Add(item);
            }
            return productTabPageItems;
        }

        /// <summary>
        /// Add the product to cart on add button clicked.
        /// </summary>
        private void ClickAddButton(object sender, System.EventArgs events)
        {
            string productName = _orderPresentationModel.CurrentSelectedProduct.Name;
            string productType = _orderPresentationModel.CurrentSelectedProduct.Type;
            string productPrice = _orderPresentationModel.CurrentSelectedProduct.Price.ToString();
            _cartDataGridView.Rows.Add(productName, productType, productPrice);
            _orderPresentationModel.AddCurrentSelectedProductToOrder();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void SelectProductTabPage(int tabPageIndex)
        {
            _orderPresentationModel.SelectProductTabPage(tabPageIndex);
            RefreshControls();
        }

        /// <summary>
        /// Initialize tab pages.
        /// </summary>
        public void InitializeProductTabPages()
        {
            TabControl.TabPageCollection tabPages = _productTabControl.TabPages;
            for ( int i = 0; i < AppDefinition.TAB_PAGES_COUNT; i++ )
            {
                TabPage tabPage = tabPages[ i ];
                tabPage.Controls.Add(Model.CreateTableLayout(TAB_PAGE_LAYOUT_NAME, AppDefinition.TAB_PAGE_LAYOUT_ROW_COUNT, AppDefinition.TAB_PAGE_LAYOUT_COLUMN_COUNT));
                PopulateProductTabPageItems(( TableLayoutPanel )tabPage.Controls[ TAB_PAGE_LAYOUT_NAME ], i);
            }
        }

        // Protest on Dr.Smell
        private void PopulateProductTabPageItems(TableLayoutPanel tabPageLayout, int tabPageIndex)
        {
            int productTabPageItemsCount = 0;
            for ( int row = 0; row < AppDefinition.TAB_PAGE_LAYOUT_ROW_COUNT; row++ )
            {
                for ( int column = 0; column < AppDefinition.TAB_PAGE_LAYOUT_COLUMN_COUNT; column++ )
                {
                    OrderProductTabPageItem item = _productTabPageItemsContainers[ tabPageIndex ][ productTabPageItemsCount ];
                    tabPageLayout.Controls.Add(item.Button, column, row);
                    item.Button.Dock = DockStyle.Fill; // Make button fill in table cell
                    productTabPageItemsCount++;
                }
            }
        }

        // Protest on Dr.Smell
        private void ResetCurrentProductPageIndex()
        {
            _orderPresentationModel.ResetCurrentProductPageIndex();
            RefreshProductTabPage(_productTabControl.SelectedIndex);
        }

        // Protest on Dr.Smell
        private void RefreshProductTabPage(int tabPageIndex)
        {
            List<OrderProductTabPageItem> productTabPageItems = _productTabPageItemsContainers[ tabPageIndex ];
            for ( int i = 0; i < AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT; i++ )
            {
                productTabPageItems[ i ].Product = _orderPresentationModel.GetProduct(tabPageIndex, i);
            }
        }

        /// <summary>
        /// Select a product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _orderPresentationModel.SelectProduct(product);
            RefreshControls();
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        public void SelectNoProduct()
        {
            _orderPresentationModel.SelectNoProduct();
            RefreshControls();
        }

        /// <summary>
        /// Referesh controls.
        /// </summary>
        public void RefreshControls()
        {
            _productNameAndDescription.Text = _orderPresentationModel.ProductNameAndDescription.Text;
            _productPrice.Text = _orderPresentationModel.ProductPrice.Text;
            _addButton.Enabled = _orderPresentationModel.AddButton.Enabled;
            _cartTotalPrice.Text = _orderPresentationModel.CartTotalPrice.Text;
            _pageLabel.Text = _orderPresentationModel.PageLabel.Text;
        }
    }
}
