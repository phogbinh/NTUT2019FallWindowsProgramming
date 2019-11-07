namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class Product
    {
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
        }
        public Money Price
        {
            get
            {
                return _price;
            }
        }
        public int StorageQuantity
        {
            get
            {
                return _storageQuantity;
            }
            set
            {
                _storageQuantity = value;
            }
        }
        private int _id;
        private string _name;
        private string _type;
        private Money _price;
        private int _storageQuantity;
        private string _description;

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData)
        {
            _id = idData;
            _name = nameData;
            _type = typeData;
            _price = priceData;
            _storageQuantity = storageQuantityData;
            _description = descriptionData;
        }

        /// <summary>
        /// Get product name and description.
        /// </summary>
        public string GetProductNameAndDescription()
        {
            return _name + AppDefinition.PRODUCT_NAME_DESCRIPTION_SEPARATOR + _description;
        }

        /// <summary>
        /// Get product storage quantity.
        /// </summary>
        public string GetStorageQuantity()
        {
            return _storageQuantity.ToString();
        }

        /// <summary>
        /// Get product price.
        /// </summary>
        public string GetPrice(string currencyUnit)
        {
            return _price.GetCurrencyFormatWithCurrencyUnit(currencyUnit);
        }
    }
}
