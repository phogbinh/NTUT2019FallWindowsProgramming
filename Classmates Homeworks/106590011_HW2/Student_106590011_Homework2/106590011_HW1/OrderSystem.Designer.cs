namespace Shop_System
{
    partial class OrderSystem
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
            this._productGroup = new System.Windows.Forms.GroupBox();
            this._pageLabel = new System.Windows.Forms.Label();
            this._downPage = new System.Windows.Forms.Button();
            this._upPage = new System.Windows.Forms.Button();
            this._addProduct = new System.Windows.Forms.Button();
            this._productInfoGroup = new System.Windows.Forms.GroupBox();
            this._productPrice = new System.Windows.Forms.Label();
            this._productInfo = new System.Windows.Forms.RichTextBox();
            this._products = new System.Windows.Forms.TabControl();
            this._shopList = new System.Windows.Forms.DataGridView();
            this._label1 = new System.Windows.Forms.Label();
            this._total = new System.Windows.Forms.Label();
            this._order = new System.Windows.Forms.Button();
            this._productGroup.SuspendLayout();
            this._productInfoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shopList)).BeginInit();
            this.SuspendLayout();
            // 
            // _productGroup
            // 
            this._productGroup.Controls.Add(this._pageLabel);
            this._productGroup.Controls.Add(this._downPage);
            this._productGroup.Controls.Add(this._upPage);
            this._productGroup.Controls.Add(this._addProduct);
            this._productGroup.Controls.Add(this._productInfoGroup);
            this._productGroup.Controls.Add(this._products);
            this._productGroup.Location = new System.Drawing.Point(12, 12);
            this._productGroup.Name = "_productGroup";
            this._productGroup.Size = new System.Drawing.Size(387, 518);
            this._productGroup.TabIndex = 2;
            this._productGroup.TabStop = false;
            this._productGroup.Text = "商品";
            // 
            // _pageLabel
            // 
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._pageLabel.Location = new System.Drawing.Point(10, 475);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(97, 27);
            this._pageLabel.TabIndex = 6;
            this._pageLabel.Text = "Page： /";
            // 
            // _downPage
            // 
            this._downPage.Enabled = false;
            this._downPage.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._downPage.Image = global::Order_System.Properties.Resources.forward;
            this._downPage.Location = new System.Drawing.Point(226, 468);
            this._downPage.Name = "_downPage";
            this._downPage.Size = new System.Drawing.Size(66, 41);
            this._downPage.TabIndex = 5;
            this._downPage.UseVisualStyleBackColor = true;
            this._downPage.Click += new System.EventHandler(this.ResetProductInfo);
            // 
            // _upPage
            // 
            this._upPage.Enabled = false;
            this._upPage.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._upPage.Image = global::Order_System.Properties.Resources.backward;
            this._upPage.Location = new System.Drawing.Point(144, 468);
            this._upPage.Name = "_upPage";
            this._upPage.Size = new System.Drawing.Size(66, 41);
            this._upPage.TabIndex = 4;
            this._upPage.UseVisualStyleBackColor = true;
            this._upPage.Click += new System.EventHandler(this.ResetProductInfo);
            // 
            // _addProduct
            // 
            this._addProduct.Enabled = false;
            this._addProduct.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addProduct.Image = global::Order_System.Properties.Resources.add;
            this._addProduct.Location = new System.Drawing.Point(307, 468);
            this._addProduct.Name = "_addProduct";
            this._addProduct.Size = new System.Drawing.Size(66, 41);
            this._addProduct.TabIndex = 3;
            this._addProduct.UseVisualStyleBackColor = true;
            this._addProduct.Click += new System.EventHandler(this.AddProductClick);
            // 
            // _productInfoGroup
            // 
            this._productInfoGroup.Controls.Add(this._productPrice);
            this._productInfoGroup.Controls.Add(this._productInfo);
            this._productInfoGroup.Location = new System.Drawing.Point(6, 314);
            this._productInfoGroup.Name = "_productInfoGroup";
            this._productInfoGroup.Size = new System.Drawing.Size(367, 148);
            this._productInfoGroup.TabIndex = 2;
            this._productInfoGroup.TabStop = false;
            this._productInfoGroup.Text = "商品介紹";
            // 
            // _productPrice
            // 
            this._productPrice.AutoSize = true;
            this._productPrice.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productPrice.Location = new System.Drawing.Point(260, 126);
            this._productPrice.Name = "_productPrice";
            this._productPrice.Size = new System.Drawing.Size(56, 16);
            this._productPrice.TabIndex = 2;
            this._productPrice.Text = "單價：";
            // 
            // _productInfo
            // 
            this._productInfo.BackColor = System.Drawing.SystemColors.Menu;
            this._productInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._productInfo.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productInfo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this._productInfo.Location = new System.Drawing.Point(6, 15);
            this._productInfo.Name = "_productInfo";
            this._productInfo.Size = new System.Drawing.Size(248, 127);
            this._productInfo.TabIndex = 1;
            this._productInfo.Text = "";
            // 
            // _products
            // 
            this._products.Location = new System.Drawing.Point(6, 21);
            this._products.Name = "_products";
            this._products.SelectedIndex = 0;
            this._products.Size = new System.Drawing.Size(375, 287);
            this._products.TabIndex = 0;
            this._products.SelectedIndexChanged += new System.EventHandler(this.ChangeProductsSelectedIndex);
            // 
            // _shopList
            // 
            this._shopList.AllowUserToAddRows = false;
            this._shopList.AllowUserToDeleteRows = false;
            this._shopList.AllowUserToResizeRows = false;
            this._shopList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._shopList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shopList.Location = new System.Drawing.Point(405, 45);
            this._shopList.Name = "_shopList";
            this._shopList.ReadOnly = true;
            this._shopList.RowHeadersVisible = false;
            this._shopList.RowTemplate.Height = 24;
            this._shopList.Size = new System.Drawing.Size(383, 429);
            this._shopList.TabIndex = 3;
            this._shopList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickCellContentShopList);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._label1.Location = new System.Drawing.Point(556, 12);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(98, 21);
            this._label1.TabIndex = 4;
            this._label1.Text = "我的訂單";
            // 
            // _total
            // 
            this._total.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._total.Location = new System.Drawing.Point(475, 491);
            this._total.Name = "_total";
            this._total.Size = new System.Drawing.Size(212, 24);
            this._total.TabIndex = 5;
            this._total.Text = "總金額：";
            this._total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _order
            // 
            this._order.Enabled = false;
            this._order.Location = new System.Drawing.Point(693, 487);
            this._order.Name = "_order";
            this._order.Size = new System.Drawing.Size(95, 34);
            this._order.TabIndex = 6;
            this._order.Text = "訂購";
            this._order.UseVisualStyleBackColor = true;
            this._order.Click += new System.EventHandler(this.ClickOrder);
            // 
            // OrderSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this._order);
            this.Controls.Add(this._total);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._shopList);
            this.Controls.Add(this._productGroup);
            this.Name = "OrderSystem";
            this.Text = "訂購";
            this._productGroup.ResumeLayout(false);
            this._productGroup.PerformLayout();
            this._productInfoGroup.ResumeLayout(false);
            this._productInfoGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shopList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _productGroup;
        private System.Windows.Forms.GroupBox _productInfoGroup;
        private System.Windows.Forms.Label _productPrice;
        private System.Windows.Forms.RichTextBox _productInfo;
        private System.Windows.Forms.TabControl _products;
        private System.Windows.Forms.Button _addProduct;
        private System.Windows.Forms.DataGridView _shopList;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label _total;
        private System.Windows.Forms.Button _order;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _downPage;
        private System.Windows.Forms.Button _upPage;
    }
}

