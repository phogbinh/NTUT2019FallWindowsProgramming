using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class Order
    {
        private const int TOTAL_PRICE_INITIAL_VALUE = 0;

        private List<OrderItem> _orderProducts;
        private Money _totalPrice;

        public Order()
        {
            _orderProducts = new List<OrderItem>();
            _totalPrice = new Money(TOTAL_PRICE_INITIAL_VALUE);
        }

        // Protest on Dr.Smell
        public string GetTotalPrice(string currencyUnit)
        {
            return _totalPrice.GetStringWithCurrencyUnit(currencyUnit);
        }

        // Protest on Dr.Smell
        public bool IsNotInOrder(OrderItem orderProduct)
        {
            return !_orderProducts.Contains(orderProduct);
        }

        // Protest on Dr.Smell
        public void AddOrderProduct(OrderItem orderProduct)
        {
            _totalPrice.Add(orderProduct.Price);
            _orderProducts.Add(orderProduct);
        }

        // Protest on Dr.Smell
        public void RemoveOrderProductAt(int orderProductIndex)
        {
            _totalPrice.Subtract(_orderProducts[ orderProductIndex ].GetTotalPrice());
            _orderProducts.RemoveAt(orderProductIndex);
        }

        // Protest on Dr.Smell
        public int GetProductsCount()
        {
            return _orderProducts.Count;
        }

        // Protest on Dr.Smell
        public void ClearOrder()
        {
            _totalPrice.Set(TOTAL_PRICE_INITIAL_VALUE);
            _orderProducts.Clear();
        }

        // Protest on Dr.Smell
        public bool IsValidQuantity(int orderProductIndex, int quantity)
        {
            return _orderProducts[ orderProductIndex ].StorageQuantity >= quantity;
        }

        // Protest on Dr.Smell
        public void SetOrderProductMaximumQuantity(int orderProductIndex)
        {
            _orderProducts[ orderProductIndex ].SetMaximumOrderQuantity();
        }

        // Protest on Dr.Smell
        public void SetOrderProductQuantity(int orderProductIndex, int newOrderQuantity)
        {
            _orderProducts[ orderProductIndex ].OrderQuantity = newOrderQuantity;
        }

        // Protest on Dr.Smell
        public string GetOrderProductTotalPrice(int orderProductIndex)
        {
            return _orderProducts[ orderProductIndex ].GetTotalPrice().GetCurrencyFormat();
        }
    }
}
