﻿using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class OrderForm : Form
    {
        private const string TAB_PAGE_LAYOUT_NAME = "_productTabPageLayout";
        private const string ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_MESSAGE = "庫存不足";
        private const string ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_TITLE = "庫存狀態";
        private const int CART_PRODUCT_QUANTITY_COLUMN_INDEX = 4;
        private const int CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX = 5;
        private CreditCardPaymentForm _creditCardPaymentForm;
        private OrderPresentationModel _orderPresentationModel;
        private OrderModel _orderModel;
        private Model _model;
        private List<List<OrderProductTabPageButton>> _productTabPageButtonsContainers;

        public OrderForm(CreditCardPaymentForm creditCardPaymentFormData, OrderPresentationModel orderPresentationModelData, OrderModel orderModelData, Model modelData)
        {
            InitializeComponent(); // [Automatically generated by Windows Form Designer]
            _creditCardPaymentForm = creditCardPaymentFormData;
            _orderPresentationModel = orderPresentationModelData;
            _orderModel = orderModelData;
            _model = modelData;
            InitializeProductTabPageButtonsContainers();
            // Observers
            _model.OrderChanged += UpdateCartSectionView;
            _model.OrderCleared += () => _cartDataGridView.Rows.Clear();
            _model.OrderAdded += (orderItem) => _cartDataGridView.Rows.Add(null, orderItem.Name, orderItem.Type, orderItem.Price.GetCurrencyFormat(), orderItem.OrderQuantity, orderItem.GetTotalPrice().GetCurrencyFormat());
            _model.OrderRemoved += (productIndex) => _cartDataGridView.Rows.RemoveAt(productIndex);
            _model.OrderItemQuantityChanged += (productIndex, orderItemTotalPrice) => _cartDataGridView.Rows[ productIndex ].Cells[ CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX ].Value = orderItemTotalPrice;
            _model.OrderItemQuantityIsExceededStorageQuantity += OrderItemQuantityIsExceededStorageQuantity;
            // UI
            _cartDataGridView.CellPainting += CartDataGridViewCellPainting;
            _cartDataGridView.CellContentClick += CartDataGridViewCellContentClick;
            _cartDataGridView.CellValueChanged += CartDataGridViewCellValueChanged;
            _leftArrowButton.Click += (sender, events) => GoToPreviousPage();
            _rightArrowButton.Click += (sender, events) => GoToNextPage();
            _addButton.Click += (sender, eventArguments) => _orderPresentationModel.AddCurrentSelectedProductToOrderIfProductIsNotInOrder();
            _orderButton.Click += ClickOrderButton;
            _productTabControl.SelectedIndexChanged += (sender, events) => SelectProductTabPage(_productTabControl.SelectedIndex);
            InitializeProductTabPages();
            // Initial UI States
            SelectProductTabPage(AppDefinition.MOTHER_BOARD_INDEX);
            UpdateCartSectionView();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void UpdateCartSectionView()
        {
            _cartTotalPrice.Text = AppDefinition.CART_TOTAL_PRICE_TEXT + _model.GetOrderTotalPrice();
            _orderButton.Enabled = _model.GetOrderItemsCount() != 0;
        }

        // Protest on Dr.Smell
        private void OrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int storageQuantity)
        {
            MessageBox.Show(this, ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_MESSAGE, ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_TITLE);
            _cartDataGridView.Rows[ orderItemIndex ].Cells[ CART_PRODUCT_QUANTITY_COLUMN_INDEX ].Value = storageQuantity;
        }

        // Protest on Dr.Smell
        private void CartDataGridViewCellPainting(object sender, DataGridViewCellPaintingEventArgs eventArguments)
        {
            if ( eventArguments.RowIndex < 0 )
            {
                return;
            }
            if ( eventArguments.ColumnIndex == 0 )
            {
                Image image = Resources.img_trash_bin;
                eventArguments.Paint(eventArguments.CellBounds, DataGridViewPaintParts.All);
                int width = image.Width;
                int height = image.Height;
                int left = eventArguments.CellBounds.Left + ( eventArguments.CellBounds.Width - width ) / AppDefinition.TWO;
                int top = eventArguments.CellBounds.Top + ( eventArguments.CellBounds.Height - height ) / AppDefinition.TWO;
                eventArguments.Graphics.DrawImage(image, new Rectangle(left, top, width, height));
                eventArguments.Handled = true;
            }
        }

        // Protest on Dr.Smell
        private void CartDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if ( eventArguments.RowIndex < 0 )
            {
                return;
            }
            if ( eventArguments.ColumnIndex == 0 )
            {
                _model.RemoveProductFromOrder(eventArguments.RowIndex);
            }
        }

        // Protest on Dr.Smell
        private void CartDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if ( eventArguments.ColumnIndex == CART_PRODUCT_QUANTITY_COLUMN_INDEX )
            {
                int currentRowIndex = eventArguments.RowIndex;
                DataGridViewTextBoxCell textBoxCell = ( DataGridViewTextBoxCell )_cartDataGridView.Rows[ currentRowIndex ].Cells[ CART_PRODUCT_QUANTITY_COLUMN_INDEX ];
                int newCartProductQuantity = int.Parse(textBoxCell.Value.ToString());
                _model.SetOrderItemQuantity(currentRowIndex, newCartProductQuantity);
            }
        }

        // Protest on Dr.Smell
        private void InitializeProductTabPageButtonsContainers()
        {
            _productTabPageButtonsContainers = new List<List<OrderProductTabPageButton>>();
            for ( int i = 0; i < AppDefinition.TAB_PAGES_COUNT; i++ )
            {
                _productTabPageButtonsContainers.Add(CreateProductTabPageButtons());
            }
        }

        // Protest on Dr.Smell
        private List<OrderProductTabPageButton> CreateProductTabPageButtons()
        {
            var productTabPageButtons = new List<OrderProductTabPageButton>();
            for ( int i = 0; i < AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT; i++ )
            {
                OrderProductTabPageButton button = new OrderProductTabPageButton();
                button.Click += (sender, eventArguments) => SelectProduct(button.Product);
                productTabPageButtons.Add(button);
            }
            return productTabPageButtons;
        }

        /// <summary>
        /// Select a product.
        /// </summary>
        private void SelectProduct(Product product)
        {
            _orderPresentationModel.SelectProduct(product);
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void ClickOrderButton(object sender, System.EventArgs eventArguments)
        {
            _creditCardPaymentForm.ShowDialog();
        }

        // Protest on Dr.Smell
        private void GoToPreviousPage()
        {
            _orderPresentationModel.GoToPreviousPage();
            UpdateProductTabView();
        }

        // Protest on Dr.Smell
        private void GoToNextPage()
        {
            _orderPresentationModel.GoToNextPage();
            UpdateProductTabView();
        }

        // Protest on Dr.Smell
        private void SelectProductTabPage(int tabPageIndex)
        {
            _orderPresentationModel.SelectProductTabPage(tabPageIndex);
            UpdateProductTabView();
        }

        // Protest on Dr.Smell
        private void UpdateProductTabView()
        {
            UpdateProductTabPageButtonsInCurrentProductTabPageAtCurrentProductPage();
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
                tabPage.Controls.Add(CreateTableLayout(TAB_PAGE_LAYOUT_NAME, AppDefinition.TAB_PAGE_LAYOUT_ROW_COUNT, AppDefinition.TAB_PAGE_LAYOUT_COLUMN_COUNT));
                PopulateProductTabPageButtons(( TableLayoutPanel )tabPage.Controls[ TAB_PAGE_LAYOUT_NAME ], i);
            }
        }

        /// <summary>
        /// Create a specified size table layout with a pre-defined name.
        /// </summary>
        private TableLayoutPanel CreateTableLayout(string tableLayoutName, int rowCount, int columnCount)
        {
            var tableLayout = new TableLayoutPanel();
            tableLayout.Name = tableLayoutName;
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.RowStyles.Clear();
            tableLayout.ColumnStyles.Clear();
            tableLayout.Controls.Clear();
            tableLayout.RowCount = rowCount;
            tableLayout.ColumnCount = columnCount;
            for ( int row = 0; row < rowCount; row++ )
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, AppDefinition.ONE_HUNDRED_PERCENT / rowCount));
            }
            for ( int col = 0; col < columnCount; col++ )
            {
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, AppDefinition.ONE_HUNDRED_PERCENT / columnCount));
            }
            return tableLayout;
        }

        // Protest on Dr.Smell
        private void PopulateProductTabPageButtons(TableLayoutPanel tabPageLayout, int tabPageIndex)
        {
            int productTabPageButtonsCount = 0;
            for ( int row = 0; row < AppDefinition.TAB_PAGE_LAYOUT_ROW_COUNT; row++ )
            {
                for ( int column = 0; column < AppDefinition.TAB_PAGE_LAYOUT_COLUMN_COUNT; column++ )
                {
                    OrderProductTabPageButton button = _productTabPageButtonsContainers[ tabPageIndex ][ productTabPageButtonsCount ];
                    tabPageLayout.Controls.Add(button, column, row);
                    button.Dock = DockStyle.Fill; // Make button fill in table cell
                    productTabPageButtonsCount++;
                }
            }
        }

        // Protest on Dr.Smell
        private void UpdateProductTabPageButtonsInCurrentProductTabPageAtCurrentProductPage()
        {
            int currentTabPageIndex = _productTabControl.SelectedIndex;
            List<OrderProductTabPageButton> productTabPageButtons = _productTabPageButtonsContainers[ currentTabPageIndex ];
            for ( int i = 0; i < AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT; i++ )
            {
                productTabPageButtons[ i ].Product = _orderPresentationModel.GetProductAtCurrentProductPage(currentTabPageIndex, i);
            }
        }

        /// <summary>
        /// Referesh controls.
        /// </summary>
        public void RefreshControls()
        {
            _productNameAndDescription.Text = _orderPresentationModel.ProductNameAndDescription.Text;
            _productStorageQuantity.Text = _orderPresentationModel.ProductStorageQuantity.Text;
            _productPrice.Text = _orderPresentationModel.ProductPrice.Text;
            _addButton.Enabled = _orderPresentationModel.AddButton.Enabled;
            _pageLabel.Text = _orderPresentationModel.PageLabel.Text;
            _leftArrowButton.Enabled = _orderPresentationModel.LeftArrowButton.Enabled;
            _rightArrowButton.Enabled = _orderPresentationModel.RightArrowButton.Enabled;
        }
    }
}
