using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public enum State
    {
        EditProduct = 0,
        AddProduct
    }
    public class ProductManagementPresentationModel
    {
        public delegate void CurrentSelectedProductChangedEventHandler();
        public delegate void SubmitProductInfoButtonEnabledChangedEventHandler();
        public delegate void IsValidProductInfoChangedEventHandler();
        public delegate void IsEditedProductInfoChangedEventHandler();
        public delegate void StateChangedEventHandler();
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
        public StateChangedEventHandler StateChanged
        {
            get; set;
        }
        private const string ERROR_MODEL_IS_NULL = "The given model is null.";
        private Model _model;
        private Product _currentSelectedProduct;
        private bool _isValidProductInfo;
        private bool _isEditedProductInfo;
        private State _state;

        public ProductManagementPresentationModel(Model modelData)
        {
            if ( modelData == null )
            {
                throw new ArgumentNullException(ERROR_MODEL_IS_NULL);
            }
            _model = modelData;
            this.CurrentSelectedProductChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            this.IsValidProductInfoChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            this.IsEditedProductInfoChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
            this.StateChanged += NotifyObserverChangeSubmitProductInfoButtonEnabled;
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
            return ( _state == State.EditProduct && _currentSelectedProduct != null && _isValidProductInfo && _isEditedProductInfo ) || ( _state == State.AddProduct && _isValidProductInfo );
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
            if ( _state == State.EditProduct )
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
        /// Set _state.
        /// </summary>
        public void SetStateAndNotifyObserver(State value)
        {
            _state = value;
            NotifyObserverChangeState();
        }

        /// <summary>
        /// Notify observer change state.
        /// </summary>
        private void NotifyObserverChangeState()
        {
            if ( StateChanged != null )
            {
                StateChanged();
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
