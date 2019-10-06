using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.ModelNamespace
{
    public class Order
    {
        private List<Product> _products;
        private Money _totalPrice;

        public Order()
        {
            _products = new List<Product>();
            _totalPrice = new Money(0);
        }

        // Protest on Dr.Smell
        public string GetTotalPrice(string currencyUnit)
        {
            return _totalPrice.GetStringWithCurrencyUnit(currencyUnit);
        }

        // Protest on Dr.Smell
        public void AddProduct(Product product)
        {
            _totalPrice.Add(product.Price);
            _products.Add(product);
        }

        // Protest on Dr.Smell
        public void RemoveProductAt(int productIndex)
        {
            _totalPrice.Subtract(_products[ productIndex ].Price);
            _products.RemoveAt(productIndex);
        }

        // Protest on Dr.Smell
        public int GetProductsCount()
        {
            return _products.Count;
        }
    }
}
