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
        public delegate void OrderRemovedEventHandler(int orderItemIndex, Product removedProduct);
        private event OrderRemovedEventHandler _orderRemoved;
        public delegate void OrderItemQuantityChangedEventHandler(int orderItemIndex, string orderItemTotalPrice);
        private event OrderItemQuantityChangedEventHandler _orderItemQuantityChanged;
        public delegate void OrderItemQuantityIsExceededStorageQuantityEventHandler(int orderItemIndex, int storageQuantity);
        private event OrderItemQuantityIsExceededStorageQuantityEventHandler _orderItemQuantityIsExceededStorageQuantity;
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
        public bool IsInOrder(OrderItem orderItem)
        {
            return _order.IsInOrder(orderItem.Id);
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
        public void RemoveOrderItemAt(int orderItemIndex)
        {
            Product removeProduct = _order.GetProduct(orderItemIndex);
            _order.RemoveOrderItemAt(orderItemIndex);
            NotifyObserverChangeAndRemoveOrder(orderItemIndex, removeProduct);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeAndRemoveOrder(int orderItemIndex, Product removedProduct)
        {
            NotifyObserverChangeOrder();
            if ( OrderRemoved != null )
            {
                OrderRemoved(orderItemIndex, removedProduct);
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

        // Protest on Dr.Smell
        private bool IsExceededStorageQuantity(int orderItemIndex, int quantity)
        {
            return _order.IsExceededStorageQuantity(orderItemIndex, quantity);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeOrderItemQuantity(int orderItemIndex, string orderItemTotalPrice)
        {
            NotifyObserverChangeOrder();
            if ( OrderItemQuantityChanged != null )
            {
                OrderItemQuantityChanged(orderItemIndex, orderItemTotalPrice);
            }
        }

        // Protest on Dr.Smell
        private void NotifyObserverOrderItemQuantityIsExceededStorageQuantity(int orderItemIndex, int storageQuantity)
        {
            if ( OrderItemQuantityIsExceededStorageQuantity != null )
            {
                OrderItemQuantityIsExceededStorageQuantity(orderItemIndex, storageQuantity);
            }
        }

        // Protest on Dr.Smell
        private string GetOrderItemTotalPrice(int orderItemIndex)
        {
            return _order.GetOrderItemTotalPrice(orderItemIndex);
        }
    }
}
