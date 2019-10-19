using OrderAndStorageManagementSystem.Models.Utilities;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderProduct : Product
    {
        private const int TOTAL_QUANTITY_INITIAL_VALUE = 1;
        public int TotalQuantity
        {
            get
            {
                return _totalQuantity;
            }
        }
        private int _totalQuantity;

        public OrderProduct(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData) : base(idData, nameData, typeData, priceData, storageQuantityData, descriptionData)
        {
            _totalQuantity = TOTAL_QUANTITY_INITIAL_VALUE;
        }

        // protest on dr.smell
        public Money GetTotalPrice()
        {
            return Price.MultiplyConstant(_totalQuantity);
        }
    }
}
