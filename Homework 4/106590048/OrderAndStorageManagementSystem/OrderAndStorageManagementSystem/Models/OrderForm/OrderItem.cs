using OrderAndStorageManagementSystem.Models.Utilities;

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
                _orderQuantity = value;
            }
        }
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
