﻿using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models
{
    public class Model
    {
        public delegate void OrderChangedEventHandler();
        public delegate void OrderItemQuantityChangedEventHandler(int orderItemIndex, string orderItemTotalPrice);
        public delegate void OrderItemQuantityIsExceededStorageQuantityEventHandler(int orderItemIndex, int storageQuantity);
        public delegate void ProductStorageQuantityChangedEventHandler(Product product);
        public OrderChangedEventHandler OrderChanged
        {
            get; set;
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
        public OrderItemQuantityChangedEventHandler OrderItemQuantityChanged
        {
            get; set;
        }
        public OrderItemQuantityIsExceededStorageQuantityEventHandler OrderItemQuantityIsExceededStorageQuantity
        {
            get; set;
        }
        public ProductStorageQuantityChangedEventHandler ProductStorageQuantityChanged
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
                NotifyObserverChangeOrder();
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
            NotifyObserverChangeOrder();
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
            {
                OrderItemQuantityChanged(orderItemIndex, orderItemTotalPrice);
            }
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
            NotifyObserverChangeOrder();
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
