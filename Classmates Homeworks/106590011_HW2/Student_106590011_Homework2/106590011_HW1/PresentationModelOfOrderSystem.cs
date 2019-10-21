using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_System
{
    public class PresentationModelOfOrderSystem
    {
        public struct Product
        {
            private string _name;
            private string _cat;
            private string _info;
            private int _price;

            public Product(string name, string cat, string info, int price) : this()
            {
                this._name = name;
                this._cat = cat;
                this._info = info;
                this._price = price;
            }
            // Get name
            public string GetName()
            {
                return _name;
            }
            // Get cat
            public string GetCat()
            {
                return _cat;
            }
            // Get info
            public string GetInfo()
            {
                return _info;
            }
            // Get price
            public int GetPrice()
            {
                return _price;
            }
        }
        private OrderSystem _orderSystem;

        private Dictionary<string, List<List<Product>>> _pages = new Dictionary<string, List<List<Product>>>();
        private const int SIX = 6;

        private int _pageNumber;
        private String _selected = "";
        private DataTable _data;
        private DataTable _cart;
        private ModelData _model;
        public const string TRASH_CAN = "🗑";
        
        //Initialize PresentationModel
        public void Initialize(ref ModelData model, OrderSystem orderSystem)
        {
            _orderSystem = orderSystem;
            _model = model;
            _data = _model.GetData();
            _cart = _model.GetShopList();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            _orderSystem.GetShopList().Columns.Add(buttonColumn);
            _orderSystem.GetShopList().DataSource = _cart;
            _orderSystem.GetShopList().Columns[ModelData.INFO_INDEX].Visible = false;
            buttonColumn.Name = ModelData.DELETE_COLUMN;
            buttonColumn.UseColumnTextForButtonValue = true;
            ProcessPages(_data);
        }

        // Get CreditCardPayment form return value and determine weather should clear _cart
        internal void FinishOrder(DialogResult dialogResult)
        {
            if (dialogResult == DialogResult.OK)
                _cart.Clear();
            UpdateCost();
        }

        // When clicked the auto-generated-button of products
        public void SelectProduct(object sender, EventArgs e)
        {
            const string LINE_BREAK = "\n";
            const string SPECIAL_LINE_BREAK = "¶";
            const string PRICE_CAP = "單價：";
            string name = ((Button)sender).Name;
            for (int i = 0; i < _data.Rows.Count; i++)
            {
                if (_data.Rows[i][0].ToString() == name)
                {
                    _selected = name.ToString();
                    _orderSystem.GetProductInfo().Text = _data.Rows[i][ModelData.NAME_INDEX].ToString() + LINE_BREAK + _data.Rows[i][ModelData.INFO_INDEX].ToString().Replace(SPECIAL_LINE_BREAK, LINE_BREAK);
                    _orderSystem.GetProductPrice().Text = PRICE_CAP + _data.Rows[i][ModelData.PRICE_INDEX].ToString();
                    _orderSystem.GetAddProduct().Enabled = true;
                }
            }
        }

        // Paint delete button
        public void PaintCellContentShopList(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                Image img = Order_System.Properties.Resources.trashcan;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                const int TWO = 2;
                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / TWO;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / TWO;
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        // Process _pages from DataTable
        public void ProcessPages(DataTable data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ProcessRow(data.Rows[i], data.Rows[i][ModelData.CAT_INDEX].ToString());
            }
        }

        // Add product to one page
        private void ProcessRow(DataRow row, string cat)
        {
            if (_pages.ContainsKey(row[ModelData.CAT_INDEX].ToString()))
            {
                if (_pages[cat][_pages[cat].Count - 1].Count.Equals(SIX))
                    _pages[cat].Add(new List<Product>
                    {
                        CreateProduct(row)
                    });
                else
                    _pages[cat][_pages[cat].Count - 1].Add(CreateProduct(row));
            }
            else
                _pages.Add(cat, new List<List<Product>>
                    {
                        CreateProductList(CreateProduct(row))
                    });
        }

        // Get _pages
        public Dictionary<string, List<List<Product>>> GetPages()
        {
            return _pages;
        }

        // Create product
        private Product CreateProduct(DataRow row)
        {
            return new Product(row[ModelData.NAME_INDEX].ToString(), row[ModelData.CAT_INDEX].ToString(), row[ModelData.INFO_INDEX].ToString(), Convert.ToInt32(row[ModelData.PRICE_INDEX].ToString()));
        }

        // Create product list
        private List<Product> CreateProductList(Product product)
        {
            return new List<Product>
            {
                product
            };
        }

        // Add product to shopping cart
        public void AddProductToCart()
        {
            for (int i = 0; i < _data.Rows.Count; i++)
                if (_data.Rows[i][0].ToString() == _selected)
                {
                    DataRow row = _cart.NewRow();
                    row[ModelData.NAME_INDEX] = _data.Rows[i][ModelData.NAME_INDEX];
                    row[ModelData.CAT_INDEX] = _data.Rows[i][ModelData.CAT_INDEX];
                    row[ModelData.PRICE_INDEX] = _data.Rows[i][ModelData.PRICE_INDEX];
                    _cart.Rows.Add(row);
                }
        }

        // Update shopping cart cost
        public void UpdateCost()
        {
            int totalCost = _model.GetShopCost();
            const string TOTAL_PRICE_CAP = "總金額：";
            _orderSystem.GetTotal().Text = TOTAL_PRICE_CAP + totalCost.ToString();
            _orderSystem.GetOrder().Enabled = (totalCost == 0 ? false : true);
        }

        // Remove product from shopping cart
        public void RemoveProductFromCart(int column, int selected)
        {
            if (column == 0)
                _orderSystem.GetShopList().Rows.RemoveAt(selected);
        }

        // Verify email address
        public static bool CheckValidMail(string mail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail);
                return addr.Address == mail;
            }
            catch
            {
                return false;
            }
        }

        // Update TabPage number label and buttons
        public void UpdateTabPageNumber(string cat, int pageNumber)
        {
            const string PAGE = "Page：";
            const string SLASH = "/";
            _pageNumber = pageNumber;
            int total = _pages[cat].Count;
            _orderSystem.GetUpPage().Enabled = (_pageNumber == 0 ? false : true);
            _orderSystem.GetDownPage().Enabled = (_pageNumber + 1 == total ? false : true);
            _orderSystem.GetPageLabel().Text = PAGE + (_pageNumber + 1).ToString() + SLASH + total.ToString();
        }

        // Click _upPage button to go last page
        public void ClickUpPage(object sender, EventArgs e)
        {
            _orderSystem.GetProducts().SelectedTab.Controls.Clear();
            UpdateTabPage(_orderSystem.GetProducts().SelectedTab.Text, _pageNumber - 1);
        }

        // Click _downPage button to go next page
        public void ClickDownPage(object sender, EventArgs e)
        {
            _orderSystem.GetProducts().SelectedTab.Controls.Clear();
            UpdateTabPage(_orderSystem.GetProducts().SelectedTab.Text, _pageNumber + 1);
        }

        // Update one page of category
        public void UpdateTabPage(string cat, int pageNumber)
        {
            List<Product> page = _pages[cat][pageNumber];
            for (int counter = 0; counter < page.Count; counter++)
            {
                _orderSystem.CreateButtonFromParameters(counter, page[counter]);
            }
            UpdateTabPageNumber(cat, pageNumber);
        }

        // Auto generate product button
        public Button CreateProductButton(string name, List<int> parameters, Image image)
        {
            const int PARAMETER0 = 0;
            const int PARAMETER1 = 1;
            const int PARAMETER2 = 2;
            const int PARAMETER3 = 3;
            Button button = new Button();
            button.Name = name;
            button.Width = parameters[PARAMETER2];
            button.Height = parameters[PARAMETER3];
            button.Top = parameters[PARAMETER0];
            button.Left = parameters[PARAMETER1];
            button.Image = image;
            button.Click += new EventHandler(SelectProduct);
            return button;
        }

        // Generate products buttons to Tabpages
        public void UpdateTabPages()
        {
            _orderSystem.GetProducts().TabPages.Clear();
            foreach (KeyValuePair<string, List<List<PresentationModelOfOrderSystem.Product>>> item in _pages)
                UpdateTabPage(item.Key, 0);
            _orderSystem.GetProducts().SelectedTab = _orderSystem.GetProducts().TabPages[0];
        }
    }
}
