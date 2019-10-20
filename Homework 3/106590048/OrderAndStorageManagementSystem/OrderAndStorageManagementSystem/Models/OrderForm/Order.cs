using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class Order
    {
        private const int TOTAL_PRICE_INITIAL_VALUE = 0;

        private List<OrderItem> _orderItems;
        private Money _totalPrice;

        public Order()
        {
            _orderItems = new List<OrderItem>();
            _totalPrice = new Money(TOTAL_PRICE_INITIAL_VALUE);
        }

        // Protest on Dr.Smell
        public string GetTotalPrice(string currencyUnit)
        {
            return _totalPrice.GetStringWithCurrencyUnit(currencyUnit);
        }

        // Protest on Dr.Smell
        public bool IsNotInOrder(OrderItem orderItem)
        {
            return !_orderItems.Contains(orderItem);
        }

        // Protest on Dr.Smell
        public void AddOrderItem(OrderItem orderItem)
        {
            _totalPrice.Add(orderItem.Price);
            _orderItems.Add(orderItem);
        }

        // Protest on Dr.Smell
        public void RemoveOrderItemAt(int orderItemIndex)
        {
            _totalPrice.Subtract(_orderItems[ orderItemIndex ].GetTotalPrice());
            _orderItems.RemoveAt(orderItemIndex);
        }

        // Protest on Dr.Smell
        public int GetOrderItemsCount()
        {
            return _orderItems.Count;
        }

        // Protest on Dr.Smell
        public void ClearOrder()
        {
            _totalPrice.Set(TOTAL_PRICE_INITIAL_VALUE);
            _orderItems.Clear();
        }

        // Protest on Dr.Smell
        public bool IsValidQuantity(int orderItemIndex, int quantity)
        {
            return _orderItems[ orderItemIndex ].StorageQuantity >= quantity;
        }

        // Protest on Dr.Smell
        public void SetOrderItemMaximumQuantity(int orderItemIndex)
        {
            _orderItems[ orderItemIndex ].SetMaximumOrderQuantity();
        }

        // Protest on Dr.Smell
        public void SetOrderItemQuantity(int orderItemIndex, int newOrderQuantity)
        {
            _orderItems[ orderItemIndex ].OrderQuantity = newOrderQuantity;
        }

        // Protest on Dr.Smell
        public string GetOrderItemTotalPrice(int orderItemIndex)
        {
            return _orderItems[ orderItemIndex ].GetTotalPrice().GetCurrencyFormat();
        }
    }
}
