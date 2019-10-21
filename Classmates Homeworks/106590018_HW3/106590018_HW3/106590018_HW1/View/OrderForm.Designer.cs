namespace _106590018_Homework
{
    partial class OrderForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._downPage = new System.Windows.Forms.Button();
            this._upPage = new System.Windows.Forms.Button();
            this._page = new System.Windows.Forms.Label();
            this._pageLabel = new System.Windows.Forms.Label();
            this._addProduct = new System.Windows.Forms.Button();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._inventory = new System.Windows.Forms.Label();
            this._inventoryLabel = new System.Windows.Forms.Label();
            this._price = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._introduction = new System.Windows.Forms.RichTextBox();
            this._tableControl1 = new System.Windows.Forms.TabControl();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._tabPage3 = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._tabPage4 = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this._tabPage5 = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this._tabPage6 = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this._orderForm = new System.Windows.Forms.DataGridView();
            this._deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._orderLabel = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._total = new System.Windows.Forms.Label();
            this._buyIt = new System.Windows.Forms.Button();
            this._groupBox1.SuspendLayout();
            this._groupBox2.SuspendLayout();
            this._tableControl1.SuspendLayout();
            this._tabPage1.SuspendLayout();
            this._tabPage2.SuspendLayout();
            this._tabPage3.SuspendLayout();
            this._tabPage4.SuspendLayout();
            this._tabPage5.SuspendLayout();
            this._tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._orderForm)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._downPage);
            this._groupBox1.Controls.Add(this._upPage);
            this._groupBox1.Controls.Add(this._page);
            this._groupBox1.Controls.Add(this._pageLabel);
            this._groupBox1.Controls.Add(this._addProduct);
            this._groupBox1.Controls.Add(this._groupBox2);
            this._groupBox1.Controls.Add(this._tableControl1);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this._groupBox1.Font = new System.Drawing.Font("新細明體", 16F);
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(465, 556);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "商品";
            // 
            // _downPage
            // 
            this._downPage.Image = ((System.Drawing.Image)(resources.GetObject("_downPage.Image")));
            this._downPage.Location = new System.Drawing.Point(312, 472);
            this._downPage.Name = "_downPage";
            this._downPage.Size = new System.Drawing.Size(50, 61);
            this._downPage.TabIndex = 7;
            this._downPage.Tag = "downpage";
            this._downPage.UseVisualStyleBackColor = true;
            this._downPage.Click += new System.EventHandler(this.ClickPageButton);
            // 
            // _upPage
            // 
            this._upPage.Image = ((System.Drawing.Image)(resources.GetObject("_upPage.Image")));
            this._upPage.Location = new System.Drawing.Point(258, 472);
            this._upPage.Name = "_upPage";
            this._upPage.Size = new System.Drawing.Size(48, 61);
            this._upPage.TabIndex = 6;
            this._upPage.Tag = "uppage";
            this._upPage.UseVisualStyleBackColor = true;
            this._upPage.Click += new System.EventHandler(this.ClickPageButton);
            // 
            // _page
            // 
            this._page.AutoSize = true;
            this._page.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._page.Location = new System.Drawing.Point(131, 479);
            this._page.Name = "_page";
            this._page.Size = new System.Drawing.Size(0, 44);
            this._page.TabIndex = 4;
            // 
            // _pageLabel
            // 
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._pageLabel.Location = new System.Drawing.Point(8, 482);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(114, 45);
            this._pageLabel.TabIndex = 0;
            this._pageLabel.Text = "Page:";
            // 
            // _addProduct
            // 
            this._addProduct.Image = ((System.Drawing.Image)(resources.GetObject("_addProduct.Image")));
            this._addProduct.Location = new System.Drawing.Point(385, 462);
            this._addProduct.Name = "_addProduct";
            this._addProduct.Size = new System.Drawing.Size(64, 62);
            this._addProduct.TabIndex = 3;
            this._addProduct.UseVisualStyleBackColor = true;
            this._addProduct.Click += new System.EventHandler(this.AddProductInGridView);
            // 
            // _groupBox2
            // 
            this._groupBox2.Controls.Add(this._inventory);
            this._groupBox2.Controls.Add(this._inventoryLabel);
            this._groupBox2.Controls.Add(this._price);
            this._groupBox2.Controls.Add(this._priceLabel);
            this._groupBox2.Controls.Add(this._introduction);
            this._groupBox2.Location = new System.Drawing.Point(12, 318);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Size = new System.Drawing.Size(443, 120);
            this._groupBox2.TabIndex = 2;
            this._groupBox2.TabStop = false;
            this._groupBox2.Text = " 商品介紹";
            // 
            // _inventory
            // 
            this._inventory.AutoSize = true;
            this._inventory.Location = new System.Drawing.Point(356, 44);
            this._inventory.Name = "_inventory";
            this._inventory.Size = new System.Drawing.Size(0, 22);
            this._inventory.TabIndex = 6;
            // 
            // _inventoryLabel
            // 
            this._inventoryLabel.AutoSize = true;
            this._inventoryLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this._inventoryLabel.Location = new System.Drawing.Point(296, 44);
            this._inventoryLabel.Name = "_inventoryLabel";
            this._inventoryLabel.Size = new System.Drawing.Size(54, 22);
            this._inventoryLabel.TabIndex = 3;
            this._inventoryLabel.Text = "庫存";
            // 
            // _price
            // 
            this._price.AutoSize = true;
            this._price.Location = new System.Drawing.Point(350, 87);
            this._price.Name = "_price";
            this._price.Size = new System.Drawing.Size(0, 22);
            this._price.TabIndex = 2;
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Location = new System.Drawing.Point(274, 87);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(60, 22);
            this._priceLabel.TabIndex = 1;
            this._priceLabel.Text = "單價:";
            // 
            // _introduction
            // 
            this._introduction.BackColor = System.Drawing.SystemColors.Menu;
            this._introduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._introduction.Location = new System.Drawing.Point(21, 32);
            this._introduction.Name = "_introduction";
            this._introduction.Size = new System.Drawing.Size(247, 77);
            this._introduction.TabIndex = 0;
            this._introduction.Text = "";
            // 
            // _tableControl1
            // 
            this._tableControl1.Controls.Add(this._tabPage1);
            this._tableControl1.Controls.Add(this._tabPage2);
            this._tableControl1.Controls.Add(this._tabPage3);
            this._tableControl1.Controls.Add(this._tabPage4);
            this._tableControl1.Controls.Add(this._tabPage5);
            this._tableControl1.Controls.Add(this._tabPage6);
            this._tableControl1.Font = new System.Drawing.Font("新細明體", 12F);
            this._tableControl1.Location = new System.Drawing.Point(12, 32);
            this._tableControl1.Name = "_tableControl1";
            this._tableControl1.SelectedIndex = 0;
            this._tableControl1.Size = new System.Drawing.Size(447, 280);
            this._tableControl1.TabIndex = 0;
            this._tableControl1.Tag = "";
            this._tableControl1.SelectedIndexChanged += new System.EventHandler(this.ChangeTab);
            // 
            // _tabPage1
            // 
            this._tabPage1.Controls.Add(this._tableLayoutPanel1);
            this._tabPage1.Location = new System.Drawing.Point(4, 26);
            this._tabPage1.Name = "_tabPage1";
            this._tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage1.Size = new System.Drawing.Size(439, 250);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Tag = "False";
            this._tabPage1.Text = "主機板";
            this._tabPage1.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.ColumnCount = 3;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 2;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(433, 244);
            this._tableLayoutPanel1.TabIndex = 2;
            // 
            // _tabPage2
            // 
            this._tabPage2.Controls.Add(this._tableLayoutPanel2);
            this._tabPage2.Location = new System.Drawing.Point(4, 26);
            this._tabPage2.Name = "_tabPage2";
            this._tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage2.Size = new System.Drawing.Size(439, 250);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Tag = "False";
            this._tabPage2.Text = "CPU";
            this._tabPage2.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel2
            // 
            this._tableLayoutPanel2.ColumnCount = 3;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 2;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(433, 244);
            this._tableLayoutPanel2.TabIndex = 2;
            // 
            // _tabPage3
            // 
            this._tabPage3.Controls.Add(this._tableLayoutPanel3);
            this._tabPage3.Location = new System.Drawing.Point(4, 26);
            this._tabPage3.Name = "_tabPage3";
            this._tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage3.Size = new System.Drawing.Size(439, 250);
            this._tabPage3.TabIndex = 2;
            this._tabPage3.Tag = "False";
            this._tabPage3.Text = "記憶體";
            this._tabPage3.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel3
            // 
            this._tableLayoutPanel3.ColumnCount = 3;
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel3.Name = "_tableLayoutPanel3";
            this._tableLayoutPanel3.RowCount = 2;
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel3.Size = new System.Drawing.Size(433, 244);
            this._tableLayoutPanel3.TabIndex = 1;
            // 
            // _tabPage4
            // 
            this._tabPage4.Controls.Add(this._tableLayoutPanel4);
            this._tabPage4.Location = new System.Drawing.Point(4, 26);
            this._tabPage4.Name = "_tabPage4";
            this._tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage4.Size = new System.Drawing.Size(439, 250);
            this._tabPage4.TabIndex = 3;
            this._tabPage4.Tag = "False";
            this._tabPage4.Text = "硬碟";
            this._tabPage4.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel4
            // 
            this._tableLayoutPanel4.ColumnCount = 3;
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel4.Name = "_tableLayoutPanel4";
            this._tableLayoutPanel4.RowCount = 2;
            this._tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel4.Size = new System.Drawing.Size(433, 244);
            this._tableLayoutPanel4.TabIndex = 1;
            // 
            // _tabPage5
            // 
            this._tabPage5.Controls.Add(this._tableLayoutPanel5);
            this._tabPage5.Location = new System.Drawing.Point(4, 26);
            this._tabPage5.Name = "_tabPage5";
            this._tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage5.Size = new System.Drawing.Size(439, 250);
            this._tabPage5.TabIndex = 4;
            this._tabPage5.Tag = "False";
            this._tabPage5.Text = "顯示卡";
            this._tabPage5.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel5
            // 
            this._tableLayoutPanel5.ColumnCount = 3;
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel5.Name = "_tableLayoutPanel5";
            this._tableLayoutPanel5.RowCount = 2;
            this._tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel5.Size = new System.Drawing.Size(433, 244);
            this._tableLayoutPanel5.TabIndex = 1;
            // 
            // _tabPage6
            // 
            this._tabPage6.Controls.Add(this._tableLayoutPanel6);
            this._tabPage6.Location = new System.Drawing.Point(4, 26);
            this._tabPage6.Name = "_tabPage6";
            this._tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage6.Size = new System.Drawing.Size(439, 250);
            this._tabPage6.TabIndex = 5;
            this._tabPage6.Tag = "False";
            this._tabPage6.Text = "套裝電腦";
            this._tabPage6.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel6
            // 
            this._tableLayoutPanel6.ColumnCount = 3;
            this._tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel6.Name = "_tableLayoutPanel6";
            this._tableLayoutPanel6.RowCount = 2;
            this._tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel6.Size = new System.Drawing.Size(433, 244);
            this._tableLayoutPanel6.TabIndex = 0;
            // 
            // _orderForm
            // 
            this._orderForm.AllowUserToAddRows = false;
            this._orderForm.AllowUserToDeleteRows = false;
            this._orderForm.AllowUserToResizeColumns = false;
            this._orderForm.AllowUserToResizeRows = false;
            this._orderForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._orderForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._productName,
            this._productType,
            this._productPrice});
            this._orderForm.Location = new System.Drawing.Point(471, 61);
            this._orderForm.Name = "_orderForm";
            this._orderForm.RowHeadersVisible = false;
            this._orderForm.RowTemplate.Height = 24;
            this._orderForm.Size = new System.Drawing.Size(412, 380);
            this._orderForm.TabIndex = 1;
            this._orderForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteButtonClick);
            this._orderForm.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PaintGridCell);
            this._orderForm.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateTotalInOrder);
            // 
            // _deleteButton
            // 
            this._deleteButton.FillWeight = 30F;
            this._deleteButton.HeaderText = "刪除";
            this._deleteButton.MinimumWidth = 20;
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteButton.UseColumnTextForButtonValue = true;
            this._deleteButton.Width = 40;
            // 
            // _productName
            // 
            this._productName.HeaderText = "商品名稱";
            this._productName.Name = "_productName";
            this._productName.Width = 70;
            // 
            // _productType
            // 
            this._productType.HeaderText = "商品類別";
            this._productType.Name = "_productType";
            // 
            // _productPrice
            // 
            this._productPrice.HeaderText = "單價";
            this._productPrice.Name = "_productPrice";
            this._productPrice.Width = 85;
            // 
            // _orderLabel
            // 
            this._orderLabel.AutoSize = true;
            this._orderLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._orderLabel.Location = new System.Drawing.Point(569, 15);
            this._orderLabel.Name = "_orderLabel";
            this._orderLabel.Size = new System.Drawing.Size(145, 40);
            this._orderLabel.TabIndex = 2;
            this._orderLabel.Text = "我的訂單";
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._label2.Location = new System.Drawing.Point(480, 482);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(92, 31);
            this._label2.TabIndex = 3;
            this._label2.Text = "總金額:";
            // 
            // _total
            // 
            this._total.AutoSize = true;
            this._total.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._total.Location = new System.Drawing.Point(598, 482);
            this._total.Name = "_total";
            this._total.Size = new System.Drawing.Size(0, 31);
            this._total.TabIndex = 4;
            // 
            // _buyIt
            // 
            this._buyIt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._buyIt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buyIt.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._buyIt.Location = new System.Drawing.Point(691, 460);
            this._buyIt.Name = "_buyIt";
            this._buyIt.Size = new System.Drawing.Size(116, 71);
            this._buyIt.TabIndex = 5;
            this._buyIt.Text = "購買";
            this._buyIt.UseVisualStyleBackColor = true;
            this._buyIt.Click += new System.EventHandler(this.BuyIt);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 556);
            this.Controls.Add(this._buyIt);
            this.Controls.Add(this._total);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._orderLabel);
            this.Controls.Add(this._orderForm);
            this.Controls.Add(this._groupBox1);
            this.Name = "OrderForm";
            this.Text = "Form1";
            this._groupBox1.ResumeLayout(false);
            this._groupBox1.PerformLayout();
            this._groupBox2.ResumeLayout(false);
            this._groupBox2.PerformLayout();
            this._tableControl1.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            this._tabPage2.ResumeLayout(false);
            this._tabPage3.ResumeLayout(false);
            this._tabPage4.ResumeLayout(false);
            this._tabPage5.ResumeLayout(false);
            this._tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._orderForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.TabControl _tableControl1;
        private System.Windows.Forms.TabPage _tabPage1;
        private System.Windows.Forms.TabPage _tabPage3;
        private System.Windows.Forms.TabPage _tabPage4;
        private System.Windows.Forms.TabPage _tabPage5;
        private System.Windows.Forms.TabPage _tabPage6;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.TabPage _tabPage2;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.Button _addProduct;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.RichTextBox _introduction;
        private System.Windows.Forms.DataGridView _orderForm;
        private System.Windows.Forms.Label _orderLabel;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.Label _total;
        private System.Windows.Forms.Label _price;
        private System.Windows.Forms.Button _upPage;
        private System.Windows.Forms.Label _page;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _downPage;
        private System.Windows.Forms.Button _buyIt;
        private System.Windows.Forms.Label _inventoryLabel;
        private System.Windows.Forms.Label _inventory;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productPrice;
    }
}

