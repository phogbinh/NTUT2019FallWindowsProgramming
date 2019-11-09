using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductsManager
    {
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        private List<Product> _products;

        public ProductsManager()
        {
            _products = DataBaseManager.GetProductsFromProductTable();
        }
    }
}
