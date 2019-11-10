using OrderAndStorageManagementSystem.Models.Utilities;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class ProductManagementPresentationModel
    {
        public delegate void CurrentSelectedProductChangedEventHandler();
        public CurrentSelectedProductChangedEventHandler CurrentSelectedProductChanged
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
        private Product _currentSelectedProduct;

        public ProductManagementPresentationModel()
        {
            _currentSelectedProduct = null;
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
    }
}
