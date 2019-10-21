using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop_System;

namespace Shop_System
{
    public partial class OrderSystem : Form
    {
        private PresentationModelOfOrderSystem _presentationModel = new PresentationModelOfOrderSystem();
        public OrderSystem(ref ModelData model)
        {
            InitializeComponent();
            _presentationModel.Initialize(ref model, this);
            this._upPage.Click += new System.EventHandler(_presentationModel.ClickUpPage);
            this._downPage.Click += new System.EventHandler(_presentationModel.ClickDownPage);
            this._shopList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(_presentationModel.PaintCellContentShopList);
            _presentationModel.UpdateTabPages();
        }

        // Add product to shopping cart
        private void AddProductClick(object sender, EventArgs e)
        {
            _presentationModel.AddProductToCart();
            _presentationModel.UpdateCost();
        }

        // Reset product info
        private void ResetProductInfo(object sender, EventArgs e)
        {
            _productInfo.Text = "";
            _productPrice.Text = "";
            _addProduct.Enabled = false;
        }

        // When changing tab of tabpages
        private void ChangeProductsSelectedIndex(object sender, EventArgs e)
        {
            _presentationModel.UpdateTabPageNumber(_products.SelectedTab.Text, 0);
            ResetProductInfo(sender, e);
        }

        // Click delete button
        private void ClickCellContentShopList(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.RemoveProductFromCart(e.ColumnIndex, e.RowIndex);
            _presentationModel.UpdateCost();
        }

        // Open credit card payment form
        private void ClickOrder(object sender, EventArgs e)
        {
            _presentationModel.FinishOrder(new CreditCardPayment().ShowDialog());
        }

        // Process categories
        public TabPage ProcessCategories(string cat)
        {
            if (_products.TabPages[cat] != null)
            {
                _products.SelectedTab = _products.TabPages[cat];
            }
            else
            {
                _products.TabPages.Add(cat, cat);
            }
            return _products.TabPages[cat];
        }

        // Create product button from parameters
        public void CreateButtonFromParameters(int counter, PresentationModelOfOrderSystem.Product product)
        {
            const int SCROLL_BAR_WIDTH = 26;
            const int ROWS = 2;
            const int COLUMNS = 3;
            ProcessCategories(product.GetCat()).Controls.Add(_presentationModel.CreateProductButton(product.GetName(),
                new List<int>
                {
                    (int)(counter / COLUMNS) * (_products.Height - SCROLL_BAR_WIDTH) / ROWS,(counter % COLUMNS) * (_products.Width) / COLUMNS,(_products.Width) / COLUMNS,(_products.Height - SCROLL_BAR_WIDTH) / ROWS
                }, ModelData.GetImageByName(product.GetName(), (_products.Width) / COLUMNS, (_products.Height - SCROLL_BAR_WIDTH) / ROWS)));
        }

        // Get _shopList
        public DataGridView GetShopList()
        {
            return _shopList;
        }

        // Get _products
        public TabControl GetProducts()
        {
            return _products;
        }

        // Get _upPage
        public Button GetUpPage()
        {
            return _upPage;
        }

        // Get _downPage
        public Button GetDownPage()
        {
            return _downPage;
        }

        // Get _pageLabel
        public Label GetPageLabel()
        {
            return _pageLabel;
        }

        // Get _productInfo
        public RichTextBox GetProductInfo()
        {
            return _productInfo;
        }

        // Get _productPrice
        public Label GetProductPrice()
        {
            return _productPrice;
        }

        // Get _addProduct
        public Button GetAddProduct()
        {
            return _addProduct;
        }

        // Get _total
        public Label GetTotal()
        {
            return _total;
        }

        // Get _order
        public Button GetOrder()
        {
            return _order;
        }
    }
}
