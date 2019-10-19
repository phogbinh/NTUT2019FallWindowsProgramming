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

        // Protest on Dr.Smell
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Protest on Dr.Smell
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
