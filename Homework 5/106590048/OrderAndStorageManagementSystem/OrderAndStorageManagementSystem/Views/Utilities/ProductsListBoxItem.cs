using OrderAndStorageManagementSystem.Models.Utilities;

namespace OrderAndStorageManagementSystem.Views.Utilities
{
    public class ProductsListBoxItem
    {
        public Product Product
        {
            get
            {
                return _product;
            }
        }
        private Product _product;

        public ProductsListBoxItem(Product productData)
        {
            _product = productData;
        }

        /// <summary>
        /// Return the name of the product.
        /// </summary>
        public override string ToString()
        {
            return _product.Name;
        }
    }
}
