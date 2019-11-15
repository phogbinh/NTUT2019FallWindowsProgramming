using System;
using System.IO;

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
            set
            {
                _name = value;
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public Money Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
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
                if ( value < 0 )
                {
                    throw new ArgumentException(ERROR_PRODUCT_STORAGE_QUANTITY_IS_NEGATIVE);
                }
                _storageQuantity = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }
        private const string ERROR_PRODUCT_STORAGE_QUANTITY_IS_NEGATIVE = "Product storage quantity cannot be set to negative.";
        private int _id;
        private string _name;
        private string _type;
        private Money _price;
        private int _storageQuantity;
        private string _description;
        private string _imagePath;

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData, string imagePathData)
        {
            _id = idData;
            this.Name = nameData;
            this.Type = typeData;
            this.Price = priceData;
            _storageQuantity = storageQuantityData;
            _description = descriptionData;
            _imagePath = imagePathData;
        }

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData)
        {
            _id = idData;
            this.Name = nameData;
            this.Type = typeData;
            this.Price = priceData;
            _storageQuantity = storageQuantityData;
            _description = descriptionData;
            _imagePath = Directory.GetCurrentDirectory() + AppDefinition.RELATIVE_PATH_FROM_APPLICATION_BINARY_DIRECTORY_TO_RESOURCES_FOLDER + AppDefinition.APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME + _id.ToString() + AppDefinition.FILE_NAME_EXTENSION_JOINT_PHOTOGRAPHIC_GROUP;
        }

        public Product(string nameData, string typeData, string priceData, string descriptionData, string imagePathData)
        {
            this.Name = nameData;
            this.Type = typeData;
            this.Price = new Money(int.Parse(priceData));
            _description = descriptionData;
            _imagePath = imagePathData;
        }

        /// <summary>
        /// Get product name and description.
        /// </summary>
        public string GetProductNameAndDescription()
        {
            return this.Name + AppDefinition.PRODUCT_NAME_DESCRIPTION_SEPARATOR + _description;
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
            return this.Price.GetCurrencyFormatWithCurrencyUnit(currencyUnit);
        }
    }
}
