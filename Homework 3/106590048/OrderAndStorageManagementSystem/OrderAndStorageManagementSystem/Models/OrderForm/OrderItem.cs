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
        }
        public string Description
        {
            get
            {
                return _product.Description;
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

        // Protest on Dr.Smell
        public Money GetTotalPrice()
        {
            return Price.MultiplyConstant(_orderQuantity);
        }

        // Protest on Dr.Smell
        public void SetOrderQuantityToStorageQuantity()
        {
            _orderQuantity = StorageQuantity;
        }
    }
}
