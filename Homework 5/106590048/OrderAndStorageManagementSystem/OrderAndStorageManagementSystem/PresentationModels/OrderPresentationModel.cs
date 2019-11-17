using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class OrderPresentationModel
    {
        public delegate void AddButtonEnabledChangedEventHandler();
        public delegate void CurrentProductInfoChangedEventHandler();
        public delegate void CurrentProductPageIndexChangedEventHandler();
        public AddButtonEnabledChangedEventHandler AddButtonEnabledChanged
        {
            get; set;
        }
        public CurrentProductInfoChangedEventHandler CurrentProductInfoChanged
        {
            get; set;
        }
        public CurrentProductPageIndexChangedEventHandler CurrentProductPageIndexChanged
        {
            get; set;
        }
        private const string ERROR_MODEL_IS_NULL = "The given model is null.";
        private const string ERROR_ORDER_ITEM_IS_NULL = "The given order item is null.";
        private const string ERROR_CURRENT_PRODUCT_PAGE_INDEX_CANNOT_BE_SET_TO_NEGATIVE = "Current product page index cannot be set to negative.";
        private const string ERROR_CURRENT_TAB_PAGE_INDEX_CANNOT_BE_SET_TO_NEGATIVE = "Current tab page index cannot be set to negative.";
        private const int CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE = 0;
        private Model _model;
        private Product _currentSelectedProduct;
        private int _currentTabPageIndex;
        private int _currentProductPageIndex;

        ~OrderPresentationModel()
        {
            _model.OrderCleared -= NotifyObserverChangeAddButtonEnabled;
            _model.OrderAdded -= HandleModelOrderAdded;
            _model.OrderRemoved -= HandleModelOrderRemoved;
            _model.ProductStorageQuantityChanged -= UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity;
        }

        public OrderPresentationModel(Model modelData)
        {
            if ( modelData == null )
            {
                throw new ArgumentNullException(ERROR_MODEL_IS_NULL);
            }
            _model = modelData;
            // Observers
            _model.OrderCleared += NotifyObserverChangeAddButtonEnabled;
            _model.OrderAdded += HandleModelOrderAdded;
            _model.OrderRemoved += HandleModelOrderRemoved;
            _model.ProductStorageQuantityChanged += UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity;
            // Initial states of all member variables of the presentation model is set by its view.
        }

        /// <summary>
        /// Handle the event OrderAdded of model.
        /// </summary>
        private void HandleModelOrderAdded(OrderItem orderItem)
        {
            if ( orderItem == null )
            {
                throw new ArgumentNullException(ERROR_ORDER_ITEM_IS_NULL);
            }
            UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder(orderItem.Product);
        }

        /// <summary>
        /// Handle the event OrderRemoved of model.
        /// </summary>
        private void HandleModelOrderRemoved(int orderItemIndex, Product removedProduct)
        {
            UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder(removedProduct);
        }

        /// <summary>
        /// Update enabled state of add button if the current selected product is added to or removed from order.
        /// </summary>
        private void UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                NotifyObserverChangeAddButtonEnabled();
            }
        }

        /// <summary>
        /// Update current product info and enabled state of add button if the storage quantity of the current selected product is changed.
        /// </summary>
        private void UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                NotifyObserverChangeCurrentProductInfo();
                NotifyObserverChangeAddButtonEnabled();
            }
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
        /// Get the enabled state of the add button.
        /// </summary>
        public bool IsAddButtonEnabled()
        {
            return _currentSelectedProduct != null && !_model.IsInOrder(_currentSelectedProduct.Id) && _currentSelectedProduct.StorageQuantity > 0;
        }

        /// <summary>
        /// Set current product page index.
        /// </summary>
        private void SetCurrentProductPageIndexAndNotifyObserver(int value)
        {
            if ( value < 0 )
            {
                throw new ArgumentException(ERROR_CURRENT_PRODUCT_PAGE_INDEX_CANNOT_BE_SET_TO_NEGATIVE);
            }
            _currentProductPageIndex = value;
            NotifyObserverChangeCurrentProductPageIndex();
        }

        /// <summary>
        /// Notify observer change current product page index.
        /// </summary>
        private void NotifyObserverChangeCurrentProductPageIndex()
        {
            if ( CurrentProductPageIndexChanged != null )
            {
                CurrentProductPageIndexChanged();
            }
        }

        /// <summary>
        /// Go to previous product page.
        /// </summary>
        public void GoToPreviousProductPage()
        {
            SetCurrentProductPageIndexAndNotifyObserver(_currentProductPageIndex - 1);
            SelectNoProduct();
        }

        /// <summary>
        /// Go to next product page.
        /// </summary>
        public void GoToNextProductPage()
        {
            SetCurrentProductPageIndexAndNotifyObserver(_currentProductPageIndex + 1);
            SelectNoProduct();
        }

        /// <summary>
        /// Select the product tab page whose index is tabPageIndex.
        /// </summary>
        public void SelectProductTabPage(int tabPageIndex)
        {
            if ( tabPageIndex < 0 )
            {
                throw new ArgumentException(ERROR_CURRENT_TAB_PAGE_INDEX_CANNOT_BE_SET_TO_NEGATIVE);
            }
            _currentTabPageIndex = tabPageIndex;
            SetCurrentProductPageIndexAndNotifyObserver(CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE);
            SelectNoProduct();
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        private void SelectNoProduct()
        {
            SelectProduct(null);
        }

        /// <summary>
        /// Select product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _currentSelectedProduct = product;
            NotifyObserverChangeCurrentProductInfo();
            NotifyObserverChangeAddButtonEnabled();
        }

        /// <summary>
        /// Notify observer change current product info.
        /// </summary>
        private void NotifyObserverChangeCurrentProductInfo()
        {
            if ( CurrentProductInfoChanged != null )
            {
                CurrentProductInfoChanged();
            }
        }

        /// <summary>
        /// Get the current product storage quantity.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentProductStorageQuantity()
        {
            return _currentSelectedProduct == null ? "" : AppDefinition.PRODUCT_STORAGE_QUANTITY_TEXT + _currentSelectedProduct.GetStorageQuantity();
        }

        /// <summary>
        /// Get the current product name and description.
        /// </summary>
        public string GetCurrentProductNameAndDescription()
        {
            return _currentSelectedProduct == null ? "" : _currentSelectedProduct.GetProductNameAndDescription();
        }

        /// <summary>
        /// Get the current product price.
        /// </summary>
        public string GetCurrentProductPrice()
        {
            return _currentSelectedProduct == null ? "" : AppDefinition.PRODUCT_PRICE_TEXT + _currentSelectedProduct.GetPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
        }

        /// <summary>
        /// Get the page label text.
        /// </summary>
        public string GetPageLabelText()
        {
            return AppDefinition.PAGE_LABEL_TEXT + AppDefinition.GetHumanIndex(_currentProductPageIndex) + AppDefinition.PAGE_LABEL_DELIMITER + _model.GetTabPageProductPagesCount(_currentTabPageIndex);
        }

        /// <summary>
        /// Get the enabled state of the left arrow button.
        /// </summary>
        public bool IsLeftArrowButtonEnabled()
        {
            return _currentProductPageIndex != 0;
        }

        /// <summary>
        /// Get the enabled state of the right arrow button.
        /// </summary>
        public bool IsRightArrowButtonEnabled()
        {
            return _currentProductPageIndex != _model.GetTabPageProductPagesCount(_currentTabPageIndex) - 1;
        }

        /// <summary>
        /// Get the product at productIndex in the current product page, which is inside the tab page whose index is tabPageIndex.
        /// </summary>
        public Product GetProductAtCurrentProductPage(int tabPageIndex, int productIndex)
        {
            return _model.GetProduct(tabPageIndex, _currentProductPageIndex, productIndex);
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