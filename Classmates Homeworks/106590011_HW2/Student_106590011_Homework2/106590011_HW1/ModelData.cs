using System.Data.OleDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Shop_System
{
    public class ModelData
    {
        public const string NAME_INDEX = "商品名稱";
        public const string CAT_INDEX = "商品類別";
        public const string INFO_INDEX = "內容";
        public const string PRICE_INDEX = "單價";
        public const string DELETE_COLUMN = "刪除";

        private DataTable _data = new DataTable();
        private DataTable _cart = new DataTable();
        private const string FILE_INFO =
                "Data Source=..\\..\\data.xls;" +
                "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Extended Properties='Excel 8.0;" +
                "HDR=Yes;" +
                "IMEX=0';";

        // Get raw database
        public DataTable GetData()
        {
            return _data;
        }

        // Get shoppingcart
        public DataTable GetShopList()
        {
            return _cart;
        }

        // Get shooping cart total amount of money
        public int GetShopCost()
        {
            int total = 0;
            const string PRICE_INDEX = "單價";
            for (int i = 0; i < _cart.Rows.Count; i++)
                total += Convert.ToInt32(_cart.Rows[i][PRICE_INDEX].ToString());
            return total;
        }

        // Update database from file
        public void UpdateData()
        {
            using (OleDbConnection cn = new OleDbConnection(FILE_INFO))
            {
                cn.Open();
                const string qs = "select * from[工作表1$]";
                const string sortBy = "商品類別";
                using (OleDbDataAdapter dr = new OleDbDataAdapter(qs, cn))
                {
                    dr.Fill(_data);
                    _data.DefaultView.Sort = sortBy;
                    _cart = _data.Clone();
                }
            }
        }

        // Get image of product, if not exsit then use default image
        public static Image GetImageByName(string name, int width, int height)
        {
            const string DIRECTORY = @"..\\..\\img\\";
            const string PNG_EXTENSION = ".jpg";
            const string PATH_DIRECTORY = "..\\..\\img\\add.jpg";
            string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
            string path = PATH_DIRECTORY;
            string pathName = name;
            foreach (char c in invalid)
                pathName = pathName.Replace(c.ToString(), "");
            foreach (var file in GetPathFiles(DIRECTORY, PNG_EXTENSION))
                if (file.Contains(pathName))
                    path = file;
            return (Image)(new Bitmap(Image.FromFile(path), new Size(width, height)));
        }

        // Get name of files by directory
        public static List<string> GetPathFiles(string path, params string[] extensions)
        {
            const string ALL_FILE_EXTENSION = "*.*";
            List<string> filePath = new List<string>();
            var files = System.IO.Directory.EnumerateFiles(path, ALL_FILE_EXTENSION, System.IO.SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (extensions.Contains(System.IO.Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                    filePath.Add(file);
            };
            return filePath;
        }
    }
}
