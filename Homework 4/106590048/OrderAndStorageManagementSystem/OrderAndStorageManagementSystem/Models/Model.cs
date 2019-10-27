using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models
{
    public class Model
    {
        public delegate void OrderChangedEventHandler();
        private event OrderChangedEventHandler _orderChanged;
        public delegate void OrderClearedEventHandler();
        private event OrderClearedEventHandler _orderCleared;
        public delegate void OrderAddedEventHandler(OrderItem orderItem);
        private event OrderAddedEventHandler _orderAdded;
        public delegate void OrderRemovedEventHandler(int orderItemIndex, Product removedProduct);
        private event OrderRemovedEventHandler _orderRemoved;
        public delegate void OrderItemQuantityChangedEventHandler(int orderItemIndex, string orderItemTotalPrice);
        private event OrderItemQuantityChangedEventHandler _orderItemQuantityChanged;
        public delegate void OrderItemQuantityIsExceededStorageQuantityEventHandler(int orderItemIndex, int storageQuantity);
        private event OrderItemQuantityIsExceededStorageQuantityEventHandler _orderItemQuantityIsExceededStorageQuantity;
        public delegate void ProductStorageQuantityChangedEventHandler(Product product);
        private event ProductStorageQuantityChangedEventHandler _productStorageQuantityChanged;
        public OrderChangedEventHandler OrderChanged
        {
            get
            {
                return _orderChanged;
            }
            set
            {
                _orderChanged = value;
            }
        }
        public OrderClearedEventHandler OrderCleared
        {
            get
            {
                return _orderCleared;
            }
            set
            {
                _orderCleared = value;
            }
        }
        public OrderAddedEventHandler OrderAdded
        {
            get
            {
                return _orderAdded;
            }
            set
            {
                _orderAdded = value;
            }
        }
        public OrderRemovedEventHandler OrderRemoved
        {
            get
            {
                return _orderRemoved;
            }
            set
            {
                _orderRemoved = value;
            }
        }
        public OrderItemQuantityChangedEventHandler OrderItemQuantityChanged
        {
            get
            {
                return _orderItemQuantityChanged;
            }
            set
            {
                _orderItemQuantityChanged = value;
            }
        }
        public OrderItemQuantityIsExceededStorageQuantityEventHandler OrderItemQuantityIsExceededStorageQuantity
        {
            get
            {
                return _orderItemQuantityIsExceededStorageQuantity;
            }
            set
            {
                _orderItemQuantityIsExceededStorageQuantity = value;
            }
        }
        public ProductStorageQuantityChangedEventHandler ProductStorageQuantityChanged
        {
            get
            {
                return _productStorageQuantityChanged;
            }
            set
            {
                _productStorageQuantityChanged = value;
            }
        }
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public Order Order
        {
            get
            {
                return _order;
            }
        }
        private const string ERROR_INVALID_PRODUCT_ID = "Product Id is invalid.";
        private List<Product> _products;
        private Order _order;

        public Model()
        {
            _products = DataBaseManager.GetProductsFromProductTable();
            _order = new Order();
        }

        /// <summary>
        /// Add the product to order if the product is not in order.
        /// </summary>
        public void AddProductToOrderIfProductIsNotInOrder(Product product)
        {
            var orderItem = new OrderItem(product);
            if ( !IsInOrder(orderItem) )
            {
                _order.AddOrderItem(orderItem);
                NotifyObserverChangeAndAddOrder(orderItem);
            }
        }

        /// <summary>
        /// Return true if the orderItem is in order.
        /// </summary>
        public bool IsInOrder(OrderItem orderItem)
        {
            return _order.IsInOrder(orderItem.Id);
        }

        /// <summary>
        /// Notify observer change and add order.
        /// </summary>
        private void NotifyObserverChangeAndAddOrder(OrderItem orderItem)
        {
            NotifyObserverChangeOrder();
            if ( OrderAdded != null )
                OrderAdded(orderItem);
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
            Product removeProduct = _order.GetProduct(orderItemIndex);
            _order.RemoveOrderItemAt(orderItemIndex);
            NotifyObserverChangeAndRemoveOrder(orderItemIndex, removeProduct);
        }

        /// <summary>
        /// Notify observer change and remove order.
        /// </summary>
        private void NotifyObserverChangeAndRemoveOrder(int orderItemIndex, Product removedProduct)
        {
            NotifyObserverChangeOrder();
            if ( OrderRemoved != null )
                OrderRemoved(orderItemIndex, removedProduct);
        }

        /// <summary>
        /// Notify observer change order.
        /// </summary>
        private void NotifyObserverChangeOrder()
        {
            if ( OrderChanged != null )
                OrderChanged();
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
            if ( !IsExceededStorageQuantity(orderItemIndex, newCartProductQuantity) )
            {
                _order.SetOrderItemQuantity(orderItemIndex, newCartProductQuantity);
                NotifyObserverChangeOrderItemQuantity(orderItemIndex, GetOrderItemTotalPrice(orderItemIndex));
            }
            else
            {
                _order.SetOrderItemQuantityToStorageQuantity(orderItemIndex);
                NotifyObserverOrderItemQuantityIsExceededStorageQuantity(orderItemIndex, _order.GetStorageQuantity(orderItemIndex));
            }
        }

        /// <summary>
        /// Return true if the given quantity is bigger than the storage quantity of the order item at orderItemIndex.
        /// </summary>
        private bool IsExceededStorageQuantity(int orderItemIndex, int quantity)
        {
            return _order.IsExceededStorageQuantity(orderItemIndex, quantity);
        }

        /// <summary>
        /// Notify observer change order quantity of order item.
        /// </summary>
        private void NotifyObserverChangeOrderItemQuantity(int orderItemIndex, string orderItemTotalPrice)
        {
            NotifyObserverChangeOrder();
            if ( OrderItemQuantityChanged != null )
                OrderItemQuantityChanged(orderItemIndex, orderItemTotalPrice);
        }

        /// <summary>
        /// Notify observer order quantity of order item is exceeded its storage quantity.
        /// </summary>
        private void NotifyObserverOrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int storageQuantity)
        {
            if ( OrderItemQuantityIsExceededStorageQuantity != null )
                OrderItemQuantityIsExceededStorageQuantity(orderItemIndex, storageQuantity);
        }

        /// <summary>
        /// Get the total price of the order item whose index is orderItemIndex.
        /// </summary>
        private string GetOrderItemTotalPrice(int orderItemIndex)
        {
            return _order.GetOrderItemTotalPrice(orderItemIndex);
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
            _order.DecreaseProductStorageQuantitiesByOrderQuantities();
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
            NotifyObserverChangeAndClearOrder();
        }

        /// <summary>
        /// Notify observer change and clear order.
        /// </summary>
        private void NotifyObserverChangeAndClearOrder()
        {
            NotifyObserverChangeOrder();
            if ( OrderCleared != null )
                OrderCleared();
        }

        /// <summary>
        /// Get product by productId.
        /// </summary>
        public Product GetProduct(int productId)
        {
            foreach ( Product product in _products )
            {
                if ( product.Id == productId )
                {
                    return product;
                }
            }
            throw new ArgumentException(ERROR_INVALID_PRODUCT_ID);
        }

        /// <summary>
        /// Add the storage quantity of the product with the supplyQuantity.
        /// </summary>
        public void SupplyProductStorageQuantity(Product product, int supplyQuantity)
        {
            product.StorageQuantity = product.StorageQuantity + supplyQuantity;
            NotifyObserverChangeProductStorageQuantity(product);
        }

        /// <summary>
        /// Notify observer change storage quantity of product.
        /// </summary>
        private void NotifyObserverChangeProductStorageQuantity(Product product)
        {
            if ( ProductStorageQuantityChanged != null )
                ProductStorageQuantityChanged(product);
        }
    }
}
