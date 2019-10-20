using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels.Utilities;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class OrderPresentationModel
    {
        public delegate void AddButtonEnabledChangedEventHandler();
        private event AddButtonEnabledChangedEventHandler _addButtonEnabledChanged;
        public AddButtonEnabledChangedEventHandler AddButtonEnabledChanged
        {
            get
            {
                return _addButtonEnabledChanged;
            }
            set
            {
                _addButtonEnabledChanged = value;
            }
        }
        public ControlStates ProductNameAndDescription
        {
            get
            {
                return _productNameAndDescription;
            }
        }
        public ControlStates ProductStorageQuantity
        {
            get
            {
                return _productStorageQuantity;
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
        private const int CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE = 0;
        private OrderModel _orderModel;
        private Model _model;
        private ControlStates _productNameAndDescription;
        private ControlStates _productStorageQuantity;
        private ControlStates _productPrice;
        private ControlStates _addButton;
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
            // Observers
            _model.OrderAdded += (orderItem) => AddOrRemoveProductFromOrder(orderItem.Product);
            _model.OrderRemoved += (orderItemIndex, removedProduct) => AddOrRemoveProductFromOrder(removedProduct);
            // UI
            _productNameAndDescription = new ControlStates();
            _productStorageQuantity = new ControlStates();
            _productPrice = new ControlStates();
            _addButton = new ControlStates();
            _pageLabel = new ControlStates();
            _leftArrowButton = new ControlStates();
            _rightArrowButton = new ControlStates();
        }

        // Protest on Dr.Smell
        private void AddOrRemoveProductFromOrder(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                _addButton.Enabled = !_model.IsInOrder(new OrderItem(product));
                NotifyObserverChangeAddButtonEnabled();
            }
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeAddButtonEnabled()
        {
            if ( AddButtonEnabledChanged != null )
            {
                AddButtonEnabledChanged();
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

        // Protest on Dr.Smell
        public void SelectProductTabPage(int tabPageIndex)
        {
            _currentTabPageIndex = tabPageIndex;
            ResetCurrentProductPageIndex();
            UpdateCurrentProductPage();
        }

        // Protest on Dr.Smell
        private void ResetCurrentProductPageIndex()
        {
            _currentProductPageIndex = CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE;
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

        /// <summary>
        /// Select no product.
        /// </summary>
        private void SelectNoProduct()
        {
            _currentSelectedProduct = null;
            UpdateCurrentProductInfo();
            _addButton.Enabled = false;
        }

        /// <summary>
        /// Select a product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _currentSelectedProduct = product;
            UpdateCurrentProductInfo();
            _addButton.Enabled = !_model.IsInOrder(new OrderItem(product));
        }

        /// <summary>
        /// Set product info text, including product name, description and price.
        /// </summary>
        private void UpdateCurrentProductInfo()
        {
            if ( _currentSelectedProduct == null )
            {
                _productNameAndDescription.Text = "";
                _productStorageQuantity.Text = "";
                _productPrice.Text = "";
            }
            else
            {
                _productNameAndDescription.Text = _currentSelectedProduct.GetProductNameAndDescription();
                _productStorageQuantity.Text = AppDefinition.PRODUCT_STORAGE_QUANTITY_TEXT + _currentSelectedProduct.GetStorageQuantity();
                _productPrice.Text = AppDefinition.PRODUCT_PRICE_TEXT + _currentSelectedProduct.GetPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
            }
        }

        // Protest on Dr.Smell
        public Product GetProductAtCurrentProductPage(int tabPageIndex, int productIndex)
        {
            return _orderModel.GetProduct(tabPageIndex, _currentProductPageIndex, productIndex);
        }

        // Protest on Dr.Smell
        public void AddCurrentSelectedProductToOrderIfProductIsNotInOrder()
        {
            _model.AddProductToOrderIfProductIsNotInOrder(_currentSelectedProduct);
        }
    }
}