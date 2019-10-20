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
        public delegate void OrderAddedEventHandler(OrderItem orderProduct);
        private event OrderAddedEventHandler _orderAdded;
        public delegate void OrderRemovedEventHandler(int productIndex);
        private event OrderRemovedEventHandler _orderRemoved;
        public delegate void OrderProductQuantityChangedEventHandler(int productIndex);
        private event OrderProductQuantityChangedEventHandler _orderProductQuantityChanged;
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
        public OrderProductQuantityChangedEventHandler OrderProductQuantityChanged
        {
            get
            {
                return _orderProductQuantityChanged;
            }
            set
            {
                _orderProductQuantityChanged = value;
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
            var orderProduct = new OrderItem(product);
            if ( IsNotInOrder(orderProduct) )
            {
                _order.AddOrderProduct(orderProduct);
                NotifyObserverChangeAndAddOrder(orderProduct);
            }
        }

        // Protest on Dr.Smell
        private bool IsNotInOrder(OrderItem orderProduct)
        {
            return _order.IsNotInOrder(orderProduct);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeAndAddOrder(OrderItem orderProduct)
        {
            NotifyObserverChangeOrder();
            if ( OrderAdded != null )
            {
                OrderAdded(orderProduct);
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
            _order.RemoveOrderProductAt(productIndex);
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
        public int GetOrderProductsCount()
        {
            return _order.GetProductsCount();
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
        public void SetOrderProductQuantity(int productIndex, int newCartProductQuantity)
        {
            if ( IsValidQuantity(productIndex, newCartProductQuantity) )
            {
                _order.SetOrderProductQuantity(productIndex, newCartProductQuantity);
                NotifyObserverChangeOrderProductQuantity(productIndex);
            }
            else
            {
                _order.SetOrderProductMaximumQuantity(productIndex);
                // TODO: Notify observer to set back value
            }
        }

        // Protest on Dr.Smell
        private bool IsValidQuantity(int productIndex, int quantity)
        {
            return _order.IsValidQuantity(productIndex, quantity);
        }

        // Protest on Dr.Smell
        private void NotifyObserverChangeOrderProductQuantity(int productIndex)
        {
            if ( OrderProductQuantityChanged != null )
            {
                OrderProductQuantityChanged(productIndex);
            }
        }

        // Protest on Dr.Smell
        public string GetOrderProductTotalPrice(int productIndex)
        {
            return _order.GetOrderProductTotalPrice(productIndex);
        }
    }
}
