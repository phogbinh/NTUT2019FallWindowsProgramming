using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public enum ProductTypesManagementTabPageState
    {
        ViewProductType = 0,
        AddProductType
    }
    public class ProductTypesManagementTabPagePresentationModel
    {
        public delegate void CurrentSelectedProductTypeChangedEventHandler();
        public delegate void SubmitProductTypeInfoButtonEnabledChangedEventHandler();
        public delegate void ProductTypesManagementTabPageStateChangedEventHandler();
        public CurrentSelectedProductTypeChangedEventHandler CurrentSelectedProductTypeChanged
        {
            get; set;
        }
        public SubmitProductTypeInfoButtonEnabledChangedEventHandler SubmitProductTypeInfoButtonEnabledChanged
        {
            get; set;
        }
        public ProductTypesManagementTabPageStateChangedEventHandler ProductTypesManagementTabPageStateChanged
        {
            get; set;
        }
        private const string ERROR_MODEL_IS_NULL = "The given model is null.";
        private Model _model;
        private string _currentSelectedProductType;
        private ProductTypesManagementTabPageState _productTypesMangementTabPageState;

        public ProductTypesManagementTabPagePresentationModel(Model modelData)
        {
            if ( modelData == null )
            {
                throw new ArgumentNullException(ERROR_MODEL_IS_NULL);
            }
            _model = modelData;
            this.CurrentSelectedProductTypeChanged += NotifyObserverChangeSubmitProductTypeInfoButtonEnabled;
            this.ProductTypesManagementTabPageStateChanged += NotifyObserverChangeSubmitProductTypeInfoButtonEnabled;
            // Initial states of all member variables of the presentation model is set by its view.
        }

        /// <summary>
        /// Sets the current selected product type and notify observer.
        /// </summary>
        public void SetCurrentSelectedProductTypeAndNotifyObserver(string productType)
        {
            _currentSelectedProductType = productType;
            NotifyObserverChangeCurrentSelectedProductType();
        }

        /// <summary>
        /// Notifies the type of the observer change current selected product.
        /// </summary>
        private void NotifyObserverChangeCurrentSelectedProductType()
        {
            if ( CurrentSelectedProductTypeChanged != null )
            {
                CurrentSelectedProductTypeChanged();
            }
        }

        /// <summary>
        /// Notify observer change enabled state of submit product info button.
        /// </summary>
        private void NotifyObserverChangeSubmitProductTypeInfoButtonEnabled()
        {
            if ( SubmitProductTypeInfoButtonEnabledChanged != null )
            {
                SubmitProductTypeInfoButtonEnabledChanged();
            }
        }

        /// <summary>
        /// Determines whether [is submit product type information button enabled].
        /// </summary>
        public bool IsSubmitProductTypeInfoButtonEnabled()
        {
            return _productTypesMangementTabPageState == ProductTypesManagementTabPageState.AddProductType;
        }

        /// <summary>
        /// Clicks the submit product information button.
        /// </summary>
        public void ClickSubmitProductTypeInfoButton(string newProductType)
        {
            if ( _productTypesMangementTabPageState == ProductTypesManagementTabPageState.AddProductType )
            {
                _model.AddProductType(newProductType);
            }
        }

        /// <summary>
        /// Sets the product types management tab page state and notify observer.
        /// </summary>
        public void SetProductTypesManagementTabPageStateAndNotifyObserver(ProductTypesManagementTabPageState value)
        {
            _productTypesMangementTabPageState = value;
            NotifyObserverChangeProductTypesManagementTabPageState();
        }

        /// <summary>
        /// Notifies the state of the observer change product types management tab page.
        /// </summary>
        private void NotifyObserverChangeProductTypesManagementTabPageState()
        {
            if ( ProductTypesManagementTabPageStateChanged != null )
            {
                ProductTypesManagementTabPageStateChanged();
            }
        }

        /// <summary>
        /// Gets the name of the current selected product type.
        /// </summary>
        public string GetCurrentSelectedProductTypeName()
        {
            return _currentSelectedProductType == null ? "" : _currentSelectedProductType;
        }

        /// <summary>
        /// Gets the current selected product type products.
        /// </summary>
        public List<Product> GetCurrentSelectedProductTypeProducts()
        {
            return _currentSelectedProductType == null ? new List<Product>() : _model.GetProductTypeProducts(_currentSelectedProductType);
        }
    }
}
