using OrderAndStorageManagementSystem.Models.Utilities;
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

        // Protest on Dr.Smell
        public string GetTotalPrice(string currencyUnit)
        {
            Money totalPrice = new Money(TOTAL_PRICE_INITIAL_VALUE);
            foreach ( OrderItem orderItem in _orderItems )
            {
                totalPrice.Add(orderItem.GetTotalPrice());
            }
            return totalPrice.GetStringWithCurrencyUnit(currencyUnit);
        }

        // Protest on Dr.Smell
        public bool IsInOrder(OrderItem orderItem)
        {
            foreach ( OrderItem item in _orderItems )
            {
                if ( item.Id == orderItem.Id )
                {
                    return true;
                }
            }
            return false;
        }

        // Protest on Dr.Smell
        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }

        // Protest on Dr.Smell
        public void RemoveOrderItemAt(int orderItemIndex)
        {
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
            _orderItems.Clear();
        }

        // Protest on Dr.Smell
        public bool IsExceededStorageQuantity(int orderItemIndex, int quantity)
        {
            return quantity > _orderItems[ orderItemIndex ].StorageQuantity;
        }

        // Protest on Dr.Smell
        public void SetOrderItemQuantityToStorageQuantity(int orderItemIndex)
        {
            _orderItems[ orderItemIndex ].SetOrderQuantityToStorageQuantity();
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
