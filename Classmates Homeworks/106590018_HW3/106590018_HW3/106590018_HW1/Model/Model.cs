using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace _106590018_Homework
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public Model()
        {
            _dataManagement = new DataManagement(DataManagement.GetSystemDirection() + @"\CommodityInformation.xlsx", 1);
            _dataManagement.LoadProduct(_products);
            _dataManagement.CloseExcel();
            FindAllTypeInProducts();           
        }
        ///
        /// Observer 
        ///
        //更新商品存貨 通知View 更新
        public void UpdateInventory(int index, int amount)
        {   
            _products[index].Inventory += amount;
            NotifyObserver();
        }

        //庫存檢調 訂單訂購的數量
        public void ReduceInventoryWithOrder()
        {
            _order.ReduceInventoryWithOrder();
            _order = new Order(); //開心的一個order
            NotifyObserver();
        }

        //通知註冊者
        void NotifyObserver()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
        /// <summary>
        /// 與Order Form有關/////////////////////////////
        /// </summary>

        //回傳有那些種類的商品
        public List<string> TypeList
        {
            get
            {
                return _typeList;
            }
        }

        //回傳被點選的商品
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
        }

        public int Total
        {
            get
            {
                return _order.GetProductsTotal();
            }
        }

        //回傳每一種種類商品的數量
        public List<int> EachTypeAmount
        {
            get
            {
                return _eachTypeAmount;
            }
        }

        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        //獲得在訂單中的商品
        public Product GetProductsInOrder(int index)
        {
            return _order.Products[index];
        }

        //取得被選商品的介紹
        public string GetSelectProductIntroduction()
        {
            return _selectedProduct.Introduction;
        }

        //回傳單行最後的總價
        public int GetOneRowProductPriceTotal(int index)
        {
            return _order.GetOneProductTotal(index);
        }

        //更新價錢和總價
        public void UpdateAmountInOrder(int index, int amount)
        {
            _order.Amounts[index] = amount;
            _order.GetProductsTotal();
        }

        //透過id獲得商品
        public Product GetProductById(int id)
        {
            for (int count = 0; count < _products.Count; count++)
            {
                if (_products[count].Id == id)
                {
                    return _products[count];
                }
            }
            return null;
        }

        //紀錄現在點選的商品
        public void SetSelectedProduct(int id)
        {
            _selectedProduct = GetProductById(id);
        }
        
        //清除暫存的商品資料
        public void ClearSelectedProduct()
        {
            _selectedProduct = null;
        }

        //加入商品到現在的訂單
        public bool AddProductInOrder()
        {
            if (_selectedProduct != null)
            {

                _order.Products.Add(_selectedProduct);
                _order.Amounts.Add(1);
                _order.GetProductsTotal();
                return true;
            }
            else
                return false;
        }

        //從訂單中刪除商品
        public bool DeleteProductInOrder(int deleteIndex)
        {
            const int DEFEAT = -1;           
            if (deleteIndex != DEFEAT)
            {
                _order.GetProductsTotal();
                _order.Products.RemoveAt(deleteIndex);
                _order.Amounts.RemoveAt(deleteIndex);
                return true;
            }
            else
            {
                return false;
            }    
        }

        //取的每個商品分隔的編號
        private int CountSameTypeProductAmount(string type)
        {
            int count = 0;
            for ( int index = 0; index < _products.Count; index++)
            {
                if ( String.Equals(_products[index].Type, type))
                {
                    count++;
                }
            }
            return count;
        }

        //找到所有商品的種類
        public void FindAllTypeInProducts()
        {
            for ( int index = 0; index < _products.Count; index++)
            {
                if (IsTypeInList(_products[index].Type) == false)
                {
                    _typeList.Add(_products[index].Type);
                    _eachTypeAmount.Add(CountSameTypeProductAmount(_products[index].Type));
                }
            }
        }

        //獲得單一種類需要的頁數
        public int GetAllPageInOneType(string type)
        {
            int carry = 1;
            if (CountSameTypeProductAmount(type) % BUTTON_AMOUNT != 0)
                return (CountSameTypeProductAmount(type) / BUTTON_AMOUNT) + carry;
            else
                return CountSameTypeProductAmount(type) / BUTTON_AMOUNT;
        }

        //是否已有記錄過此種類型的商品
        public bool IsTypeInList(string type)
        {
            for (int index = 0; index < _typeList.Count; index++)
            {
                if (String.Equals(_typeList[index], type))
                {
                    return true;
                }
            }
            return false;
        }

        //是否有相同商品已從在於購物清單中
        public bool IsSameProductInOrder()
        {
            if (_selectedProduct == null)
                return false;
            else
                return _order.IsSameProductInOrder(_selectedProduct.Name);
        }

        /// <summary>
        /// 與CreditCardModel 有關
        /// </summary>
        /// 
        
        //加入新的信用卡資料
        public void SetOrderCreditCardPayment(CreditCardPayment creditCardPayment)
        {
            _order.CreditCardPayment = creditCardPayment;
            _orders.Add(_order);
        }

        //回傳信用卡資料
        public CreditCardPayment GetCreditCardPayment()
        {
            if (_orders.Count == 0)
                return null;
            return _orders[_orders.Count - 1].CreditCardPayment;
            
        }
        
        //private variable
        private DataManagement _dataManagement;
        private const int TYPE_AMOUNT = 6;
        private const int BUTTON_AMOUNT = 6;
        private Product _selectedProduct;
        private List<int> _eachTypeAmount = new List<int>(); // 6 = tpye的數量 
        private List<string> _typeList = new List<string>();
        private List<Product> _products = new List<Product>();
        private Order _order = new Order();
        private List<Order> _orders = new List<Order>();       
    }
}
