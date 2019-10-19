using OrderAndStorageManagementSystem.Models.Utilities;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderProduct : Product
    {
        private const int ORDER_QUANTITY_INITIAL_VALUE = 1;
        public int OrderQuantity
        {
            get
            {
                return _orderQuantity;
            }
        }
        private int _orderQuantity;

        public OrderProduct(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData) : base(idData, nameData, typeData, priceData, storageQuantityData, descriptionData)
        {
            _orderQuantity = ORDER_QUANTITY_INITIAL_VALUE;
        }

        // protest on dr.smell
        public Money GetTotalPrice()
        {
            return Price.MultiplyConstant(_orderQuantity);
        }
    }
}
