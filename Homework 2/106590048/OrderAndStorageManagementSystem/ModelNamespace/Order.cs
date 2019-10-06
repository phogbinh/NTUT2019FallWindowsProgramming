namespace OrderAndStorageManagementSystem.ModelNamespace
{
    public class Order
    {
        private Money _totalPrice;

        public Order()
        {
            _totalPrice = new Money(0);
        }

        /// <summary>
        /// Add total price by addtional price.
        /// </summary>
        public void AddTotalPrice(Money additionalPrice)
        {
            _totalPrice.Add(additionalPrice);
        }

        // Protest on Dr.Smell
        public string GetTotalPrice(string currencyUnit)
        {
            return _totalPrice.GetStringWithCurrencyUnit(currencyUnit);
        }
    }
}
