using System.Collections.Generic;
using System.Data;

namespace OrderAndStorageManagementSystem.Model
{
    public class AppModel
    {
        public IDictionary<ProductTypes, string> ProductTypesTypeToStringMap
        {
            get
            {
                return _productTypesTypeToStringMap;
            }
        }
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public int CartTotalPrice
        {
            get
            {
                return _cartTotalPrice;
            }
        }
        private IDictionary<string, ProductTypes> _productTypesStringToTypeMap;
        private IDictionary<ProductTypes, string> _productTypesTypeToStringMap;
        private DataBaseManager _dataBaseManager;
        private List<Product> _products;
        private int _cartTotalPrice;
        public AppModel()
        {
            InitializeProductTypesMaps();
            _dataBaseManager = new DataBaseManager(Properties.Settings.Default.AppDatabaseConnectionString);
            _products = new List<Product>();
            InitializeProducts(_dataBaseManager.DataTable);
            _cartTotalPrice = 0;
        }

        /// <summary>
        /// Initialize maps of product types.
        /// </summary>
        private void InitializeProductTypesMaps()
        {
            // String to Type
            _productTypesStringToTypeMap = new Dictionary<string, ProductTypes>();
            _productTypesStringToTypeMap.Add(AppDefinition.MOTHER_BOARD, ProductTypes.MotherBoard);
            _productTypesStringToTypeMap.Add(AppDefinition.CENTRAL_PROCESSING_UNIT, ProductTypes.CentralProcessingUnit);
            _productTypesStringToTypeMap.Add(AppDefinition.RANDOM_ACCESS_MEMORY, ProductTypes.RandomAccessMemory);
            _productTypesStringToTypeMap.Add(AppDefinition.HARD_DISK, ProductTypes.HardDisk);
            _productTypesStringToTypeMap.Add(AppDefinition.GRAPHICS_CARD, ProductTypes.GraphicsCard);
            _productTypesStringToTypeMap.Add(AppDefinition.COMPUTER_SET, ProductTypes.ComputerSet);
            // Type to String
            _productTypesTypeToStringMap = new Dictionary<ProductTypes, string>();
            foreach ( string key in _productTypesStringToTypeMap.Keys )
            {
                _productTypesTypeToStringMap.Add(_productTypesStringToTypeMap[ key ], key);
            }
        }

        /// <summary>
        /// Initialize products from the data table fetched from the database.
        /// </summary>
        private void InitializeProducts(DataTable dataTable)
        {
            foreach ( DataRow row in dataTable.Rows )
            {
                int productId = int.Parse(row[ AppDefinition.PRODUCT_ID ].ToString());
                string productName = row[ AppDefinition.PRODUCT_NAME ].ToString();
                ProductTypes productType = _productTypesStringToTypeMap[ row[ AppDefinition.PRODUCT_TYPE ].ToString() ];
                int productPrice = int.Parse(row[ AppDefinition.PRODUCT_PRICE ].ToString());
                string productDescription = row[ AppDefinition.PRODUCT_DESCRIPTION ].ToString();
                _products.Add(new Product(productId, productName, productType, productPrice, productDescription));
            }
        }

        /// <summary>
        /// Add total price by addtional price.
        /// </summary>
        public void AddTotalPrice(int additionalPrice)
        {
            SetTotalPrice(_cartTotalPrice + additionalPrice);
        }

        /// <summary>
        /// Set total price.
        /// </summary>
        private void SetTotalPrice(int newTotalPrice)
        {
            _cartTotalPrice = newTotalPrice;
        }
    }
}
