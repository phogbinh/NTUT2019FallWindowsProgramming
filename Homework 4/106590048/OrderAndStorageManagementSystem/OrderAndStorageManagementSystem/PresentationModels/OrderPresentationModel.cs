﻿using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels.Utilities;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class OrderPresentationModel
    {
        public delegate void AddButtonEnabledChangedEventHandler();
        public delegate void CurrentProductInfoChangedEventHandler();
        public AddButtonEnabledChangedEventHandler AddButtonEnabledChanged
        {
            get; set;
        }
        public CurrentProductInfoChangedEventHandler CurrentProductInfoChanged
        {
            get; set;
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
        private const int CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE = 0;
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

        ~OrderPresentationModel()
        {
            _model.OrderCleared -= UpdateAddButtonByCurrentSelectedProduct;
            _model.OrderAdded -= HandleModelOrderAdded;
            _model.OrderRemoved -= HandleModelOrderRemoved;
            _model.ProductStorageQuantityChanged -= UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity;
        }

        public OrderPresentationModel(Model modelData)
        {
            _model = modelData;
            _currentSelectedProduct = null;
            // Observers
            _model.OrderCleared += UpdateAddButtonByCurrentSelectedProduct;
            _model.OrderAdded += HandleModelOrderAdded;
            _model.OrderRemoved += HandleModelOrderRemoved;
            _model.ProductStorageQuantityChanged += UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity;
            _model.ProductInfoChanged += UpdateCurrentProductInfoIfChangedCurrentSelectedProductInfo;
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
                UpdateAddButtonByCurrentSelectedProduct();
            }
        }

        /// <summary>
        /// Update current product info and enabled state of add button if the storage quantity of the current selected product is changed.
        /// </summary>
        private void UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                UpdateCurrentProductInfo();
                UpdateAddButtonByCurrentSelectedProduct();
            }
        }

        /// <summary>
        /// Update enabled state of add button by current selected product.
        /// </summary>
        private void UpdateAddButtonByCurrentSelectedProduct()
        {
            _addButton.Enabled = _currentSelectedProduct != null && !_model.IsInOrder(_currentSelectedProduct.Id) && _currentSelectedProduct.StorageQuantity > 0;
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
        /// Update current product info if the current selected product info is changed.
        /// </summary>
        private void UpdateCurrentProductInfoIfChangedCurrentSelectedProductInfo(Product product)
        {
            if ( product == _currentSelectedProduct )
            {
                UpdateCurrentProductInfo();
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
            _pageLabel.Text = AppDefinition.PAGE_LABEL_TEXT + AppDefinition.GetHumanIndex(_currentProductPageIndex) + AppDefinition.PAGE_LABEL_DELIMITER + _model.GetTabPageProductPagesCount(_currentTabPageIndex);
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
            if ( humanIndex == _model.GetTabPageProductPagesCount(_currentTabPageIndex) )
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
            _productStorageQuantity.Text = _currentSelectedProduct == null ? "" : AppDefinition.PRODUCT_STORAGE_QUANTITY_TEXT + _currentSelectedProduct.GetStorageQuantity();
            _productNameAndDescription.Text = _currentSelectedProduct == null ? "" : _currentSelectedProduct.GetProductNameAndDescription();
            _productPrice.Text = _currentSelectedProduct == null ? "" : AppDefinition.PRODUCT_PRICE_TEXT + _currentSelectedProduct.GetPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
            NotifyObserverChangeCurrentProductInfo();
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