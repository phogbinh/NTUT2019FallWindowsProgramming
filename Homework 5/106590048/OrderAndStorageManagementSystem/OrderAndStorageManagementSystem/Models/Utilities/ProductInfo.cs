using System;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductInfo
    {
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
                if ( value == null )
                {
                    throw new ArgumentNullException(ERROR_PRICE_CANNOT_BE_SET_TO_NULL);
                }
                if ( value.IsNegative() )
                {
                    throw new ArgumentException(ERROR_PRICE_CANNOT_BE_SET_TO_NEGATIVE);
                }
                _price = value;
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
        private const string ERROR_PRICE_CANNOT_BE_SET_TO_NULL = "Price cannot be set to null.";
        private const string ERROR_PRICE_CANNOT_BE_SET_TO_NEGATIVE = "Price cannot be set to negative.";
        private string _name;
        private string _type;
        private Money _price;
        private string _description;
        private string _imagePath;

        public ProductInfo(string nameData, string typeData, Money priceData, string descriptionData, string imagePathData)
        {
            this.Name = nameData;
            this.Type = typeData;
            this.Price = priceData;
            this.Description = descriptionData;
            this.ImagePath = imagePathData;
        }
    }
}
