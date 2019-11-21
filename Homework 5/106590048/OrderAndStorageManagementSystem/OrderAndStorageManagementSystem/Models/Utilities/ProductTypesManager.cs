using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductTypesManager
    {
        public delegate void ProductTypeAddedEventHandler(string productType);
        public ProductTypeAddedEventHandler ProductTypeAdded
        {
            get; set;
        }
        public List<string> ProductTypes
        {
            get
            {
                return _productTypes;
            }
        }
        private const string ERROR_INITIAL_DATA_BASE_PRODUCTS_IS_NULL = "The given initial database products is null.";
        private const string ERROR_PRODUCT_TYPE_INDEX_IS_OUT_OF_RANGE = "The given product type index is out of range.";
        private List<string> _productTypes;

        public ProductTypesManager(List<Product> initialDataBaseProducts)
        {
            InitializeProductTypes(initialDataBaseProducts);
        }

        /// <summary>
        /// Initialize _productTypes with the given initialDataBaseProducts.
        /// </summary>
        private void InitializeProductTypes(List<Product> initialDataBaseProducts)
        {
            if ( initialDataBaseProducts == null )
            {
                throw new ArgumentNullException(ERROR_INITIAL_DATA_BASE_PRODUCTS_IS_NULL);
            }
            _productTypes = new List<string>();
            foreach ( Product product in initialDataBaseProducts )
            {
                if ( !_productTypes.Contains(product.Type) )
                {
                    _productTypes.Add(product.Type);
                }
            }
        }

        /// <summary>
        /// Get product type by product type index.
        /// </summary>
        public string GetProductType(int productTypeIndex)
        {
            if ( !AppDefinition.IsInIntervalRange(productTypeIndex, 0, _productTypes.Count - 1) )
            {
                throw new ArgumentOutOfRangeException(ERROR_PRODUCT_TYPE_INDEX_IS_OUT_OF_RANGE);
            }
            return _productTypes[ productTypeIndex ];
        }

        /// <summary>
        /// Determines whether the specified product type is existing.
        /// </summary>
        public bool IsExisting(string productType)
        {
            return _productTypes.Contains(productType);
        }

        /// <summary>
        /// Adds the type of the product.
        /// </summary>
        public void AddProductType(string productType)
        {
            _productTypes.Add(productType);
            NotifyObserverAddProductType(productType);
        }

        /// <summary>
        /// Notifies the type of the observer add product.
        /// </summary>
        private void NotifyObserverAddProductType(string productType)
        {
            if ( ProductTypeAdded != null )
            {
                ProductTypeAdded(productType);
            }
        }
    }
}
