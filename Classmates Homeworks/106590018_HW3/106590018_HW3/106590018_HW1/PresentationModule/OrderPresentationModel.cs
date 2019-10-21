using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106590018_Homework
{   
    public class OrderPresentationModel
    {
        private Model _model;
        private int _nowPage = 1;
        private int _allPage;
        private const int BUTTON_AMOUNT_IN_A_TAB = 6;
        private const string SLASH = "/";
        private const string UP_PAGE = "uppage";
        private const string DOWN_PAGE = "downpage";

        //constructor
        public OrderPresentationModel(Model model)
        {
            this._model = model;
        }
        
        //回傳Page的文字
        public string GetPageText()
        {
            return _nowPage + SLASH + _allPage;
        }

        public int NowPage
        {
            set
            {
                _nowPage = value;
            }
            get
            {
                return _nowPage;
            }
        } 

        public int AllPage
        {
            set
            {
                _allPage = value;
            }
            get
            {
                return _allPage;
            }
        }

        //判斷第N個商品是否要顯示
        public bool IsProductInPrintRange(int count, string direction)
        {
            const int TWO = 2;
            const int ONE = 1;
            const string SAME = "same";
            if (string.Equals(direction, SAME))
            {
                return true;
            }
            else if (IsUpPage(direction))
                return ((count > (_nowPage - TWO) * BUTTON_AMOUNT_IN_A_TAB && count <= (_nowPage - ONE) * BUTTON_AMOUNT_IN_A_TAB));
            else
                return (count > (_nowPage * BUTTON_AMOUNT_IN_A_TAB) && count < (_nowPage + 1) * BUTTON_AMOUNT_IN_A_TAB);
        }

        //判斷是否是往上一頁
        public bool IsUpPage(string direction)
        {
            if (string.Equals(direction, UP_PAGE))
                return true;
            else
                return false;
        }

        //改變NowPage
        public void UpdateNowAndAllPage(string direction)
        {
            if (string.Equals(direction, UP_PAGE))
                NowPage--;
            else
                NowPage++;
        }

        //回傳兩個Page之間的關係
        public int GetRelationOfNowPageAndAllPage()
        {
            if (_nowPage > _allPage)
                return 1;
            else if (_nowPage == _allPage)
                return 0;
            else
                return -1;
        }

        //Now Page 是否小於等於 AllPge
        public bool IsNowPageSmallOrEqualAllPage()
        {
            const int ALL_PAGE_BIG = -1;
            const int NOW_ALL_SAME = 0;
            if (GetRelationOfNowPageAndAllPage() == ALL_PAGE_BIG ||
                GetRelationOfNowPageAndAllPage() == NOW_ALL_SAME)
                return true;
            else
                return false;
        }

        //回傳要產生幾個
        public int GetButtonAmountNeedProduce(int productAmount)
        {    
            return productAmount >= BUTTON_AMOUNT_IN_A_TAB ? BUTTON_AMOUNT_IN_A_TAB : productAmount;
        }

        //是否在第一頁
        public bool IsNowInFirstPage()
        {
            const int FIRST_PAGE = 1;
            if (_nowPage == FIRST_PAGE)
                return true;
            else
                return false;
        }

        //Count 是否跟 Button需要的數量一樣
        public bool IsCountSameButtonAmount(int productCount, int productAmount)
        {
            int buttonAmount = GetButtonAmountNeedProduce(productAmount);
            if (productCount != buttonAmount)
                return true;
            else
                return false;
        }

        //判斷商品是否存在於購物車當中
        public bool IsSameProductInOrder(string result)
        {
            const string EXIST = "exist";
            if (string.Equals(result, EXIST))
            {
                return true;
            }
            else
                return false;
        }

        //幫price加入逗點
        public string AddPeriodInNumber(int number)
        {
            string numberString = number.ToString();
            string newNumberString = "";
            const string COMMA = ",";
            const int SPLIT_WORD_AMOUNT = 3;

            int count = 0;
            for (int index = numberString.Length - 1; index >= 0; index--)
            {
                newNumberString = numberString[index] + newNumberString;
                count++;
                if (count == SPLIT_WORD_AMOUNT)
                    newNumberString = COMMA + newNumberString;
            }
            return newNumberString;
        }

        //判斷model加入商品是否成功
        public bool IsAddProductInOrderSuccessed(string result)
        {
            if (string.Equals(result, ""))
            {
                return false;
            }
            else
                return true;

        }

        //查slectedProduct是否為null
        public bool IsSelectedProductNull()
        {
            if (_model.SelectedProduct == null)
                return true;
            else
                return false;
        }

        //回傳現在選到商品的價格(有逗號)
        public string GetSelectedProductWithPeriod()
        {
            return AddPeriodInNumber(_model.SelectedProduct.Price);
        }

        //回傳在購物車商品的價錢
        public string GetProductInOrderPriceWithPeriod(int index)
        {
            return AddPeriodInNumber(_model.GetProductsInOrder(index).Price);
        }

        //回傳在購物車單項商品的總價
        public string GetOneRowProductTotal(int index)
        {
            return AddPeriodInNumber(_model.GetOneRowProductPriceTotal(index));
        }

        //回傳現在total(有逗號)
        public string GetTotalWithPeriod()
        {
            return AddPeriodInNumber(_model.Total);
        }

        //判斷是否超過庫存
        public bool IsExcessInventory(int index, int amount)
        {
            string productName = _model.GetProductsInOrder(index).Name;
            int productAmount = _model.GetProductsInOrder(index).Inventory;
            if ( amount > _model.GetProductsInOrder(index).Inventory)
                return true;
            else
                return false;
        }

        //加入商品的按鈕是否Enable
        public bool IsAddProductButtonEnable()
        {
            if (_model.SelectedProduct == null)
                return false;
            return _model.SelectedProduct.Inventory > 0;
        }

        //BuyIt Enabled
        public bool IsBuyItButtonEnabled(int rowAmount)
        {
            if (rowAmount == 0)
                return false;
            else
                return true;

        }
    }
}
