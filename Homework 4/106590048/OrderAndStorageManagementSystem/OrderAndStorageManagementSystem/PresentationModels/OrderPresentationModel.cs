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
        public delegate void OrderFormProductStorageQuantityTextChangedEventHandler();
        private event OrderFormProductStorageQuantityTextChangedEventHandler _orderFormProductStorageQuantityTextChanged;
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
        public OrderFormProductStorageQuantityTextChangedEventHandler OrderFormProductStorageQuantityTextChanged
        {
            get
            {
                return _orderFormProductStorageQuantityTextChanged;
            }
            set
            {
                _orderFormProductStorageQuantityTextChanged = value;
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
            _model.OrderAdded += (orderItem) => UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder(orderItem.Product);
            _model.OrderRemoved += (orderItemIndex, removedProduct) => UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder(removedProduct);
            _model.ProductStorageQuantityChanged += UpdateProductStorageQuantityAndAddButtonIfChangedCurrentSelectedProductStorageQuantity;
            // UI
            _productNameAndDescription = new ControlStates();
            _productStorageQuantity = new ControlStates();
            _productPrice = new ControlStates();
            _addButton = new ControlStates();
            _pageLabel = new ControlStates();
            _leftArrowButton = new ControlStates();
            _rightArrowButton = new ControlStates();
        }

        /// <summary>
        /// Update enabled state of add button if the current selected product is added to or removed from order.
        /// </summary>
        private void UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                UpdateAddButtonByCurrentSelectedProduct();
            }
        }

        /// <summary>
        /// Update text of product storage quantity and enabled state of add button if the storage quantity of the current selected product is changed.
        /// </summary>
        private void UpdateProductStorageQuantityAndAddButtonIfChangedCurrentSelectedProductStorageQuantity(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                UpdateProductStorageQuantityByCurrentSelectedProduct();
                UpdateAddButtonByCurrentSelectedProduct();
            }
        }

        /// <summary>
        /// Update text of product storage quantity by the current selected product.
        /// </summary>
        private void UpdateProductStorageQuantityByCurrentSelectedProduct()
        {
            _productStorageQuantity.Text = _currentSelectedProduct == null ? "" : AppDefinition.PRODUCT_STORAGE_QUANTITY_TEXT + _currentSelectedProduct.GetStorageQuantity();
            NotifyObserverChangeOrderFormProductStorageQuantityText();
        }

        /// <summary>
        /// Notify observer change text of order form product storage quantity.
        /// </summary>
        private void NotifyObserverChangeOrderFormProductStorageQuantityText()
        {
            if ( OrderFormProductStorageQuantityTextChanged != null )
            {
                OrderFormProductStorageQuantityTextChanged();
            }
        }

        /// <summary>
        /// Update enabled state of add button by current selected product.
        /// </summary>
        private void UpdateAddButtonByCurrentSelectedProduct()
        {
            _addButton.Enabled = _currentSelectedProduct != null && !_model.IsInOrder(new OrderItem(_currentSelectedProduct)) && _currentSelectedProduct.StorageQuantity > 0;
            NotifyObserverChangeAddButtonEnabled();
        }

        /// <summary>
        /// Notify observer change enabled state of add button.
        /// </summary>
        private void NotifyObserverChangeAddButtonEnabled()
        {
            if ( AddButtonEnabledChanged != null )
            {
                AddButtonEnabledChanged();
            }
        }

        /// <summary>
        /// Go to previous product page.
        /// </summary>
        public void GoToPreviousProductPage()
        {
            _currentProductPageIndex--;
            UpdateCurrentProductPage();
        }

        /// <summary>
        /// Go to next product page.
        /// </summary>
        public void GoToNextProductPage()
        {
            _currentProductPageIndex++;
            UpdateCurrentProductPage();
        }

        /// <summary>
        /// Select the product tab page whose index is tabPageIndex.
        /// </summary>
        public void SelectProductTabPage(int tabPageIndex)
        {
            _currentTabPageIndex = tabPageIndex;
            ResetCurrentProductPageIndex();
            UpdateCurrentProductPage();
        }

        /// <summary>
        /// Reset current product page index to initial value.
        /// </summary>
        private void ResetCurrentProductPageIndex()
        {
            _currentProductPageIndex = CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE;
        }

        /// <summary>
        /// Update current product page.
        /// </summary>
        private void UpdateCurrentProductPage()
        {
            _pageLabel.Text = AppDefinition.PAGE_LABEL_TEXT + AppDefinition.GetHumanIndex(_currentProductPageIndex) + AppDefinition.PAGE_LABEL_DELIMITER + _orderModel.GetTabPageProductPagesCount(_currentTabPageIndex);
            UpdatePageNavigationButtons();
            SelectNoProduct();
        }

        /// <summary>
        /// Update enabled states of page navigation buttons.
        /// </summary>
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
        public void SelectNoProduct()
        {
            _currentSelectedProduct = null;
            UpdateCurrentProductInfo();
            UpdateAddButtonByCurrentSelectedProduct();
        }

        /// <summary>
        /// Select product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _currentSelectedProduct = product;
            UpdateCurrentProductInfo();
            UpdateAddButtonByCurrentSelectedProduct();
        }

        /// <summary>
        /// Update current product info, including product name, description and price.
        /// </summary>
        private void UpdateCurrentProductInfo()
        {
            UpdateProductStorageQuantityByCurrentSelectedProduct();
            if ( _currentSelectedProduct == null )
            {
                _productNameAndDescription.Text = "";
                _productPrice.Text = "";
            }
            else
            {
                _productNameAndDescription.Text = _currentSelectedProduct.GetProductNameAndDescription();
                _productPrice.Text = AppDefinition.PRODUCT_PRICE_TEXT + _currentSelectedProduct.GetPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
            }
        }

        /// <summary>
        /// Get the product at productIndex in the current product page, which is inside the tab page whose index is tabPageIndex.
        /// </summary>
        public Product GetProductAtCurrentProductPage(int tabPageIndex, int productIndex)
        {
            return _orderModel.GetProduct(tabPageIndex, _currentProductPageIndex, productIndex);
        }

        /// <summary>
        /// Add current selected product to order if the product is not in order.
        /// </summary>
        public void AddCurrentSelectedProductToOrderIfProductIsNotInOrder()
        {
            _model.AddProductToOrderIfProductIsNotInOrder(_currentSelectedProduct);
        }
    }
}