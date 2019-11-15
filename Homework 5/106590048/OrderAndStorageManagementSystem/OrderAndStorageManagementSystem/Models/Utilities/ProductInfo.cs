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
