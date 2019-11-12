﻿using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;

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
            _model = modelData;
            // Observers
            _model.OrderCleared += NotifyObserverChangeAddButtonEnabled;
            _model.OrderAdded += HandleModelOrderAdded;
            _model.OrderRemoved += HandleModelOrderRemoved;
            _model.ProductStorageQuantityChanged += UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity;
            // Initial States
            _currentSelectedProduct = null;
            _currentTabPageIndex = 0;
            SetCurrentProductPageIndex(CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE);
        }

        /// <summary>
        /// Handle the event OrderAdded of model.
        /// </summary>
        private void HandleModelOrderAdded(OrderItem orderItem)
        {
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
        public bool GetAddButtonEnabled()
        {
            return _currentSelectedProduct != null && !_model.IsInOrder(_currentSelectedProduct.Id) && _currentSelectedProduct.StorageQuantity > 0;
        }

        /// <summary>
        /// Set current product page index.
        /// </summary>
        private void SetCurrentProductPageIndex(int value)
        {
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
            SetCurrentProductPageIndex(_currentProductPageIndex - 1);
            SelectNoProduct();
        }

        /// <summary>
        /// Go to next product page.
        /// </summary>
        public void GoToNextProductPage()
        {
            SetCurrentProductPageIndex(_currentProductPageIndex + 1);
            SelectNoProduct();
        }

        /// <summary>
        /// Select the product tab page whose index is tabPageIndex.
        /// </summary>
        public void SelectProductTabPage(int tabPageIndex)
        {
            _currentTabPageIndex = tabPageIndex;
            SetCurrentProductPageIndex(CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE);
            SelectNoProduct();
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        private void SelectNoProduct()
        {
            _currentSelectedProduct = null;
            NotifyObserverChangeCurrentProductInfo();
            NotifyObserverChangeAddButtonEnabled();
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
        public bool GetLeftArrowButtonEnabled()
        {
            return _currentProductPageIndex != 0;
        }

        /// <summary>
        /// Get the enabled state of the right arrow button.
        /// </summary>
        public bool GetRightArrowButtonEnabled()
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