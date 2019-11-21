using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models
{
    public class Model
    {
        public Order.OrderChangedEventHandler OrderChanged
        {
            get
            {
                return _order.OrderChanged;
            }
            set
            {
                _order.OrderChanged = value;
            }
        }
        public Order.OrderClearedEventHandler OrderCleared
        {
            get
            {
                return _order.OrderCleared;
            }
            set
            {
                _order.OrderCleared = value;
            }
        }
        public Order.OrderAddedEventHandler OrderAdded
        {
            get
            {
                return _order.OrderAdded;
            }
            set
            {
                _order.OrderAdded = value;
            }
        }
        public Order.OrderRemovedEventHandler OrderRemoved
        {
            get
            {
                return _order.OrderRemoved;
            }
            set
            {
                _order.OrderRemoved = value;
            }
        }
        public Order.OrderItemQuantityChangedEventHandler OrderItemQuantityChanged
        {
            get
            {
                return _order.OrderItemQuantityChanged;
            }
            set
            {
                _order.OrderItemQuantityChanged = value;
            }
        }
        public Order.OrderItemQuantityIsExceededStorageQuantityEventHandler OrderItemQuantityIsExceededStorageQuantity
        {
            get
            {
                return _order.OrderItemQuantityIsExceededStorageQuantity;
            }
            set
            {
                _order.OrderItemQuantityIsExceededStorageQuantity = value;
            }
        }
        public ProductsManager.ProductStorageQuantityChangedEventHandler ProductStorageQuantityChanged
        {
            get
            {
                return _productsManager.ProductStorageQuantityChanged;
            }
            set
            {
                _productsManager.ProductStorageQuantityChanged = value;
            }
        }
        public ProductsManager.ProductInfoChangedEventHandler ProductInfoChanged
        {
            get
            {
                return _productsManager.ProductInfoChanged;
            }
            set
            {
                _productsManager.ProductInfoChanged = value;
            }
        }
        public ProductsManager.ProductAddedEventHandler ProductAdded
        {
            get
            {
                return _productsManager.ProductAdded;
            }
            set
            {
                _productsManager.ProductAdded = value;
            }
        }
        public ProductTypesManager.ProductTypeAddedEventHandler ProductTypeAdded
        {
            get
            {
                return _productTypesManager.ProductTypeAdded;
            }
            set
            {
                _productTypesManager.ProductTypeAdded = value;
            }
        }
        public List<Product> Products
        {
            get
            {
                return _productsManager.Products;
            }
        }
        private ProductsManager _productsManager;
        private ProductTypesManager _productTypesManager;
        private ProductsAndProductTypesManager _productsAndProductTypesManager;
        private Order _order;

        public Model(string input)
        {
            List<Product> initialDataBaseProducts = DataBaseManager.GetProductsFromFile(input);
            _productsManager = new ProductsManager(initialDataBaseProducts);
            _productTypesManager = new ProductTypesManager(initialDataBaseProducts);
            _productsAndProductTypesManager = new ProductsAndProductTypesManager(_productsManager, _productTypesManager);
            _order = new Order();
        }

        /// <summary>
        /// Add the product to order if the product is not in order.
        /// </summary>
        public void AddProductToOrderIfProductIsNotInOrder(Product product)
        {
            _order.AddProductToOrderIfProductIsNotInOrder(product);
        }

        /// <summary>
        /// Return true if the given productId is in order.
        /// </summary>
        public bool IsInOrder(int productId)
        {
            return _order.IsInOrder(productId);
        }

        /// <summary>
        /// Get the order total price.
        /// </summary>
        public string GetOrderTotalPrice()
        {
            return _order.GetTotalPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
        }

        /// <summary>
        /// Remove the order item at orderItemIndex from the order.
        /// </summary>
        public void RemoveOrderItemAt(int orderItemIndex)
        {
            _order.RemoveOrderItemAt(orderItemIndex);
        }

        /// <summary>
        /// Get the number of order items in the order.
        /// </summary>
        public int GetOrderItemsCount()
        {
            return _order.GetOrderItemsCount();
        }

        /// <summary>
        /// Set the order quantity of the order item whose index is orderItemIndex to newCartProductQuantity.
        /// </summary>
        public void SetOrderItemQuantity(int orderItemIndex, int newCartProductQuantity)
        {
            _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(orderItemIndex, newCartProductQuantity);
        }

        /// <summary>
        /// Submit the order.
        /// </summary>
        public void SubmitOrder()
        {
            _productsManager.DecreaseProductStorageQuantitiesByOrderQuantities(_order.GetProductWithOrderQuantityContainers());
            _order.ClearOrder();
        }

        /// <summary>
        /// Get product by productId.
        /// </summary>
        public Product GetProduct(int productId)
        {
            return _productsManager.GetProduct(productId);
        }

        /// <summary>
        /// Add the storage quantity of the product with the supplyQuantity.
        /// </summary>
        public void SupplyProductStorageQuantity(Product product, int supplyQuantity)
        {
            _productsManager.AddProductStorageQuantity(product, supplyQuantity);
        }

        /// <summary>
        /// Get all the order items in the order.
        /// </summary>
        public List<OrderItem> GetOrderItems()
        {
            return _order.GetOrderItems();
        }

        /// <summary>
        /// Get the total number of product types.
        /// </summary>
        public int GetProductTypesCount()
        {
            return GetProductTypes().Count;
        }

        /// <summary>
        /// Get all product types.
        /// </summary>
        public List<string> GetProductTypes()
        {
            return _productTypesManager.ProductTypes;
        }

        /// <summary>
        /// Get the number of product pages of the tab page whose index is tabPageIndex.
        /// </summary>
        public int GetTabPageProductPagesCount(int tabPageIndex)
        {
            return _productsAndProductTypesManager.GetProductTypeProductPagesCount(_productTypesManager.GetProductType(tabPageIndex));
        }

        /// <summary>
        /// Get the product at productIndex in the product page of productPageIndex, which is inside the tab page whose index is tabPageIndex.
        /// </summary>
        public Product GetProduct(int tabPageIndex, int productPageIndex, int productIndex)
        {
            return _productsAndProductTypesManager.GetProduct(_productTypesManager.GetProductType(tabPageIndex), productPageIndex, productIndex);
        }

        /// <summary>
        /// Update the product info.
        /// </summary>
        public void UpdateProductInfo(Product product, ProductInfo newProductInfo)
        {
            _productsManager.UpdateProductInfo(product, newProductInfo);
        }

        /// <summary>
        /// Get order item at orderItemIndex.
        /// </summary>
        public OrderItem GetOrderItemAt(int orderItemIndex)
        {
            return _order.GetOrderItemAt(orderItemIndex);
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        public void AddProduct(ProductInfo newProductInfo)
        {
            _productsManager.AddProduct(newProductInfo);
        }

        /// <summary>
        /// Gets the product type products.
        /// </summary>
        public List<Product> GetProductTypeProducts(string productType)
        {
            return _productsAndProductTypesManager.GetProductTypeProducts(productType);
        }

        /// <summary>
        /// Adds the type of the product.
        /// </summary>
        public void AddProductType(string productType)
        {
            _productTypesManager.AddProductType(productType);
        }

        /// <summary>
        /// Gets the product at.
        /// </summary>
        public Product GetProductAt(int productIndex)
        {
            return _productsManager.GetProductAt(productIndex);
        }
    }
}
