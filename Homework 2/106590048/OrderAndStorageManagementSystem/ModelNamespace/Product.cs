using System.Diagnostics;

namespace OrderAndStorageManagementSystem.Model
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
        public int Price
        {
            get
            {
                return _price;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }
        private int _id;
        private string _name;
        private string _type;
        private int _price;
        private string _description;

        public Product(int idData, string nameData, string typeData, int priceData, string descriptionData)
        {
            _id = idData;
            _name = nameData;
            _type = typeData;
            _price = priceData;
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
        /// Print info of the product. For debugging purpose only.
        /// </summary>
        public void Print()
        {
            string result = "";
            result += AppDefinition.PRINT_ID + _id.ToString();
            result += AppDefinition.PRINT_DELIMITER;
            result += AppDefinition.PRINT_NAME + _name;
            result += AppDefinition.PRINT_DELIMITER;
            result += AppDefinition.PRINT_TYPE + _type;
            result += AppDefinition.PRINT_DELIMITER;
            result += AppDefinition.PRINT_PRICE + _price.ToString();
            result += AppDefinition.PRINT_DELIMITER;
            result += AppDefinition.PRINT_DESCRIPTION + _description;
            result += AppDefinition.PRINT_END_MARK;
            Debug.Write(result);
        }
    }
}
