using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class Order
    {
        private const int TOTAL_PRICE_INITIAL_VALUE = 0;

        private List<OrderProduct> _orderProducts;
        private Money _totalPrice;

        public Order()
        {
            _orderProducts = new List<OrderProduct>();
            _totalPrice = new Money(TOTAL_PRICE_INITIAL_VALUE);
        }

        // Protest on Dr.Smell
        public string GetTotalPrice(string currencyUnit)
        {
            return _totalPrice.GetStringWithCurrencyUnit(currencyUnit);
        }

        // Protest on Dr.Smell
        public bool IsNotInOrder(OrderProduct orderProduct)
        {
            return !_orderProducts.Contains(orderProduct);
        }

        // Protest on Dr.Smell
        public void AddOrderProduct(OrderProduct orderProduct)
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
    }
}
