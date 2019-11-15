using OrderAndStorageManagementSystem.Models.Utilities;
using System;
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
        public delegate void OrderItemQuantityIsExceededStorageQuantityEventHandler(int orderItemIndex, int orderItemStorageQuantity);
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
        private const string ERROR_ORDER_ITEM_IS_NULL = "The given order item is null.";
        private const string ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE = "The given order item index is out of range.";
        private const string ERROR_NEW_CART_PRODUCT_QUANTITY_IS_NEGATIVE = "The given new cart product quantity is negative.";
        private const string ERROR_PRODUCT_IS_NULL = "The given product is null.";
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
            if ( product == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCT_IS_NULL);
            }
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
            if ( orderItem == null )
            {
                throw new ArgumentNullException(ERROR_ORDER_ITEM_IS_NULL);
            }
            _orderItems.Add(orderItem);
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
            if ( !IsInOrderItemsIndexRange(orderItemIndex) )
            {
                throw new ArgumentException(ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE);
            }
            Product removeProduct = _orderItems[ orderItemIndex ].Product;
            _orderItems.RemoveAt(orderItemIndex);
            NotifyObserverChangeOrder();
            NotifyObserverRemoveOrder(orderItemIndex, removeProduct);
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
        /// Set the order quantity of the order item whose index is orderItemIndex to newCartProductQuantity if it does not exceed the item storage quantity; otherwise, we notify the observer.
        /// </summary>
        public void SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(int orderItemIndex, int newCartProductQuantity)
        {
            if ( !IsInOrderItemsIndexRange(orderItemIndex) )
            {
                throw new ArgumentException(ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE);
            }
            if ( !IsExceededStorageQuantity(orderItemIndex, newCartProductQuantity) )
            {
                SetOrderItemQuantity(orderItemIndex, newCartProductQuantity);
            }
            else
            {
                NotifyObserverOrderItemQuantityIsExceededStorageQuantity(orderItemIndex, _orderItems[ orderItemIndex ].StorageQuantity);
            }
        }

        /// <summary>
        /// Return true if the given quantity is bigger than the storage quantity of the order item at orderItemIndex.
        /// </summary>
        private bool IsExceededStorageQuantity(int orderItemIndex, int quantity)
        {
            if ( !IsInOrderItemsIndexRange(orderItemIndex) )
            {
                throw new ArgumentException(ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE);
            }
            return quantity > _orderItems[ orderItemIndex ].StorageQuantity;
        }

        /// <summary>
        /// Set the order quantity of the order item at orderItemIndex to newOrderQuantity.
        /// </summary>
        private void SetOrderItemQuantity(int orderItemIndex, int newOrderQuantity)
        {
            if ( !IsInOrderItemsIndexRange(orderItemIndex) )
            {
                throw new ArgumentException(ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE);
            }
            _orderItems[ orderItemIndex ].OrderQuantity = newOrderQuantity;
            NotifyObserverChangeOrder();
            NotifyObserverChangeOrderItemQuantity(orderItemIndex, GetOrderItemTotalPrice(orderItemIndex));
        }

        /// <summary>
        /// Get the total price of the order item at orderItemIndex.
        /// </summary>
        private string GetOrderItemTotalPrice(int orderItemIndex)
        {
            if ( !IsInOrderItemsIndexRange(orderItemIndex) )
            {
                throw new ArgumentException(ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE);
            }
            return _orderItems[ orderItemIndex ].GetTotalPrice().GetCurrencyFormat();
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
        /// Notify observer order quantity of order item is exceeded its storage quantity.
        /// </summary>
        private void NotifyObserverOrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int orderItemStorageQuantity)
        {
            if ( OrderItemQuantityIsExceededStorageQuantity != null )
            {
                OrderItemQuantityIsExceededStorageQuantity(orderItemIndex, orderItemStorageQuantity);
            }
        }

        /// <summary>
        /// Get all products with their order quantities.
        /// </summary>
        public IDictionary<Product, int> GetProductWithOrderQuantityContainers()
        {
            IDictionary<Product, int> productWithOrderQuantityContainers = new Dictionary<Product, int>();
            foreach ( OrderItem item in _orderItems )
            {
                productWithOrderQuantityContainers.Add(item.Product, item.OrderQuantity);
            }
            return productWithOrderQuantityContainers;
        }

        /// <summary>
        /// Get all the order items in the order.
        /// </summary>
        public List<OrderItem> GetOrderItems()
        {
            return _orderItems;
        }

        /// <summary>
        /// Get order item at orderItemIndex.
        /// </summary>
        public OrderItem GetOrderItemAt(int orderItemIndex)
        {
            if ( !IsInOrderItemsIndexRange(orderItemIndex) )
            {
                throw new ArgumentException(ERROR_ORDER_ITEM_INDEX_IS_OUT_OF_RANGE);
            }
            return _orderItems[ orderItemIndex ];
        }

        /// <summary>
        /// Return true if orderItemIndex is in the order items index range.
        /// </summary>
        private bool IsInOrderItemsIndexRange(int orderItemIndex)
        {
            return AppDefinition.IsInIntervalRange(orderItemIndex, 0, _orderItems.Count - 1);
        }
    }
}
