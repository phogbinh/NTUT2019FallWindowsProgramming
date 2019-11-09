using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductsManager
    {
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        private const string ERROR_INVALID_PRODUCT_ID = "Product Id is invalid.";
        private List<Product> _products;

        public ProductsManager()
        {
            _products = DataBaseManager.GetProductsFromProductTable();
        }

        /// <summary>
        /// Get product by productId.
        /// </summary>
        public Product GetProduct(int productId)
        {
            foreach ( Product product in Products )
            {
                if ( product.Id == productId )
                {
                    return product;
                }
            }
            throw new ArgumentException(ERROR_INVALID_PRODUCT_ID);
        }
    }
}
