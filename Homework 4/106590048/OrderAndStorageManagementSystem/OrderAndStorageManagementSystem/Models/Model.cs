using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models
{
    public class Model
    {
        public delegate void ProductStorageQuantityChangedEventHandler(Product product);
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
        public ProductStorageQuantityChangedEventHandler ProductStorageQuantityChanged
        {
            get; set;
        }
        public List<Product> Products
        {
            get
            {
                return _productsManager.Products;
            }
        }
        private ProductsManager _productsManager;
        private Order _order;

        public Model()
        {
            _productsManager = new ProductsManager();
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
            DecreaseProductStorageQuantitiesByOrderQuantities();
            ClearOrder();
        }

        /// <summary>
        /// Decrease the storage quantity of all order items by theirs order quantity.
        /// </summary>
        private void DecreaseProductStorageQuantitiesByOrderQuantities()
        {
            _productsManager.DecreaseProductStorageQuantitiesByOrderQuantities(_order.GetProductWithOrderQuantityContainers());
            foreach ( Product product in _order.GetProducts() )
            {
                NotifyObserverChangeProductStorageQuantity(product);
            }
        }

        /// <summary>
        /// Clear the order.
        /// </summary>
        private void ClearOrder()
        {
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
        /// Get all the order items in the order.
        /// </summary>
        public List<OrderItem> GetOrderItems()
        {
            return _order.GetOrderItems();
        }
    }
}
