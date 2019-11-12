using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels.Utilities;

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
        private State _state;

        public ProductManagementPresentationModel(Model modelData)
        {
            _model = modelData;
            this.CurrentSelectedProductChanged += UpdateSaveButton;
            this.IsValidProductInfoChanged += UpdateSaveButton;
            this.IsEditedProductInfoChanged += UpdateSaveButton;
            this.StateChanged += UpdateSaveButton;
            // UI
            _saveButton = new ControlStates();
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
        /// Update enabled state of the save button.
        /// </summary>
        private void UpdateSaveButton()
        {
            _saveButton.Enabled = ( _state == State.EditProduct && _currentSelectedProduct != null && _isValidProductInfo && _isEditedProductInfo ) || ( _state == State.AddProduct && _isValidProductInfo );
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
    }
}
