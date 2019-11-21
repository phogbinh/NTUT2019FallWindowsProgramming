using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public enum ProductsManagementTabPageState
    {
        EditProduct = 0,
        AddProduct
    }
    public class ProductsManagementTabPagePresentationModel
    {
        public delegate void CurrentSelectedProductChangedEventHandler();
        public delegate void SubmitProductInfoButtonEnabledChangedEventHandler();
        public delegate void IsValidProductInfoChangedEventHandler();
        public delegate void IsEditedProductInfoChangedEventHandler();
        public delegate void ProductsManagementTabPageStateChangedEventHandler();
        public CurrentSelectedProductChangedEventHandler CurrentSelectedProductChanged
        {
            get; set;
        }
        public SubmitProductInfoButtonEnabledChangedEventHandler SubmitProductInfoButtonEnabledChanged
        {
            get; set;
        }
        public IsValidProductInfoChangedEventHandler IsValidProductInfoChanged
        {
            get; set;
        }
        public IsEditedProductInfoChangedEventHandler IsEditedProductInfoChanged
        {
            get; set;
        }
        public ProductsManagementTabPageStateChangedEventHandler ProductsManagementTabPageStateChanged
        {
            get; set;
        }
        private Model _model;
        private Product _currentSelectedProduct;
        private bool _isValidProductInfo;
        private bool _isEditedProductInfo;
        private ProductsManagementTabPageState _productsManagementTabPageState;

        public ProductsManagementTabPagePresentationModel(Model modelData)
        {
            if ( modelData == null )
            {
                throw new ArgumentNullException(AppDefinition.ERROR_MODEL_IS_NULL);
            }
            _model = modelData;
            this.CurrentSelectedProductChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            this.IsValidProductInfoChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            this.IsEditedProductInfoChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            this.ProductsManagementTabPageStateChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            // Initial states of all member variables of the presentation model is set by its view.
        }

        /// <summary>
        /// Set current selected product to the given product.
        /// </summary>
        public void SetCurrentSelectedProductAndNotifyObserver(Product product)
        {
            _currentSelectedProduct = product;
            NotifyObserverChangeCurrentSelectedProduct();
        }

        /// <summary>
        /// Notify observer change current selected product.
        /// </summary>
        private void NotifyObserverChangeCurrentSelectedProduct()
        {
            if ( CurrentSelectedProductChanged != null )
            {
                CurrentSelectedProductChanged();
            }
        }

        /// <summary>
        /// Notify observer change enabled state of submit product info button.
        /// </summary>
        private void NotifyObserverChangeSubmitProductInfoButtonEnabled()
        {
            if ( SubmitProductInfoButtonEnabledChanged != null )
            {
                SubmitProductInfoButtonEnabledChanged();
            }
        }

        /// <summary>
        /// Get the enabled state of the submit product info button.
        /// </summary>
        public bool IsSubmitProductInfoButtonEnabled()
        {
            return ( _productsManagementTabPageState == ProductsManagementTabPageState.EditProduct && _currentSelectedProduct != null && _isValidProductInfo && _isEditedProductInfo ) || ( _productsManagementTabPageState == ProductsManagementTabPageState.AddProduct && _isValidProductInfo );
        }

        /// <summary>
        /// Set _isValidProductInfo.
        /// </summary>
        public void SetIsValidProductInfoAndNotifyObserver(bool value)
        {
            _isValidProductInfo = value;
            NotifyObserverChangeIsValidProductInfo();
        }

        /// <summary>
        /// Notify observer change _isValidProductInfo.
        /// </summary>
        private void NotifyObserverChangeIsValidProductInfo()
        {
            if ( IsValidProductInfoChanged != null )
            {
                IsValidProductInfoChanged();
            }
        }

        /// <summary>
        /// Click the submit product info button.
        /// </summary>
        public void ClickSubmitProductInfoButton(ProductInfo newProductInfo)
        {
            if ( _productsManagementTabPageState == ProductsManagementTabPageState.EditProduct )
            {
                _model.UpdateProductInfo(_currentSelectedProduct, newProductInfo);
                SetIsEditedProductInfoAndNotifyObserver(false);
            }
            else
            {
                _model.AddProduct(newProductInfo);
            }
        }

        /// <summary>
        /// Set _isEditedProductInfo.
        /// </summary>
        public void SetIsEditedProductInfoAndNotifyObserver(bool value)
        {
            _isEditedProductInfo = value;
            NotifyObserverChangeIsEditedProductInfo();
        }

        /// <summary>
        /// Notify observer change _isEditedProductInfo.
        /// </summary>
        private void NotifyObserverChangeIsEditedProductInfo()
        {
            if ( IsEditedProductInfoChanged != null )
            {
                IsEditedProductInfoChanged();
            }
        }

        /// <summary>
        /// Sets the products management tab page state and notify observer.
        /// </summary>
        public void SetProductsManagementTabPageStateAndNotifyObserver(ProductsManagementTabPageState value)
        {
            _productsManagementTabPageState = value;
            NotifyObserverChangeProductsManagementTabPageState();
        }

        /// <summary>
        /// Notifies the state of the observer change products management tab page.
        /// </summary>
        private void NotifyObserverChangeProductsManagementTabPageState()
        {
            if ( ProductsManagementTabPageStateChanged != null )
            {
                ProductsManagementTabPageStateChanged();
            }
        }

        /// <summary>
        /// Get current selected product name.
        /// </summary>
        public string GetCurrentSelectedProductName()
        {
            return _currentSelectedProduct == null ? "" : _currentSelectedProduct.Name;
        }

        /// <summary>
        /// Get current selected product price.
        /// </summary>
        public string GetCurrentSelectedProductPrice()
        {
            return _currentSelectedProduct == null ? "" : _currentSelectedProduct.Price.GetString();
        }

        /// <summary>
        /// Get current selected product type.
        /// </summary>
        public string GetCurrentSelectedProductType()
        {
            return _currentSelectedProduct == null ? "" : _currentSelectedProduct.Type;
        }

        /// <summary>
        /// Get current selected product image path.
        /// </summary>
        public string GetCurrentSelectedProductImagePath()
        {
            return _currentSelectedProduct == null ? "" : _currentSelectedProduct.ImagePath;
        }

        /// <summary>
        /// Get current selected product description.
        /// </summary>
        public string GetCurrentSelectedProductDescription()
        {
            return _currentSelectedProduct == null ? "" : _currentSelectedProduct.Description;
        }
    }
}
