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
                return _productInfo.Name;
            }
            set
            {
                _productInfo.Name = value;
            }
        }
        public string Type
        {
            get
            {
                return _productInfo.Type;
            }
            set
            {
                _productInfo.Type = value;
            }
        }
        public Money Price
        {
            get
            {
                return _productInfo.Price;
            }
            set
            {
                _productInfo.Price = value;
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
                return _productInfo.Description;
            }
            set
            {
                _productInfo.Description = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return _productInfo.ImagePath;
            }
            set
            {
                _productInfo.ImagePath = value;
            }
        }
        private const string ERROR_PRODUCT_STORAGE_QUANTITY_IS_NEGATIVE = "Product storage quantity cannot be set to negative.";
        private int _id;
        private int _storageQuantity;
        private ProductInfo _productInfo = new ProductInfo("", "", "0", "", "");

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData, string imagePathData)
        {
            _id = idData;
            this.Name = nameData;
            this.Type = typeData;
            this.Price = priceData;
            _storageQuantity = storageQuantityData;
            this.Description = descriptionData;
            this.ImagePath = imagePathData;
        }

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData)
        {
            _id = idData;
            this.Name = nameData;
            this.Type = typeData;
            this.Price = priceData;
            _storageQuantity = storageQuantityData;
            this.Description = descriptionData;
            this.ImagePath = Directory.GetCurrentDirectory() + AppDefinition.RELATIVE_PATH_FROM_APPLICATION_BINARY_DIRECTORY_TO_RESOURCES_FOLDER + AppDefinition.APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME + _id.ToString() + AppDefinition.FILE_NAME_EXTENSION_JOINT_PHOTOGRAPHIC_GROUP;
        }

        public Product(string nameData, string typeData, string priceData, string descriptionData, string imagePathData)
        {
            this.Name = nameData;
            this.Type = typeData;
            this.Price = new Money(int.Parse(priceData));
            this.Description = descriptionData;
            this.ImagePath = imagePathData;
        }

        /// <summary>
        /// Get product name and description.
        /// </summary>
        public string GetProductNameAndDescription()
        {
            return this.Name + AppDefinition.PRODUCT_NAME_DESCRIPTION_SEPARATOR + this.Description;
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
