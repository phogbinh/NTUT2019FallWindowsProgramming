using OrderAndStorageManagementSystem.ModelNamespace;

namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class OrderPresentationModel
    {
        private const int CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE = 0;
        public ControlStates ProductNameAndDescription
        {
            get
            {
                return _productNameAndDescription;
            }
        }
        public ControlStates ProductPrice
        {
            get
            {
                return _productPrice;
            }
        }
        public ControlStates AddButton
        {
            get
            {
                return _addButton;
            }
        }
        public ControlStates CartTotalPrice
        {
            get
            {
                return _cartTotalPrice;
            }
        }
        public ControlStates PageLabel
        {
            get
            {
                return _pageLabel;
            }
        }
        public ControlStates LeftArrowButton
        {
            get
            {
                return _leftArrowButton;
            }
        }
        public ControlStates RightArrowButton
        {
            get
            {
                return _rightArrowButton;
            }
        }
        public Product CurrentSelectedProduct
        {
            get
            {
                return _currentSelectedProduct;
            }
        }
        private OrderModel _orderModel;
        private Model _model;
        private ControlStates _productNameAndDescription;
        private ControlStates _productPrice;
        private ControlStates _addButton;
        private ControlStates _cartTotalPrice;
        private ControlStates _pageLabel;
        private ControlStates _leftArrowButton;
        private ControlStates _rightArrowButton;
        private Product _currentSelectedProduct;
        private int _currentTabPageIndex;
        private int _currentProductPageIndex;

        public OrderPresentationModel(OrderModel orderModelData, Model modelData)
        {
            _orderModel = orderModelData;
            _model = modelData;
            _productNameAndDescription = new ControlStates();
            _productPrice = new ControlStates();
            _addButton = new ControlStates();
            _cartTotalPrice = new ControlStates();
            _pageLabel = new ControlStates();
            _leftArrowButton = new ControlStates();
            _rightArrowButton = new ControlStates();
        }

        /// <summary>
        /// Select a product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _currentSelectedProduct = product;
            SetProductInfoText(product.GetProductNameAndDescription(), AppDefinition.PRODUCT_PRICE_TEXT + product.GetPrice(AppDefinition.TAIWAN_CURRENCY_UNIT));
            _addButton.Enabled = true;
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        private void SelectNoProduct()
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
        }

        // Protest on Dr.Smell
        private void ResetCurrentProductPageIndex()
        {
            _currentProductPageIndex = CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE;
        }

        // Protest on Dr.Smell
        public Product GetProduct(int tabPageIndex, int productIndex)
        {
            return _orderModel.GetProduct(tabPageIndex, _currentProductPageIndex, productIndex);
        }

        // Protest on Dr.Smell
        public void AddCurrentSelectedProductToOrder()
        {
            _model.AddProductToOrder(_currentSelectedProduct);
            _cartTotalPrice.Text = AppDefinition.CART_TOTAL_PRICE_TEXT + _model.GetOrderTotalPrice();
        }

        // Protest on Dr.Smell
        public void SelectProductTabPage(int tabPageIndex)
        {
            _currentTabPageIndex = tabPageIndex;
            ResetCurrentProductPageIndex();
            UpdateCurrentProductPage();
        }

        // Protest on Dr.Smell
        private void UpdateCurrentProductPage()
        {
            _pageLabel.Text = AppDefinition.PAGE_LABEL_TEXT + AppDefinition.GetHumanIndex(_currentProductPageIndex) + AppDefinition.PAGE_LABEL_DELIMITER + _orderModel.GetTabPageProductPagesCount(_currentTabPageIndex);
            UpdatePageNavigationButtons();
            SelectNoProduct();
        }

        // Protest on Dr.Smell
        private void UpdatePageNavigationButtons()
        {
            int humanIndex = AppDefinition.GetHumanIndex(_currentProductPageIndex);
            if ( humanIndex == 1 )
            {
                _leftArrowButton.Enabled = false;
            }
            else
            {
                _leftArrowButton.Enabled = true;
            }
            if ( humanIndex == _orderModel.GetTabPageProductPagesCount(_currentTabPageIndex) )
            {
                _rightArrowButton.Enabled = false;
            }
            else
            {
                _rightArrowButton.Enabled = true;
            }
        }

        // Protest on Dr.Smell
        public void GoToPreviousPage()
        {
            _currentProductPageIndex--;
            UpdateCurrentProductPage();
        }

        // Protest on Dr.Smell
        public void GoToNextPage()
        {
            _currentProductPageIndex++;
            UpdateCurrentProductPage();
        }
    }
}