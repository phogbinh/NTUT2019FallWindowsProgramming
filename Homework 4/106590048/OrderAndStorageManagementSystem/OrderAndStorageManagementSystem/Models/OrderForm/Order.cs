using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class Order
    {
        public delegate void OrderChangedEventHandler();
        public delegate void OrderClearedEventHandler();
        public delegate void OrderAddedEventHandler(OrderItem orderItem);
        public delegate void OrderRemovedEventHandler(int orderItemIndex, Product removedProduct);
        public delegate void OrderItemQuantityChangedEventHandler(int orderItemIndex, string orderItemTotalPrice);
        public delegate void OrderItemQuantityIsExceededStorageQuantityEventHandler(int orderItemIndex, int storageQuantity);
        public OrderChangedEventHandler OrderChanged
        {
            get; set;
        }
        public OrderClearedEventHandler OrderCleared
        {
            get; set;
        }
        public OrderAddedEventHandler OrderAdded
        {
            get; set;
        }
        public OrderRemovedEventHandler OrderRemoved
        {
            get; set;
        }
        public OrderItemQuantityChangedEventHandler OrderItemQuantityChanged
        {
            get; set;
        }
        public OrderItemQuantityIsExceededStorageQuantityEventHandler OrderItemQuantityIsExceededStorageQuantity
        {
            get; set;
        }
        private const int TOTAL_PRICE_INITIAL_VALUE = 0;

        private List<OrderItem> _orderItems;

        public Order()
        {
            _orderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Get the total price of the order.
        /// </summary>
        public string GetTotalPrice(string currencyUnit)
        {
            Money totalPrice = new Money(TOTAL_PRICE_INITIAL_VALUE);
            foreach ( OrderItem orderItem in _orderItems )
            {
                totalPrice.Add(orderItem.GetTotalPrice());
            }
            return totalPrice.GetCurrencyFormatWithCurrencyUnit(currencyUnit);
        }

        /// <summary>
        /// Add the product to order if the product is not in order.
        /// </summary>
        public void AddProductToOrderIfProductIsNotInOrder(Product product)
        {
            if ( !IsInOrder(product.Id) )
            {
                AddOrderItem(new OrderItem(product));
            }
        }

        /// <summary>
        /// Return true if the productId matches that of an order item in the order.
        /// </summary>
        public bool IsInOrder(int productId)
        {
            foreach ( OrderItem item in _orderItems )
            {
                if ( item.Id == productId )
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Add an order item to the order.
        /// </summary>
        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
            NotifyObserverChangeOrderAndAddOrder(orderItem);
        }

        /// <summary>
        /// Notify observer change order and add order.
        /// </summary>
        private void NotifyObserverChangeOrderAndAddOrder(OrderItem orderItem)
        {
            NotifyObserverChangeOrder();
            NotifyObserverAddOrder(orderItem);
        }

        /// <summary>
        /// Notify observer change order.
        /// </summary>
        private void NotifyObserverChangeOrder()
        {
            if ( OrderChanged != null )
            {
                OrderChanged();
            }
        }

        /// <summary>
        /// Notify observer add order.
        /// </summary>
        private void NotifyObserverAddOrder(OrderItem orderItem)
        {
            if ( OrderAdded != null )
            {
                OrderAdded(orderItem);
            }
        }

        /// <summary>
        /// Remove an order item from the order at orderItemIndex.
        /// </summary>
        public void RemoveOrderItemAt(int orderItemIndex)
        {
            Product removeProduct = GetProduct(orderItemIndex);
            _orderItems.RemoveAt(orderItemIndex);
            NotifyObserverChangeOrderAndRemoveOrder(orderItemIndex, removeProduct);
        }

        /// <summary>
        /// Get the corresponding product of the order item at orderItemIndex.
        /// </summary>
        private Product GetProduct(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].Product;
        }

        /// <summary>
        /// Notify observer change order and remove order.
        /// </summary>
        private void NotifyObserverChangeOrderAndRemoveOrder(int orderItemIndex, Product removedProduct)
        {
            NotifyObserverChangeOrder();
            NotifyObserverRemoveOrder(orderItemIndex, removedProduct);
        }

        /// <summary>
        /// Notify observer remove order.
        /// </summary>
        private void NotifyObserverRemoveOrder(int orderItemIndex, Product removedProduct)
        {
            if ( OrderRemoved != null )
            {
                OrderRemoved(orderItemIndex, removedProduct);
            }
        }

        /// <summary>
        /// Get the number of order items in the order.
        /// </summary>
        public int GetOrderItemsCount()
        {
            return _orderItems.Count;
        }

        /// <summary>
        /// Clear all order items in the order.
        /// </summary>
        public void ClearOrder()
        {
            _orderItems.Clear();
            NotifyObserverChangeOrderAndClearOrder();
        }

        /// <summary>
        /// Notify observer change order and clear order.
        /// </summary>
        private void NotifyObserverChangeOrderAndClearOrder()
        {
            NotifyObserverChangeOrder();
            NotifyObserverClearOrder();
        }

        /// <summary>
        /// Notify observer clear order.
        /// </summary>
        private void NotifyObserverClearOrder()
        {
            if ( OrderCleared != null )
            {
                OrderCleared();
            }
        }

        /// <summary>
        /// Set the order quantity of the order item whose index is orderItemIndex to min( newCartProductQuantity, order item storage quantity ).
        /// </summary>
        public void SetOrderItemQuantityNotExceedingStorageQuantity(int orderItemIndex, int newCartProductQuantity)
        {
            if ( !IsExceededStorageQuantity(orderItemIndex, newCartProductQuantity) )
            {
                SetOrderItemQuantity(orderItemIndex, newCartProductQuantity);
            }
            else
            {
                SetOrderItemQuantityToStorageQuantity(orderItemIndex);
            }
        }

        /// <summary>
        /// Return true if the given quantity is bigger than the storage quantity of the order item at orderItemIndex.
        /// </summary>
        private bool IsExceededStorageQuantity(int orderItemIndex, int quantity)
        {
            return quantity > _orderItems[ orderItemIndex ].StorageQuantity;
        }

        /// <summary>
        /// Set the order quantity of the order item at orderItemIndex to newOrderQuantity.
        /// </summary>
        private void SetOrderItemQuantity(int orderItemIndex, int newOrderQuantity)
        {
            _orderItems[ orderItemIndex ].OrderQuantity = newOrderQuantity;
            NotifyObserverChangeOrderAndChangeOrderItemQuantity(orderItemIndex, GetOrderItemTotalPrice(orderItemIndex));
        }

        /// <summary>
        /// Get the total price of the order item at orderItemIndex.
        /// </summary>
        private string GetOrderItemTotalPrice(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].GetTotalPrice().GetCurrencyFormat();
        }

        /// <summary>
        /// Notify observer change order and change order item quantity.
        /// </summary>
        private void NotifyObserverChangeOrderAndChangeOrderItemQuantity(int orderItemIndex, string orderItemTotalPrice)
        {
            NotifyObserverChangeOrder();
            NotifyObserverChangeOrderItemQuantity(orderItemIndex, orderItemTotalPrice);
        }

        /// <summary>
        /// Notify observer change order quantity of order item.
        /// </summary>
        private void NotifyObserverChangeOrderItemQuantity(int orderItemIndex, string orderItemTotalPrice)
        {
            if ( OrderItemQuantityChanged != null )
            {
                OrderItemQuantityChanged(orderItemIndex, orderItemTotalPrice);
            }
        }

        /// <summary>
        /// Set the order quantity of the order item at orderItemIndex to its storage quantity.
        /// </summary>
        private void SetOrderItemQuantityToStorageQuantity(int orderItemIndex)
        {
            _orderItems[ orderItemIndex ].SetOrderQuantityToStorageQuantity();
            NotifyObserverOrderItemQuantityIsExceededStorageQuantity(orderItemIndex, GetStorageQuantity(orderItemIndex));
        }

        /// <summary>
        /// Get the storage quantity of the order item at orderItemIndex.
        /// </summary>
        private int GetStorageQuantity(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].StorageQuantity;
        }

        /// <summary>
        /// Notify observer order quantity of order item is exceeded its storage quantity.
        /// </summary>
        private void NotifyObserverOrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int storageQuantity)
        {
            if ( OrderItemQuantityIsExceededStorageQuantity != null )
            {
                OrderItemQuantityIsExceededStorageQuantity(orderItemIndex, storageQuantity);
            }
        }

        /// <summary>
        /// Decrease the storage quantity of all order items by theirs order quantity.
        /// </summary>
        public void DecreaseProductStorageQuantitiesByOrderQuantities()
        {
            foreach ( OrderItem item in _orderItems )
            {
                item.DecreaseProductStorageQuantityByOrderQuantity();
            }
        }

        /// <summary>
        /// Get all the products in the order.
        /// </summary>
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            foreach ( OrderItem item in _orderItems )
            {
                products.Add(item.Product);
            }
            return products;
        }

        /// <summary>
        /// Get all the order items in the order.
        /// </summary>
        public List<OrderItem> GetOrderItems()
        {
            return _orderItems;
        }
    }
}
