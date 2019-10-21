using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106590018_Homework
{
    class Order
    {
        private List<Product> _products = null;
        private List<int> _amounts = null;
        private int _total = 0;
        private CreditCardPayment _creditCardPayment;

        public Order()
        {
            _products = new List<Product>();
            _amounts = new List<int>();
        }

        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public List<int> Amounts
        {
            get
            {
                return _amounts;
            }
        }

        public CreditCardPayment CreditCardPayment
        {
            set
            {
                _creditCardPayment = value;
            }
            get
            {
                return _creditCardPayment;
            }
        }

        //回傳一項商品的總價
        public int GetOneProductTotal(int index)
        {
            return _products[index].Price * _amounts[index];
        }

        //回傳這張訂單的價格
        public int GetProductsTotal()
        {
            _total = 0;
            for (int index = 0; index < _products.Count; index++)
            {
                _total += _products[index].Price * _amounts[index];
            }
            return _total;
        }

        //是否有相同商品已存在於表單中
        public bool IsSameProductInOrder(string searchName)
        {
            if (_products.Count == 0)
            {
                return false;
            }

            for (int index = 0; index < _products.Count; index++)
            {
                if (string.Equals(searchName, _products[index].Name))
                {
                    return true;
                }
            }
            return false;
        }

        //結算訂單
        public void ReduceInventoryWithOrder()
        {
            for (int index = 0; index < _products.Count; index++)
            {
                _products[index].Inventory -= _amounts[index];
            }
        }
    }
}
