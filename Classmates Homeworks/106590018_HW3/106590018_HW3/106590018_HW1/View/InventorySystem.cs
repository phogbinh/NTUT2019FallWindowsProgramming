using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106590018_Homework
{
    public partial class InventorySystem : Form
    {
        private Model _model;
        private List<Product> _products;
        private const int NAME_INDEX = 0;
        private const int TYPE_INDEX = 1;
        private const int PRICE_INDEX = 2;
        private const int INVENTORY_INDEX = 3;
        private const int REPLENISHMENT_INDEX = 4;
        private const string COLUMN1_NAME = "商品名稱";
        private const string COLUMN2_NAME = "商品種類";
        private const string COLUMN3_NAME = "商品價格";
        private const string COLUMN4_NAME = "商品數量";
        private const string COLUMN5_NAME = "補貨";
        private int _inventoryAmount;

        public int InventoryAmount
        {
            set
            {
                _inventoryAmount = value;
            }
        }

        public InventorySystem(Model model)
        {
            this._model = model;
            _model._modelChanged += RefreshForm;
            _products = _model.Products;
            InitializeComponent();
            InitializeColumnsDataGridView();
            AddProductsInOrder();
        }

        //初始化DataGridView的欄位
        private void InitializeColumnsDataGridView()
        {   
            DataGridViewTextBoxColumn productName = new DataGridViewTextBoxColumn();
            productName.HeaderText = COLUMN1_NAME;
            DataGridViewTextBoxColumn productType = new DataGridViewTextBoxColumn();
            productType.HeaderText = COLUMN2_NAME;
            DataGridViewTextBoxColumn productPrice = new DataGridViewTextBoxColumn();
            productPrice.HeaderText = COLUMN3_NAME;
            DataGridViewTextBoxColumn productInventory = new DataGridViewTextBoxColumn();
            productInventory.HeaderText = COLUMN4_NAME;
            DataGridViewButtonColumn replenishment = new DataGridViewButtonColumn();
            replenishment.HeaderText = COLUMN5_NAME;
            _inventoryDataGridView.Columns.Add(productName);
            _inventoryDataGridView.Columns.Add(productType);
            _inventoryDataGridView.Columns.Add(productPrice);
            _inventoryDataGridView.Columns.Add(productInventory);
            _inventoryDataGridView.Columns.Add(replenishment);
        }

        //將商品資料加入到DataGrudView
        private void AddProductsInOrder()
        {
            InitializeColumnsDataGridView();
            for (int index = 0; index < _products.Count; index++)
            {
                Product product = _products[index];
                _inventoryDataGridView.Rows.Add(product.Name, product.Type, product.Price, product.Inventory);
            }
        }

        //顯示商品的圖片和介紹
        private void ShowImageAndIntroduction(object sender, DataGridViewCellEventArgs e)
        {
            Image image = System.Drawing.Bitmap.FromFile(DataManagement.GetSystemDirection() + @"\picture\" + _products[e.RowIndex].Name + @".jpg");
            _introduction.Text = _products[e.RowIndex].Introduction;
            _image.Image = image;
        }

        //畫上補貨的圖片
        private void PaintGridCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const int TWO = 2;
            const int REPLENISHMENT_INDEX = 4;
            if (e.RowIndex < 0)
                return;
            //I supposed your button column is at index 0
            if (e.ColumnIndex == REPLENISHMENT_INDEX)
            {
                Image img = Image.FromFile(DataManagement.GetSystemDirection() + @"\picture\" + @"truck.jpg");
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / TWO;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / TWO;
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }        
        }

        //按下補貨時 增加庫存數量
        private void AddInventory(object sender, DataGridViewCellEventArgs e)
        {   
            string name = _inventoryDataGridView.Rows[e.RowIndex].Cells[NAME_INDEX].Value.ToString();
            string type = _inventoryDataGridView.Rows[e.RowIndex].Cells[TYPE_INDEX].Value.ToString();
            string price = _inventoryDataGridView.Rows[e.RowIndex].Cells[PRICE_INDEX].Value.ToString();
            string inventory = _inventoryDataGridView.Rows[e.RowIndex].Cells[INVENTORY_INDEX].Value.ToString();
            ReplenishmentForm replenishmentform = new ReplenishmentForm(name, type, price, inventory);
            replenishmentform.Owner = this;
            replenishmentform.ShowDialog();
            UpdateModelProducts(e.RowIndex, _inventoryAmount);
        }

        //呼叫model　更新存貨
        private void UpdateModelProducts(int index, int amount)
        {
            _model.UpdateInventory(index, amount);
        }

        //更新畫面
        private void RefreshForm()
        {
            _products = _model.Products;
            _inventoryDataGridView.Rows.Clear();
            AddProductsInOrder();
        }
    }
}
