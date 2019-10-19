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
        public void AddProductToOrder(Product product)
        {
            _order.AddProduct(product);
            NotifyObserverChangeOrder();
        }

        // Protest on Dr.Smell
        public string GetOrderTotalPrice()
        {
            return _order.GetTotalPrice(AppDefinition.TAIWAN_CURRENCY_UNIT);
        }

        // Protest on Dr.Smell
        public void RemoveProductFromOrder(int productIndex)
        {
            _order.RemoveProductAt(productIndex);
            NotifyObserverChangeOrder();
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
    }
}
