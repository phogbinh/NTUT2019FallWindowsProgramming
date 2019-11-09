using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductTypesManager
    {
        public List<string> ProductTypes
        {
            get
            {
                return _productTypes;
            }
        }
        private string ERROR_PRODUCT_TYPE_INDEX_OUT_OF_RANGE = "The given product type index is out of range.";
        private string ERROR_PRODUCT_TYPES_IS_EMPTY = "Product types is empty.";
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
            if ( !IsInProductTypesIndexRange(productTypeIndex) )
            {
                throw new ArgumentException(ERROR_PRODUCT_TYPE_INDEX_OUT_OF_RANGE);
            }
            return _productTypes[ productTypeIndex ];
        }

        /// <summary>
        /// Return true if the given product type index is in range of _productTypes.
        /// </summary>
        private bool IsInProductTypesIndexRange(int productTypeIndex)
        {
            if ( _productTypes.Count <= 0 )
            {
                throw new ArgumentException(ERROR_PRODUCT_TYPES_IS_EMPTY);
            }
            return 0 <= productTypeIndex && productTypeIndex <= _productTypes.Count - 1;
        }
    }
}
