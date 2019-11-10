using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductsManager
    {
        public delegate void ProductStorageQuantityChangedEventHandler(Product product);
        public delegate void ProductInfoChangedEventHandler(Product product);
        public ProductStorageQuantityChangedEventHandler ProductStorageQuantityChanged
        {
            get; set;
        }
        public ProductInfoChangedEventHandler ProductInfoChanged
        {
            get; set;
        }
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        private const string ERROR_INVALID_PRODUCT_ID = "Product Id is invalid.";
        private List<Product> _products;

        public ProductsManager(List<Product> initialDataBaseProducts)
        {
            _products = initialDataBaseProducts;
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
                AddProductStorageQuantity(product, -productOrderQuantity);
            }
        }

        /// <summary>
        /// Add the storage quantity of the product with the additionalQuantity.
        /// </summary>
        public void AddProductStorageQuantity(Product product, int additionalQuantity)
        {
            product.StorageQuantity = product.StorageQuantity + additionalQuantity;
            NotifyObserverChangeProductStorageQuantity(product);
        }

        /// <summary>
        /// Notify observer change storage quantity of product.
        /// </summary>
        private void NotifyObserverChangeProductStorageQuantity(Product product)
        {
            if ( ProductStorageQuantityChanged != null )
            {
                ProductStorageQuantityChanged(product);
            }
        }

        /// <summary>
        /// Update product info according to the new product data.
        /// </summary>
        public void UpdateProductInfo(Product product, Product newProductData)
        {
            product.Name = newProductData.Name;
            product.Type = newProductData.Type;
            product.Price = newProductData.Price;
            product.Description = newProductData.Description;
            product.ImagePath = newProductData.ImagePath;
            NotifyObserverChangeProductInfo(product);
        }

        /// <summary>
        /// Notify observer change product info
        /// </summary>
        private void NotifyObserverChangeProductInfo(Product product)
        {
            if ( ProductInfoChanged != null )
            {
                ProductInfoChanged(product);
            }
        }
    }
}
