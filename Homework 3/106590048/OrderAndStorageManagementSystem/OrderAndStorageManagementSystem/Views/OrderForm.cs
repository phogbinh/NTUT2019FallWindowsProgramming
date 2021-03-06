﻿using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Properties;
using OrderAndStorageManagementSystem.Views.Utilities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class OrderForm : Form
    {
        private const string TAB_PAGE_LAYOUT_NAME = "_productTabPageLayout";
        private const string ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_MESSAGE = "庫存不足";
        private const string ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_TITLE = "庫存狀態";
        private const int CART_DELETE_BUTTON_COLUMN_INDEX = 0;
        private const int CART_PRODUCT_QUANTITY_COLUMN_INDEX = 4;
        private const int CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX = 5;
        private CreditCardPaymentForm _creditCardPaymentForm;
        private OrderPresentationModel _orderPresentationModel;
        private OrderModel _orderModel;
        private Model _model;
        private List<List<OrderProductTabPageButton>> _productTabPageButtonsContainers;

        public OrderForm(CreditCardPaymentForm creditCardPaymentFormData, OrderPresentationModel orderPresentationModelData, OrderModel orderModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentForm = creditCardPaymentFormData;
            _orderPresentationModel = orderPresentationModelData;
            _orderModel = orderModelData;
            _model = modelData;
            InitializeProductTabPageButtonsContainers();
            // Observers
            _model.OrderChanged += UpdateCartSectionViewOnOrderChanged;
            _model.OrderCleared += UpdateViewOnOrderCleared;
            _model.OrderAdded += (orderItem) => _cartDataGridView.Rows.Add(null, orderItem.Name, orderItem.Type, orderItem.Price.GetCurrencyFormat(), orderItem.OrderQuantity, orderItem.GetTotalPrice().GetCurrencyFormat());
            _model.OrderRemoved += (orderItemIndex, removedProduct) => _cartDataGridView.Rows.RemoveAt(orderItemIndex);
            _model.OrderItemQuantityChanged += (orderItemIndex, orderItemTotalPrice) => _cartDataGridView.Rows[ orderItemIndex ].Cells[ CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX ].Value = orderItemTotalPrice;
            _model.OrderItemQuantityIsExceededStorageQuantity += UpdateViewOnOrderItemQuantityIsExceededStorageQuantity;
            _orderPresentationModel.AddButtonEnabledChanged += () => _addButton.Enabled = _orderPresentationModel.AddButton.Enabled;
            _orderPresentationModel.OrderFormProductStorageQuantityTextChanged += () => _productStorageQuantity.Text = _orderPresentationModel.ProductStorageQuantity.Text;
            // UI
            _cartDataGridView.CellPainting += (sender, eventArguments) => DataGridViewHelper.InitializeButtonImageOfButtonColumn(eventArguments, CART_DELETE_BUTTON_COLUMN_INDEX, Resources.img_trash_bin);
            _cartDataGridView.CellContentClick += ClickCartDataGridViewCellContent;
            _cartDataGridView.CellValueChanged += ChangeCartDataGridViewCellValue;
            _leftArrowButton.Click += (sender, events) => GoToPreviousProductPage();
            _rightArrowButton.Click += (sender, events) => GoToNextProductPage();
            _addButton.Click += (sender, eventArguments) => _orderPresentationModel.AddCurrentSelectedProductToOrderIfProductIsNotInOrder();
            _orderButton.Click += ClickOrderButton;
            _productTabControl.SelectedIndexChanged += (sender, events) => SelectProductTabPage(_productTabControl.SelectedIndex);
            InitializeProductTabPages();
            // Initial UI States
            SelectProductTabPage(AppDefinition.MOTHER_BOARD_INDEX);
            UpdateCartSectionViewOnOrderChanged();
            RefreshControls();
        }

        /// <summary>
        /// Update cart section view on order changed.
        /// </summary>
        private void UpdateCartSectionViewOnOrderChanged()
        {
            _cartTotalPrice.Text = AppDefinition.CART_TOTAL_PRICE_TEXT + _model.GetOrderTotalPrice();
            _orderButton.Enabled = _model.GetOrderItemsCount() != 0;
        }

        /// <summary>
        /// Update view on ordered clear.
        /// </summary>
        private void UpdateViewOnOrderCleared()
        {
            _cartDataGridView.Rows.Clear();
            SelectNoProduct();
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        private void SelectNoProduct()
        {
            _orderPresentationModel.SelectNoProduct();
            RefreshControls();
        }

        /// <summary>
        /// Update view on order quantity of order item is exceeded its storage quantity.
        /// </summary>
        private void UpdateViewOnOrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int storageQuantity)
        {
            MessageBox.Show(this, ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_MESSAGE, ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_TITLE);
            _cartDataGridView.Rows[ orderItemIndex ].Cells[ CART_PRODUCT_QUANTITY_COLUMN_INDEX ].Value = storageQuantity;
        }

        /// <summary>
        /// Click cell content of cart data grid view. Use to handle button column click.
        /// </summary>
        private void ClickCartDataGridViewCellContent(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if ( eventArguments.RowIndex < 0 )
            {
                return;
            }
            if ( eventArguments.ColumnIndex == CART_DELETE_BUTTON_COLUMN_INDEX )
            {
                _model.RemoveOrderItemAt(eventArguments.RowIndex);
            }
        }

        /// <summary>
        /// Change cart data grid view cell value. Used to handle DataGridViewNumericUpDownColumn change.
        /// </summary>
        private void ChangeCartDataGridViewCellValue(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if ( eventArguments.ColumnIndex == CART_PRODUCT_QUANTITY_COLUMN_INDEX )
            {
                int currentRowIndex = eventArguments.RowIndex;
                DataGridViewTextBoxCell textBoxCell = ( DataGridViewTextBoxCell )_cartDataGridView.Rows[ currentRowIndex ].Cells[ CART_PRODUCT_QUANTITY_COLUMN_INDEX ];
                int newCartProductQuantity = int.Parse(textBoxCell.Value.ToString());
                _model.SetOrderItemQuantity(currentRowIndex, newCartProductQuantity);
            }
        }

        /// <summary>
        /// Initialize _productTabPageButtonsContainers.
        /// </summary>
        private void InitializeProductTabPageButtonsContainers()
        {
            _productTabPageButtonsContainers = new List<List<OrderProductTabPageButton>>();
            for ( int i = 0; i < AppDefinition.TAB_PAGES_COUNT; i++ )
            {
                _productTabPageButtonsContainers.Add(CreateProductTabPageButtons());
            }
        }

        /// <summary>
        /// Create product tab page buttons.
        /// </summary>
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
        /// Select product.
        /// </summary>
        private void SelectProduct(Product product)
        {
            _orderPresentationModel.SelectProduct(product);
            RefreshControls();
        }

        /// <summary>
        /// Click order button.
        /// </summary>
        private void ClickOrderButton(object sender, System.EventArgs eventArguments)
        {
            _creditCardPaymentForm.ShowDialog();
        }

        /// <summary>
        /// Go to previous product page.
        /// </summary>
        private void GoToPreviousProductPage()
        {
            _orderPresentationModel.GoToPreviousProductPage();
            UpdateProductTabPageView();
        }

        /// <summary>
        /// Go to next product page.
        /// </summary>
        private void GoToNextProductPage()
        {
            _orderPresentationModel.GoToNextProductPage();
            UpdateProductTabPageView();
        }

        /// <summary>
        /// Select the product tab page whose index is tabPageIndex.
        /// </summary>
        private void SelectProductTabPage(int tabPageIndex)
        {
            _orderPresentationModel.SelectProductTabPage(tabPageIndex);
            UpdateProductTabPageView();
        }

        /// <summary>
        /// Update product tab page view.
        /// </summary>
        private void UpdateProductTabPageView()
        {
            UpdateProductTabPageButtonsInCurrentProductTabPageAtCurrentProductPage();
            RefreshControls();
        }

        /// <summary>
        /// Initialize product tab pages.
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
        /// Create a rowCount by columnCount table layout with name as tableLayoutName.
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

        /// <summary>
        /// Populate product tab page buttons onto the product tab page whose index is tabPageIndex.
        /// </summary>
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

        /// <summary>
        /// Update the product tab page buttons in the current product tab page, at the current product page.
        /// </summary>
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
            _productPrice.Text = _orderPresentationModel.ProductPrice.Text;
            _pageLabel.Text = _orderPresentationModel.PageLabel.Text;
            _leftArrowButton.Enabled = _orderPresentationModel.LeftArrowButton.Enabled;
            _rightArrowButton.Enabled = _orderPresentationModel.RightArrowButton.Enabled;
        }
    }
}
