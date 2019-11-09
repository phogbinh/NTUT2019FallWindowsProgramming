using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductTypesManager
    {
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
    }
}
