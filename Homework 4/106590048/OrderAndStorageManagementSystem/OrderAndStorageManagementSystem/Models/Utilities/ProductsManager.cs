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

        /// <summary>
        /// Decrease the storage quantity of all products in the order by theirs order quantity.
        /// </summary>
        public void DecreaseProductStorageQuantitiesByOrderQuantities(IDictionary<Product, int> productWithOrderQuantityContainers)
        {
            foreach ( KeyValuePair<Product, int> container in productWithOrderQuantityContainers )
            {
                Product product = container.Key;
                int productOrderQuantity = container.Value;
                product.StorageQuantity -= productOrderQuantity;
            }
        }

        /// <summary>
        /// Add the storage quantity of the product with the supplyQuantity.
        /// </summary>
        public void AddProductStorageQuantity(Product product, int supplyQuantity)
        {
            product.StorageQuantity = product.StorageQuantity + supplyQuantity;
        }
    }
}
