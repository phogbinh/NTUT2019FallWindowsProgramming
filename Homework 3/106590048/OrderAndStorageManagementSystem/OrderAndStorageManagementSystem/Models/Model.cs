﻿using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Models
{
    public class Model
    {
        public event OrderChangedEventHandler OrderChanged;
        public delegate void OrderChangedEventHandler();
        public event OrderClearedEventHandler OrderCleared;
        public delegate void OrderClearedEventHandler();
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
            OrderChanged?.Invoke();
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
            OrderCleared?.Invoke();
        }
    }
}
