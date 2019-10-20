using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
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
        public delegate void OrderRemovedEventHandler(int productIndex);
        private event OrderRemovedEventHandler _orderRemoved;
        public delegate void OrderItemQuantityChangedEventHandler(int productIndex);
        private event OrderItemQuantityChangedEventHandler _orderItemQuantityChanged;
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
        private List<Product> _products;
        private Order _order;

        public Model()
        {
            _products = DataBaseManager.GetProductsFromProductTable();
            _order = new Order();
        }

        // Protest on Dr.Smell
        public void AddProductToOrderIfProductIsNotInOrder(Product product)
        {
            var orderItem = new OrderItem(product);
            if ( !IsInOrder(orderItem) )
            {
                _order.AddOrderItem(orderItem);
                NotifyObserverChangeAndAddOrder(orderItem);
            }
        }

        // Protest on Dr.Smell
        private bool IsInOrder(OrderItem orderItem)
        {
            return _order.IsInOrder(orderItem);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeAndAddOrder(OrderItem orderItem)
        {
            NotifyObserverChangeOrder();
            if ( OrderAdded != null )
            {
                OrderAdded(orderItem);
            }
        }

        // Protest on Dr.Smell
        public string GetOrderTotalPrice()
        {
            return _order.GetTotalPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
        }

        // Protest on Dr.Smell
        public void RemoveProductFromOrder(int productIndex)
        {
            _order.RemoveOrderItemAt(productIndex);
            NotifyObserverChangeAndRemoveOrder(productIndex);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeAndRemoveOrder(int productIndex)
        {
            NotifyObserverChangeOrder();
            if ( OrderRemoved != null )
            {
                OrderRemoved(productIndex);
            }
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeOrder()
        {
            if ( OrderChanged != null )
            {
                OrderChanged();
            }
        }

        // Protest on Dr.Smell
        public int GetOrderItemsCount()
        {
            return _order.GetOrderItemsCount();
        }

        // Protest on Dr.Smell
        public void ClearOrder()
        {
            _order.ClearOrder();
            NotifyObserverChangeAndClearOrder();
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeAndClearOrder()
        {
            NotifyObserverChangeOrder();
            if ( OrderCleared != null )
            {
                OrderCleared();
            }
        }

        // Protest on Dr.Smell
        public void SetOrderItemQuantity(int productIndex, int newCartProductQuantity)
        {
            if ( IsValidQuantity(productIndex, newCartProductQuantity) )
            {
                _order.SetOrderItemQuantity(productIndex, newCartProductQuantity);
                NotifyObserverChangeOrderItemQuantity(productIndex);
            }
            else
            {
                _order.SetOrderItemMaximumQuantity(productIndex);
                // TODO: Notify observer to set back value
            }
        }

        // Protest on Dr.Smell
        private bool IsValidQuantity(int productIndex, int quantity)
        {
            return _order.IsValidQuantity(productIndex, quantity);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeOrderItemQuantity(int productIndex)
        {
            if ( OrderItemQuantityChanged != null )
            {
                OrderItemQuantityChanged(productIndex);
            }
        }

        // Protest on Dr.Smell
        public string GetOrderItemTotalPrice(int productIndex)
        {
            return _order.GetOrderItemTotalPrice(productIndex);
        }
    }
}
