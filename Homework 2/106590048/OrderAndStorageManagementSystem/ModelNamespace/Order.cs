using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.ModelNamespace
{
    public class Order
    {
        public int TotalPrice
        {
            get
            {
                return _totalPrice;
            }
        }
        private int _totalPrice;

        public Order()
        {
            _totalPrice = 0;
        }

        /// <summary>
        /// Add total price by addtional price.
        /// </summary>
        public void AddTotalPrice(int additionalPrice)
        {
            SetTotalPrice(_totalPrice + additionalPrice);
        }

        /// <summary>
        /// Set total price.
        /// </summary>
        private void SetTotalPrice(int newTotalPrice)
        {
            _totalPrice = newTotalPrice;
        }
    }
}
