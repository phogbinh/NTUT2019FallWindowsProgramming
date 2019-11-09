﻿using System.Collections.Generic;

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
            return _productTypes[ productTypeIndex ];
        }
    }
}
