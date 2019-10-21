using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DataGridViewNumericUpDownElements;

namespace _106590018_Homework
{
    public partial class OrderForm : Form
    {
        private List<string> _typeList;
        private Model _model;
        private OrderPresentationModel _presentationModel;
        const int NOW_PAGE_BIG = 1;
        const int ALL_PAGE_BIG = -1;
        const int NOW_ALL_SAME = 0;
        const int AMOUNT_INDEX = 4;

        public OrderForm(Model model)
        {
            this._model = model;
            this._presentationModel = new OrderPresentationModel(model);
            _model._modelChanged += UpdateView;
            InitializeComponent();
            _typeList = _model.TypeList;
            InitializeProductButton();
            InitializePageButtonAndPage();
            InitializeDataGridView();
            _addProduct.Enabled = _presentationModel.IsAddProductButtonEnable();
            _buyIt.Enabled = _presentationModel.IsBuyItButtonEnabled(_orderForm.RowCount);
            this.Text = "訂單系統";
        }

        //設定頁數
        private void SetPageLabel(int nowPage, int allPage)
        {
            _page.Text = _presentationModel.GetPageText();
        }

        //商品是否在需要顯示的編號內
        private bool IsProductInPrintRanges(int count, string direction)
        {
            return _presentationModel.IsProductInPrintRange(count, direction);
        }

        //新加一個Button
        private void AddButton(TableLayoutPanel layoutName, int id)
        {
            Product product = _model.GetProductById(id);
            ProductButton button = new ProductButton(id);
            layoutName.Controls.Add(button, 0, 0);
            button.Dock = System.Windows.Forms.DockStyle.Fill;
            button.Name = product.Name;
            button.Tag = product.Type;
            button.Image = Image.FromFile(DataManagement.GetSystemDirection() + @"\picture\" + product.Name + @".jpg");
            button.Click += new System.EventHandler(this.ClickProduct);
            button.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //選擇加入的LayoutPanel
        private TableLayoutPanel FindAddTableLayoutPanel(int count)
        {
            const string ELEMENT = "_tableLayoutPanel";
            string searchName = ELEMENT + (count + 1).ToString();
            _tableControl1.SelectedIndex = count;
            return (TableLayoutPanel)_tableControl1.SelectedTab.Controls.Find(searchName, true)[0];
        }

        //清除所有button In TableLayout
        private void ClearAllButtonInTab(TableLayoutPanel tableLayout)
        {
            tableLayout.Controls.Clear();
        }

        //PageUpButton是否要啟動
        private bool IsPageUpEnable()
        {
            return (!_presentationModel.IsNowInFirstPage());
        }

        //PageDownButton是否要啟動
        private bool IsPageDownEnable()
        {
            return (!(_presentationModel.GetRelationOfNowPageAndAllPage() == NOW_ALL_SAME));
        }

        //選擇不同商品頁面
        private void ClearIntroductionAndPrice()
        {
            _introduction.Text = "";
            _price.Text = "";
            _inventory.Text = "";
            _model.ClearSelectedProduct();
        }

        //更新資訊 + 判斷
        private void UpdateView()
        {
            if (!_presentationModel.IsSelectedProductNull())
            {
                RefreshView();
            }
            _total.Text = _presentationModel.GetTotalWithPeriod();
            _addProduct.Enabled = _presentationModel.IsAddProductButtonEnable();
            _buyIt.Enabled = _presentationModel.IsBuyItButtonEnabled(_orderForm.RowCount);
        }

        //更新View
        private void RefreshView()
        {
            _inventory.Text = _model.SelectedProduct.Inventory.ToString();
            _introduction.Text = _model.GetSelectProductIntroduction();
            _price.Text = _presentationModel.GetSelectedProductWithPeriod();
        }

        /// <summary>
        /// /////////////////////////////////////////////big function/////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //切換頁面
        private void ChangeTab(object sender, EventArgs e)
        {
            _upPage.Enabled = false;
            _presentationModel.NowPage = 1;          
            _presentationModel.AllPage = _model.GetAllPageInOneType(_typeList[_tableControl1.SelectedIndex]);
            if (_presentationModel.GetRelationOfNowPageAndAllPage() == ALL_PAGE_BIG)
            {
                _downPage.Enabled = true;
            }
            else
                _downPage.Enabled = false;
            _page.Text = _presentationModel.GetPageText();
            ClearIntroductionAndPrice();
        }

        //加入數量和總價的column
        private void InitializeDataGridView()
        {
            DataGridViewNumericUpDownColumn upDown = new DataGridViewNumericUpDownColumn();
            upDown.HeaderText = "數量";
            upDown.Width = 60;
            upDown.Name = "_proudctAmount";
            _orderForm.Columns.Add(upDown);
            DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
            total.HeaderText = "總價";
            total.Width = 100;
            _orderForm.Columns.Add(total);
        }

        //初始化 上下按鈕和Page數字
        private void InitializePageButtonAndPage()
        {
            int startType = 0;
            _presentationModel.AllPage = _model.GetAllPageInOneType(_typeList[startType]);
            _page.Text = _presentationModel.GetPageText();
            _upPage.Enabled = false;
            if (_presentationModel.GetRelationOfNowPageAndAllPage() != ALL_PAGE_BIG)
            {
                _downPage.Enabled = false;
            }
        }

        //初始化商品按鈕
        private void InitializeProductButton()
        {
            List<int> eachTypeAmount = _model.EachTypeAmount;
            for (int index = 0; index < _typeList.Count; index++)
            {
                AddButtonsInTab(eachTypeAmount, index);
            }
        }

        //更新一組Button
        private void UpdateButtons(string direction)
        {
            int tabIndex = _tableControl1.SelectedIndex;
            string selectType = _typeList[tabIndex];
            int count = 0;
            int id = 1;
            ClearAllButtonInTab(FindAddTableLayoutPanel(tabIndex));
            while (_presentationModel.IsNowPageSmallOrEqualAllPage() &&
                _model.GetProductById(id) != null)
            {
                if (_model.GetProductById(id).Type == selectType)
                {
                    count++; //第N個同種商品
                    if (IsProductInPrintRanges(count, direction))
                        AddButton(FindAddTableLayoutPanel(tabIndex), id);                               
                }
                id++;
            }
        }

        //加入button在Tab
        private void AddButtonsInTab(List<int> eachTypeAmount, int index)
        {
            int productCount = 0;
            int id = 1;        

            TableLayoutPanel selected = FindAddTableLayoutPanel(index);
            while (_presentationModel.IsCountSameButtonAmount(productCount, eachTypeAmount[index]))
            {
                if (_model.GetProductById(id).Type == _typeList[index])
                {
                    AddButton(selected, id);
                    productCount++;
                }
                id++;
            }
            _tableControl1.SelectedIndex++;
        }

        //Button Click
        private void ClickProduct(object sender, EventArgs e)
        {
            int productId = ((ProductButton)(sender)).Id;
            _model.SetSelectedProduct(productId);
            UpdateView();
        }

        //Add Product
        private void AddProductInGridView(object sender, EventArgs e)
        {
            Product selectedProduct = _model.SelectedProduct;
            if (_model.IsSameProductInOrder())
            {
                MessageBox.Show("商品已存在於購物清單中");
                return;
            }
            if (_model.AddProductInOrder()) //如果加入商品成功
            {
                string price = _presentationModel.GetSelectedProductWithPeriod();
                _orderForm.Rows.Add(_deleteButton, selectedProduct.Name, selectedProduct.Type, price, 1, price); //加入在我的定案單
                //((DataGridViewNumericUpDownCell)(_orderForm.Rows[_orderForm.RowCount - 1].Cells[AMOUNT_INDEX])).Maximum = _model.GetProductsInOrder(_orderForm.RowCount - 1).Inventory;
                ((DataGridViewNumericUpDownCell)(_orderForm.Rows[_orderForm.RowCount - 1].Cells[AMOUNT_INDEX])).Minimum = 1;
                UpdateView();
            }
        }

        //刪除在購商車內的商品
        private void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;       
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                _model.DeleteProductInOrder(e.RowIndex);
                _orderForm.Rows.RemoveAt(e.RowIndex);
            }
            UpdateView();
        }

