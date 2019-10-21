using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
namespace _106590018_Homework
{
    class DataManagement
    {
        private const int NAME_COLUMN = 0;
        private const int PRICE_COLUMN = 1;
        private const int INTRODUCTION_COLUMN = 2;
        private const int TYPE_COLUMN = 3;
        private const int INVENTORY = 4;
        private const int TYPE_AMOUNT = 6;

        private string _path = "";
        private _Application _excel = new _Excel.Application();
        private Workbook _workBook;
        private Worksheet _workSheet;
        private const int IGNORE_LENGTH = 9;

        //Constructor
        public DataManagement(string path, int sheet)
        {
            this._path = path;
            this._workBook = _excel.Workbooks.Open(path);
            this._workSheet = _workBook.Worksheets[sheet];
        }

        //獲得路徑
        public static String GetSystemDirection()
        {            
            string direction = System.Environment.CurrentDirectory;
            return direction.Substring(0, direction.Length - IGNORE_LENGTH);
        }

        //關閉Excel
        public void CloseExcel()
        {
            _workBook.Close(true);
            _excel.Quit();
        }

        //LoadAllProduct
        public void LoadProduct(List<Product> products)
        {
            int id = 1;

            while (GetProductName(id).Length > 0)
            {
                int productId = id;
                string productName = GetProductName(id);
                int productPrice = GetProductPrice(id);
                string productIntroduction = GetProductIntroduction(id);
                string productType = GetProductType(id);
                int productInventory = GetProductInventory(id);
                Product newProduct = new Product(productId, productName, productType, productPrice, productIntroduction, productInventory);
                products.Add(newProduct);
                id++;
            }
        }

        //回傳格子的字
        public dynamic ReadCell(int row, int column)
        {
            row++;
            column++;
            if (_workSheet.Cells[row, column].Value2 != null)
                return _workSheet.Cells[row, column].Value2;
            else
                return "";
        }

        //回傳點選商品的名稱
        public string GetProductName(int row)
        {
            return ReadCell(row, NAME_COLUMN);
        }

        //回傳點選商品的名稱
        public int GetProductPrice(int row)
        {
            return Convert.ToInt32(ReadCell(row, PRICE_COLUMN));
        }

        //回傳點選商品的名稱
        public string GetProductType(int row)
        {
            return ReadCell(row, TYPE_COLUMN);
        }

        //回傳商品介紹
        public string GetProductIntroduction(int row)
        {
            return ReadCell(row, INTRODUCTION_COLUMN);
        }

        //回傳商品的庫存量
        public int GetProductInventory(int row)
        {
            return Convert.ToInt32(ReadCell(row, INVENTORY));
        }
    }
}
