using OrderAndStorageManagementSystem.Models.Utilities;
using System;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderItem
    {
        private const int ORDER_QUANTITY_INITIAL_VALUE = 1;
        public int Id
        {
            get
            {
                return _product.Id;
            }
        }
        public string Name
        {
            get
            {
                return _product.Name;
            }
        }
        public string Type
        {
            get
            {
                return _product.Type;
            }
        }
        public Money Price
        {
            get
            {
                return _product.Price;
            }
        }
        public int StorageQuantity
        {
            get
            {
                return _product.StorageQuantity;
            }
            set
            {
                _product.StorageQuantity = value;
            }
        }
        public Product Product
        {
            get
            {
                return _product;
            }
        }
        public int OrderQuantity
        {
            get
            {
                return _orderQuantity;
            }
            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException(ERROR_ORDER_QUANTITY_CANNOT_BE_SET_TO_NEGATIVE);
                }
                _orderQuantity = value;
            }
        }
        private const string ERROR_ORDER_QUANTITY_CANNOT_BE_SET_TO_NEGATIVE = "Order quantity cannot be set to negative.";
        private Product _product;
        private int _orderQuantity;

        public OrderItem(Product productData)
        {
            _product = productData;
            _orderQuantity = ORDER_QUANTITY_INITIAL_VALUE;
        }

        /// <summary>
        /// Get the total price of the order item.
        /// </summary>
        public Money GetTotalPrice()
        {
            return Price.MultiplyConstant(_orderQuantity);
        }
    }
}
