using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class Order
    {
        private const int TOTAL_PRICE_INITIAL_VALUE = 0;

        private List<Product> _products;
        private Money _totalPrice;

        public Order()
        {
            _products = new List<Product>();
            _totalPrice = new Money(TOTAL_PRICE_INITIAL_VALUE);
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

        // Protest on Dr.Smell
        public void ClearOrder()
        {
            _totalPrice.Set(TOTAL_PRICE_INITIAL_VALUE);
            _products.Clear();
        }
    }
}