        //點選上下頁Button
        private void ClickPageButton(object sender, EventArgs e)
        {
            UpdateButtons(((Button)(sender)).Tag.ToString());
            _presentationModel.UpdateNowAndAllPage(((Button)(sender)).Tag.ToString());
            SetPageLabel(((Button)(sender)).Tag.ToString());
        }

        //當UpOrDownPage被點即時，改變Pagelabel
        private void SetPageLabel(string direction)
        {   
            if (_presentationModel.IsUpPage(direction))
            {                   
                _downPage.Enabled = true;
                _upPage.Enabled = IsPageUpEnable();
            }
            else
            {
                _upPage.Enabled = true;
                _downPage.Enabled = IsPageDownEnable();                             
            }
            _page.Text = _presentationModel.GetPageText();
            ClearIntroductionAndPrice();
        }

        //顯是輸入信用卡資訊的FORM
        private void BuyIt(object sender, EventArgs e)
        {
            CreditCardForm creditCardForm = new CreditCardForm(_model);
            if (creditCardForm.ShowDialog() == DialogResult.OK)
            {
                _orderForm.Rows.Clear();
            }
            
        }

        //畫DeleteButton的Icon
        private void PaintGridCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const int TWO = 2 ;
            if (e.RowIndex < 0)
                return;
            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                Image img = Image.FromFile(DataManagement.GetSystemDirection() + @"\picture\" + @"DeleteImage.jpg");
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / TWO;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / TWO;
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //當訂單內的數量改變的時候
        private void UpdateTotalInOrder(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.ColumnIndex == AMOUNT_INDEX)
            {
                int amount = int.Parse(_orderForm.Rows[e.RowIndex].Cells[AMOUNT_INDEX].Value.ToString());
                if (_presentationModel.IsExcessInventory(e.RowIndex, amount))
                {
                    MessageBox.Show("超過庫存");
                    _orderForm.Rows[e.RowIndex].Cells[AMOUNT_INDEX].Value = _model.GetProductsInOrder(e.RowIndex).Inventory;
                }
                else
                {
                    RefreshTotal(e.RowIndex, amount);
                }
            }
        }

        //更新total
        private void RefreshTotal(int index, int amount)
        {
            const int TOTAL_COLUMN = 5;
            _model.UpdateAmountInOrder(index, amount);
            _orderForm.Rows[index].Cells[TOTAL_COLUMN].Value = _presentationModel.GetOneRowProductTotal(index);
            _total.Text = _presentationModel.GetTotalWithPeriod();
        }
        
        //更新有關庫存的資料
        private void UpdateInventory()
        {
            const string SAME = "same";
            UpdateButtons(SAME);
            Refresh();
        }
    }
}
