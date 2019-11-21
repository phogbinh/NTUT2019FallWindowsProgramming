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
                    throw new ArgumentException(ERROR_STORAGE_QUANTITY_CANNOT_BE_SET_TO_NEGATIVE);
                }
                _storageQuantity = value;
            }
        }
        public ProductInfo ProductInfo
        {
            get
            {
                return _productInfo;
            }
            set
            {
                if ( value == null )
                {
                    throw new ArgumentNullException(ERROR_PRODUCT_INFO_CANNOT_BE_SET_TO_NULL);
                }
                _productInfo = value;
            }
        }
        public string Name
        {
            get
            {
                return this.ProductInfo.Name;
            }
            set
            {
                this.ProductInfo.Name = value;
            }
        }
        public string Type
        {
            get
            {
                return this.ProductInfo.Type;
            }
            set
            {
                this.ProductInfo.Type = value;
            }
        }
        public Money Price
        {
            get
            {
                return this.ProductInfo.Price;
            }
            set
            {
                this.ProductInfo.Price = value;
            }
        }
        public string Description
        {
            get
            {
                return this.ProductInfo.Description;
            }
            set
            {
                this.ProductInfo.Description = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return this.ProductInfo.ImagePath;
            }
            set
            {
                this.ProductInfo.ImagePath = value;
            }
        }
        private const string ERROR_STORAGE_QUANTITY_CANNOT_BE_SET_TO_NEGATIVE = "Storage quantity cannot be set to negative.";
        private const string ERROR_PRODUCT_INFO_CANNOT_BE_SET_TO_NULL = "Product info cannot be set to null.";
        private const int STORAGE_QUANTITY_INITIAL_VALUE = 0;
        private int _id;
        private int _storageQuantity;
        private ProductInfo _productInfo;

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData, string imagePathData)
        {
            _id = idData;
            this.StorageQuantity = storageQuantityData;
            this.ProductInfo = new ProductInfo(nameData, typeData, priceData, descriptionData, imagePathData);
        }

        public Product(int idData, string nameData, string typeData, Money priceData, int storageQuantityData, string descriptionData)
        {
            _id = idData;
            this.StorageQuantity = storageQuantityData;
            string defaultImagePath = Directory.GetCurrentDirectory() + AppDefinition.RELATIVE_PATH_FROM_APPLICATION_BINARY_DIRECTORY_TO_RESOURCES_FOLDER + AppDefinition.APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME + _id.ToString() + AppDefinition.FILE_NAME_EXTENSION_JOINT_PHOTOGRAPHIC_GROUP;
            this.ProductInfo = new ProductInfo(nameData, typeData, priceData, descriptionData, defaultImagePath);
        }

        public Product(int idData, ProductInfo productInfoData)
        {
            _id = idData;
            this.StorageQuantity = STORAGE_QUANTITY_INITIAL_VALUE;
            this.ProductInfo = productInfoData;
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
            return this.StorageQuantity.ToString();
        }

        /// <summary>
        /// Get product price.
        /// </summary>
        public string GetPrice(string currencyUnit)
        {
            return this.Price.GetCurrencyFormatWithCurrencyUnit(currencyUnit);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
