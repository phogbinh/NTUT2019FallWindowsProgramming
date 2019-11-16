using OrderAndStorageManagementSystem.Models.Utilities;
using System;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderItem
    {
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
        private const string ERROR_PRODUCT_IS_NULL = "The given product is null.";
        private const int ORDER_QUANTITY_INITIAL_VALUE = 1;
        private Product _product;
        private int _orderQuantity;

        public OrderItem(Product productData)
        {
            if ( productData == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCT_IS_NULL);
            }
            _product = productData;
            this.OrderQuantity = ORDER_QUANTITY_INITIAL_VALUE;
        }

        /// <summary>
        /// Get the total price of the order item.
        /// </summary>
        public Money GetTotalPrice()
        {
            return Price.MultiplyConstant(this.OrderQuantity);
        }
    }
}
