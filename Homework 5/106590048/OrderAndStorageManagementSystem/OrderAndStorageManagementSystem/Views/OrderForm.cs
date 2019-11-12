using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Properties;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
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
        private const int CART_PRODUCT_NAME_COLUMN_INDEX = 1;
        private const int CART_PRODUCT_TYPE_COLUMN_INDEX = 2;
        private const int CART_PRODUCT_PRICE_COLUMN_INDEX = 3;
        private const int CART_PRODUCT_QUANTITY_COLUMN_INDEX = 4;
        private const int CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX = 5;
        private const int FIRST_PRODUCT_TAB_PAGE_INDEX = 0;
        private CreditCardPaymentForm _creditCardPaymentForm;
        private OrderPresentationModel _orderPresentationModel;
        private Model _model;
        private List<List<OrderProductTabPageButton>> _productTabPageButtonsContainers;

        public OrderForm(CreditCardPaymentForm creditCardPaymentFormData, OrderPresentationModel orderPresentationModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentForm = creditCardPaymentFormData;
            _orderPresentationModel = orderPresentationModelData;
            _model = modelData;
            InitializeProductTabPageButtonsContainers();
            this.Disposed += RemoveEvents;
            // Observers
            _model.OrderChanged += UpdateCartSectionViewOnOrderChanged;
            _model.OrderCleared += ClearCartDataGridViewOnOrderCleared;
            _model.OrderAdded += AddOrderItemToCartDataGridView;
            _model.OrderRemoved += RemoveOrderItemAtFromCartDataGridView;
            _model.OrderItemQuantityChanged += UpdateOrderItemTotalPriceAtInCartDataGridView;
            _model.OrderItemQuantityIsExceededStorageQuantity += ShowMessageBoxAndSetOrderItemQuantityToStorageQuantityOnOrderItemQuantityIsExceededStorageQuantity;
            _model.ProductInfoChanged += UpdateViewOnProductInfoChanged;
            _model.ProductAdded += UpdateViewOnProductAdded;
            _orderPresentationModel.AddButtonEnabledChanged += UpdateAddButtonView;
            _orderPresentationModel.CurrentProductInfoChanged += UpdateProductInfoView;
            // UI
            _cartDataGridView.CellPainting += (sender, eventArguments) => DataGridViewHelper.InitializeButtonImageOfButtonColumn(eventArguments, CART_DELETE_BUTTON_COLUMN_INDEX, Resources.img_trash_bin);
            _cartDataGridView.CellContentClick += ClickCartDataGridViewCellContent;
            _cartDataGridView.CellValueChanged += ChangeCartDataGridViewCellValue;
            _leftArrowButton.Click += (sender, eventArguments) => GoToPreviousProductPage();
            _rightArrowButton.Click += (sender, eventArguments) => GoToNextProductPage();
            _addButton.Click += (sender, eventArguments) => _orderPresentationModel.AddCurrentSelectedProductToOrderIfProductIsNotInOrder();
            _orderButton.Click += ClickOrderButton;
            _productTabControl.SelectedIndexChanged += (sender, eventArguments) => SelectProductTabPage(_productTabControl.SelectedIndex);
            InitializeTabPages();
            InitializeProductTabPages();
            // Initial UI States
            SelectProductTabPage(FIRST_PRODUCT_TAB_PAGE_INDEX);
            InitializeCartDataGridView();
            UpdateCartSectionViewOnOrderChanged();
            RefreshControls();
        }

        /// <summary>
        /// Unsubscribe from all events that were subscribed by this form.
        /// </summary>
        private void RemoveEvents(object sender, EventArgs eventArguments)
        {
            _model.OrderChanged -= UpdateCartSectionViewOnOrderChanged;
            _model.OrderCleared -= ClearCartDataGridViewOnOrderCleared;
            _model.OrderAdded -= AddOrderItemToCartDataGridView;
            _model.OrderRemoved -= RemoveOrderItemAtFromCartDataGridView;
            _model.OrderItemQuantityChanged -= UpdateOrderItemTotalPriceAtInCartDataGridView;
            _model.OrderItemQuantityIsExceededStorageQuantity -= ShowMessageBoxAndSetOrderItemQuantityToStorageQuantityOnOrderItemQuantityIsExceededStorageQuantity;
            _model.ProductInfoChanged -= UpdateViewOnProductInfoChanged;
            _model.ProductAdded -= UpdateViewOnProductAdded;
            _orderPresentationModel.AddButtonEnabledChanged -= UpdateAddButtonView;
            _orderPresentationModel.CurrentProductInfoChanged -= UpdateProductInfoView;
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
        /// Clear cart data grid view on order cleared.
        /// </summary>
        private void ClearCartDataGridViewOnOrderCleared()
        {
            _cartDataGridView.Rows.Clear();
        }

        /// <summary>
        /// Add order item to the cart data grid view.
        /// </summary>
        private void AddOrderItemToCartDataGridView(OrderItem orderItem)
        {
            _cartDataGridView.Rows.Add(null, orderItem.Name, orderItem.Type, orderItem.Price.GetCurrencyFormat(), orderItem.OrderQuantity, orderItem.GetTotalPrice().GetCurrencyFormat());
        }

        /// <summary>
        /// Remove order item at orderItemIndex from cart data grid view.
        /// </summary>
        private void RemoveOrderItemAtFromCartDataGridView(int orderItemIndex, Product removedProduct)
        {
            _cartDataGridView.Rows.RemoveAt(orderItemIndex);
        }

        /// <summary>
        /// Update order item total price at orderItemIndex in cart data grid view.
        /// </summary>
        private void UpdateOrderItemTotalPriceAtInCartDataGridView(int orderItemIndex, string orderItemTotalPrice)
        {
            _cartDataGridView.Rows[ orderItemIndex ].Cells[ CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX ].Value = orderItemTotalPrice;
        }

        /// <summary>
        /// Show MessageBox and set order item quantity to its storage quantity on order quantity of order item is exceeded its storage quantity.
        /// </summary>
        private void ShowMessageBoxAndSetOrderItemQuantityToStorageQuantityOnOrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int storageQuantity)
        {
            MessageBox.Show(this, ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_MESSAGE, ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY_TITLE);
            _cartDataGridView.Rows[ orderItemIndex ].Cells[ CART_PRODUCT_QUANTITY_COLUMN_INDEX ].Value = storageQuantity;
        }

        /// <summary>
        /// Update view on product info changed.
        /// </summary>
        private void UpdateViewOnProductInfoChanged(Product product)
        {
            SelectProductTabPage(_productTabControl.SelectedIndex); // Reselect the current page to update product type and image in the product tab page view.
            for ( int rowIndex = 0; rowIndex < _cartDataGridView.Rows.Count; rowIndex++ )
            {
                OrderItem orderItem = _model.GetOrderItemAt(rowIndex);
                _cartDataGridView.Rows[ rowIndex ].Cells[ CART_PRODUCT_NAME_COLUMN_INDEX ].Value = orderItem.Name;
                _cartDataGridView.Rows[ rowIndex ].Cells[ CART_PRODUCT_TYPE_COLUMN_INDEX ].Value = orderItem.Type;
                _cartDataGridView.Rows[ rowIndex ].Cells[ CART_PRODUCT_PRICE_COLUMN_INDEX ].Value = orderItem.Price.GetCurrencyFormat();
                _cartDataGridView.Rows[ rowIndex ].Cells[ CART_PRODUCT_TOTAL_PRICE_COLUMN_INDEX ].Value = orderItem.GetTotalPrice().GetCurrencyFormat();
            }
        }

        /// <summary>
        /// Update view on product added.
        /// </summary>
        private void UpdateViewOnProductAdded(Product product)
        {
            SelectProductTabPage(_productTabControl.SelectedIndex); // Reselect the current page to update product type and image in the product tab page view.
        }

        /// <summary>
        /// Update enabled state of add button.
        /// </summary>
        private void UpdateAddButtonView()
        {
            _addButton.Enabled = _orderPresentationModel.GetAddButtonEnabled();
        }

        /// <summary>
        /// Update text of product storage quantity.
        /// </summary>
        private void UpdateProductInfoView()
        {
            _productStorageQuantity.Text = _orderPresentationModel.GetCurrentProductStorageQuantity();
            _productNameAndDescription.Text = _orderPresentationModel.GetCurrentProductNameAndDescription();
            _productPrice.Text = _orderPresentationModel.GetCurrentProductPrice();
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
            for ( int i = 0; i < _model.GetProductTypesCount(); i++ )
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
                button.Click += (sender, eventArguments) => _orderPresentationModel.SelectProduct(button.Product);
                productTabPageButtons.Add(button);
            }
            return productTabPageButtons;
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
        /// Initialize tab pages.
        /// </summary>
        private void InitializeTabPages()
        {
            foreach ( string productType in _model.GetProductTypes() )
            {
                _productTabControl.Controls.Add(new TabPage(productType));
            }
        }

        /// <summary>
        /// Initialize product tab pages.
        /// </summary>
        private void InitializeProductTabPages()
        {
            TabControl.TabPageCollection tabPages = _productTabControl.TabPages;
            for ( int i = 0; i < _model.GetProductTypesCount(); i++ )
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
        /// Initialize cart data grid view.
        /// </summary>
        private void InitializeCartDataGridView()
        {
            foreach ( OrderItem orderItem in _model.GetOrderItems() )
            {
                _cartDataGridView.Rows.Add(null, orderItem.Name, orderItem.Type, orderItem.Price.GetCurrencyFormat(), orderItem.OrderQuantity, orderItem.GetTotalPrice().GetCurrencyFormat());
            }
        }

        /// <summary>
        /// Referesh controls.
        /// </summary>
        private void RefreshControls()
        {
            _pageLabel.Text = _orderPresentationModel.GetPageLabelText();
            _leftArrowButton.Enabled = _orderPresentationModel.GetLeftArrowButtonEnabled();
            _rightArrowButton.Enabled = _orderPresentationModel.GetRightArrowButtonEnabled();
        }
    }
}
