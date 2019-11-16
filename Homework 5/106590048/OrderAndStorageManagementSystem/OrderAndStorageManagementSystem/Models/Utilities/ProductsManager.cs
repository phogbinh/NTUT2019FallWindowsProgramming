using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductsManager
    {
        public delegate void ProductStorageQuantityChangedEventHandler(Product product);
        public delegate void ProductInfoChangedEventHandler(Product product);
        public delegate void ProductAddedEventHandler(Product product);
        public ProductStorageQuantityChangedEventHandler ProductStorageQuantityChanged
        {
            get; set;
        }
        public ProductInfoChangedEventHandler ProductInfoChanged
        {
            get; set;
        }
        public ProductAddedEventHandler ProductAdded
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
        private const string ERROR_INITIAL_DATA_BASE_PRODUCTS_IS_NULL = "The given initial database products is null.";
        private const string ERROR_PRODUCT_ID_IS_NOT_EXISTING = "The given product id is not existing.";
        private const string ERROR_PRODUCT_WITH_ORDER_QUANTITY_CONTAINERS_IS_NULL = "The given product-with-order-quantity-containers is null.";
        private const string ERROR_PRODUCT_IS_NULL = "The given product is null.";
        private List<Product> _products;

        public ProductsManager(List<Product> initialDataBaseProducts)
        {
            if ( initialDataBaseProducts == null )
            {
                throw new ArgumentNullException(ERROR_INITIAL_DATA_BASE_PRODUCTS_IS_NULL);
            }
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
            throw new ArgumentException(ERROR_PRODUCT_ID_IS_NOT_EXISTING);
        }

        /// <summary>
        /// Decrease the storage quantity of all products in the order by theirs order quantity.
        /// </summary>
        public void DecreaseProductStorageQuantitiesByOrderQuantities(IDictionary<Product, int> productWithOrderQuantityContainers)
        {
            if ( productWithOrderQuantityContainers == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCT_WITH_ORDER_QUANTITY_CONTAINERS_IS_NULL);
            }
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
            if ( product == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCT_IS_NULL);
            }
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
        /// Update the product info.
        /// </summary>
        public void UpdateProductInfo(Product product, ProductInfo newProductInfo)
        {
            if ( product == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCT_IS_NULL);
            }
            product.ProductInfo = newProductInfo;
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

        /// <summary>
        /// Add a new product.
        /// </summary>
        public void AddProduct(ProductInfo newProductInfo)
        {
            var product = new Product(_products.Count + 1, newProductInfo);
            _products.Add(product);
            NotifyObserverAddProduct(product);
        }

        /// <summary>
        /// Notify observer add product.
        /// </summary>
        private void NotifyObserverAddProduct(Product product)
        {
            if ( ProductAdded != null )
            {
                ProductAdded(product);
            }
        }
    }
}
