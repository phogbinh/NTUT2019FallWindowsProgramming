using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderProductTabPageProductPage
    {
        List<Product> _products;

        public OrderProductTabPageProductPage()
        {
            _products = new List<Product>();
        }

        /// <summary>
        /// Add a product to this product page.
        /// </summary>
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        /// <summary>
        /// Get the product whose index is productIndex.
        /// </summary>
        public Product GetProduct(int productIndex)
        {
            if ( productIndex >= _products.Count )
            {
                return null;
            }
            return _products[ productIndex ];
        }
    }
}
