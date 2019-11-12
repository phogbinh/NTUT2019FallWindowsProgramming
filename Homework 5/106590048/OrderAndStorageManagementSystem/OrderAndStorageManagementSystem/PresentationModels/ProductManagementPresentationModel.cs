using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;

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
        public delegate void SaveButtonEnabledChangedEventHandler();
        private delegate void IsValidProductInfoChangedEventHandler();
        private delegate void IsEditedProductInfoChangedEventHandler();
        private delegate void StateChangedEventHandler();
        public CurrentSelectedProductChangedEventHandler CurrentSelectedProductChanged
        {
            get; set;
        }
        public SaveButtonEnabledChangedEventHandler SaveButtonEnabledChanged
        {
            get; set;
        }
        private IsValidProductInfoChangedEventHandler IsValidProductInfoChanged
        {
            get; set;
        }
        private IsEditedProductInfoChangedEventHandler IsEditedProductInfoChanged
        {
            get; set;
        }
        private StateChangedEventHandler StateChanged
        {
            get; set;
        }
        private Model _model;
        private Product _currentSelectedProduct;
        private bool _isValidProductInfo;
        private bool _isEditedProductInfo;
        private State _state;

        public ProductManagementPresentationModel(Model modelData)
        {
            _model = modelData;
            this.CurrentSelectedProductChanged += NotifyObserverChangeSaveButtonEnabled;
            this.IsValidProductInfoChanged += NotifyObserverChangeSaveButtonEnabled;
            this.IsEditedProductInfoChanged += NotifyObserverChangeSaveButtonEnabled;
            this.StateChanged += NotifyObserverChangeSaveButtonEnabled;
            // Initial states
            SetCurrentSelectedProduct(null);
            SetIsValidProductInfo(false);
            SetIsEditedProductInfo(false);
            SetState(State.EditProduct);
        }

        /// <summary>
        /// Set current selected product to the given product.
        /// </summary>
        public void SetCurrentSelectedProduct(Product product)
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
        /// Notify observer change enabled state of save button.
        /// </summary>
        private void NotifyObserverChangeSaveButtonEnabled()
        {
            if ( SaveButtonEnabledChanged != null )
            {
                SaveButtonEnabledChanged();
            }
        }

        /// <summary>
        /// Get the enabled state of the save button.
        /// </summary>
        public bool GetSaveButtonEnabled()
        {
            return ( _state == State.EditProduct && _currentSelectedProduct != null && _isValidProductInfo && _isEditedProductInfo ) || ( _state == State.AddProduct && _isValidProductInfo );
        }

        /// <summary>
        /// Set _isValidProductInfo.
        /// </summary>
        public void SetIsValidProductInfo(bool value)
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
        /// Click save button.
        /// </summary>
        public void ClickSaveButton(Product newProductData)
        {
            if ( _state == State.EditProduct )
            {
                _model.UpdateProductInfo(_currentSelectedProduct, newProductData);
                SetIsEditedProductInfo(false);
            }
            else
            {
                _model.AddProduct(newProductData);
            }
        }

        /// <summary>
        /// Set _isEditedProductInfo.
        /// </summary>
        public void SetIsEditedProductInfo(bool value)
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
        public void SetState(State value)
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
