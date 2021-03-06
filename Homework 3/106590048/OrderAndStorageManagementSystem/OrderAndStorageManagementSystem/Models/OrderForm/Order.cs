﻿using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class Order
    {
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
        /// Return true if the orderItemId matches that of an order item in the order.
        /// </summary>
        public bool IsInOrder(int orderItemId)
        {
            foreach ( OrderItem item in _orderItems )
            {
                if ( item.Id == orderItemId )
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
        }

        /// <summary>
        /// Remove an order item from the order at orderItemIndex.
        /// </summary>
        public void RemoveOrderItemAt(int orderItemIndex)
        {
            _orderItems.RemoveAt(orderItemIndex);
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
        }

        /// <summary>
        /// Return true if the given quantity is bigger than the storage quantity of the order item at orderItemIndex.
        /// </summary>
        public bool IsExceededStorageQuantity(int orderItemIndex, int quantity)
        {
            return quantity > _orderItems[ orderItemIndex ].StorageQuantity;
        }

        /// <summary>
        /// Set the order quantity of the order item at orderItemIndex to its storage quantity.
        /// </summary>
        public void SetOrderItemQuantityToStorageQuantity(int orderItemIndex)
        {
            _orderItems[ orderItemIndex ].SetOrderQuantityToStorageQuantity();
        }

        /// <summary>
        /// Set the order quantity of the order item at orderItemIndex to newOrderQuantity.
        /// </summary>
        public void SetOrderItemQuantity(int orderItemIndex, int newOrderQuantity)
        {
            _orderItems[ orderItemIndex ].OrderQuantity = newOrderQuantity;
        }

        /// <summary>
        /// Get the total price of the order item at orderItemIndex.
        /// </summary>
        public string GetOrderItemTotalPrice(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].GetTotalPrice().GetCurrencyFormat();
        }

        /// <summary>
        /// Get the storage quantity of the order item at orderItemIndex.
        /// </summary>
        public int GetStorageQuantity(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].StorageQuantity;
        }

        /// <summary>
        /// Get the corresponding product of the order item at orderItemIndex.
        /// </summary>
        public Product GetProduct(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].Product;
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
    }
}
