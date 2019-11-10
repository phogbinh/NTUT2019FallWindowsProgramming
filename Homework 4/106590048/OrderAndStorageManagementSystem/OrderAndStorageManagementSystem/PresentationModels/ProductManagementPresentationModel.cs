using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels.Utilities;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class ProductManagementPresentationModel
    {
        public delegate void CurrentSelectedProductChangedEventHandler();
        public delegate void SaveButtonEnabledChangedEventHandler();
        private delegate void IsValidProductInfoChangedEventHandler();
        private delegate void IsEditedProductInfoChangedEventHandler();
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
        public Product CurrentSelectedProduct
        {
            get
            {
                return _currentSelectedProduct;
            }
        }
        public ControlStates SaveButton
        {
            get
            {
                return _saveButton;
            }
        }
        private Model _model;
        private Product _currentSelectedProduct;
        private ControlStates _saveButton;
        private bool _isValidProductInfo;
        private bool _isEditedProductInfo;

        public ProductManagementPresentationModel(Model modelData)
        {
            _model = modelData;
            this.CurrentSelectedProductChanged += UpdateSaveButton;
            this.IsValidProductInfoChanged += UpdateSaveButton;
            this.IsEditedProductInfoChanged += UpdateSaveButton;
            // UI
            _saveButton = new ControlStates();
            // Initial states
            SetCurrentSelectedProduct(null);
            SetIsValidProductInfo(false);
            SetIsEditedProductInfo(false);
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
        /// Update enabled state of the save button.
        /// </summary>
        private void UpdateSaveButton()
        {
            _saveButton.Enabled = _currentSelectedProduct != null && _isValidProductInfo && _isEditedProductInfo;
            NotifyObserverChangeSaveButtonEnabled();
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
        /// Update current product info with the given parameters.
        /// </summary>
        public void UpdateCurrentSelectedProductInfo(Product newProductData)
        {
            _model.UpdateProductInfo(_currentSelectedProduct, newProductData);
        }
    }
}
