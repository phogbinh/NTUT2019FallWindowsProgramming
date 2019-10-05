namespace OrderAndStorageManagementSystem.ViewNamespace
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._productGroupBox = new System.Windows.Forms.GroupBox();
            this._productGroupBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productTabControl = new System.Windows.Forms.TabControl();
            this._motherBoardTabPage = new System.Windows.Forms.TabPage();
            this._centralProcessingUnitTabPage = new System.Windows.Forms.TabPage();
            this._randomAccessMemoryTabPage = new System.Windows.Forms.TabPage();
            this._hardDiskTabPage = new System.Windows.Forms.TabPage();
            this._graphicsCardTabPage = new System.Windows.Forms.TabPage();
            this._computerSetTabPage = new System.Windows.Forms.TabPage();
            this._addButton = new System.Windows.Forms.Button();
            this._productInfoGroupBox = new System.Windows.Forms.GroupBox();
            this._productInfoGroupBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productNameAndDescription = new System.Windows.Forms.RichTextBox();
            this._productPrice = new System.Windows.Forms.RichTextBox();
            this._orderFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this._cartSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this._cartDataGridView = new System.Windows.Forms.DataGridView();
            this._cartSectionTitle = new System.Windows.Forms.Label();
            this._cartTotalPrice = new System.Windows.Forms.Label();
            this._cartProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cartProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cartProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productGroupBox.SuspendLayout();
            this._productGroupBoxLayout.SuspendLayout();
            this._productTabControl.SuspendLayout();
            this._productInfoGroupBox.SuspendLayout();
            this._productInfoGroupBoxLayout.SuspendLayout();
            this._orderFormLayout.SuspendLayout();
            this._cartSectionLayout.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this._cartDataGridView ) ).BeginInit();
            this.SuspendLayout();
            // 
            // _productGroupBox
            // 
            this._productGroupBox.AutoSize = true;
            this._productGroupBox.Controls.Add(this._productGroupBoxLayout);
            this._productGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productGroupBox.Location = new System.Drawing.Point(3, 3);
            this._productGroupBox.Name = "_productGroupBox";
            this._productGroupBox.Size = new System.Drawing.Size(447, 528);
            this._productGroupBox.TabIndex = 0;
            this._productGroupBox.TabStop = false;
            this._productGroupBox.Text = "商品";
            // 
            // _productGroupBoxLayout
            // 
            this._productGroupBoxLayout.ColumnCount = 1;
            this._productGroupBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productGroupBoxLayout.Controls.Add(this._productTabControl, 0, 0);
            this._productGroupBoxLayout.Controls.Add(this._addButton, 0, 2);
            this._productGroupBoxLayout.Controls.Add(this._productInfoGroupBox, 0, 1);
            this._productGroupBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productGroupBoxLayout.Location = new System.Drawing.Point(3, 16);
            this._productGroupBoxLayout.Name = "_productGroupBoxLayout";
            this._productGroupBoxLayout.RowCount = 3;
            this._productGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.64511F));
            this._productGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.95974F));
            this._productGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.39515F));
            this._productGroupBoxLayout.Size = new System.Drawing.Size(441, 509);
            this._productGroupBoxLayout.TabIndex = 3;
            // 
            // _productTabControl
            // 
            this._productTabControl.Controls.Add(this._motherBoardTabPage);
            this._productTabControl.Controls.Add(this._centralProcessingUnitTabPage);
            this._productTabControl.Controls.Add(this._randomAccessMemoryTabPage);
            this._productTabControl.Controls.Add(this._hardDiskTabPage);
            this._productTabControl.Controls.Add(this._graphicsCardTabPage);
            this._productTabControl.Controls.Add(this._computerSetTabPage);
            this._productTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productTabControl.Location = new System.Drawing.Point(3, 3);
            this._productTabControl.Name = "_productTabControl";
            this._productTabControl.SelectedIndex = 0;
            this._productTabControl.Size = new System.Drawing.Size(435, 251);
            this._productTabControl.TabIndex = 0;
            // 
            // _motherBoardTabPage
            // 
            this._motherBoardTabPage.Location = new System.Drawing.Point(4, 22);
            this._motherBoardTabPage.Name = "_motherBoardTabPage";
            this._motherBoardTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._motherBoardTabPage.Size = new System.Drawing.Size(427, 225);
            this._motherBoardTabPage.TabIndex = 0;
            this._motherBoardTabPage.Text = "主機板";
            this._motherBoardTabPage.UseVisualStyleBackColor = true;
            // 
            // _centralProcessingUnitTabPage
            // 
            this._centralProcessingUnitTabPage.Location = new System.Drawing.Point(4, 22);
            this._centralProcessingUnitTabPage.Name = "_centralProcessingUnitTabPage";
            this._centralProcessingUnitTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._centralProcessingUnitTabPage.Size = new System.Drawing.Size(427, 225);
            this._centralProcessingUnitTabPage.TabIndex = 1;
            this._centralProcessingUnitTabPage.Text = "CPU";
            this._centralProcessingUnitTabPage.UseVisualStyleBackColor = true;
            // 
            // _randomAccessMemoryTabPage
            // 
            this._randomAccessMemoryTabPage.Location = new System.Drawing.Point(4, 22);
            this._randomAccessMemoryTabPage.Name = "_randomAccessMemoryTabPage";
            this._randomAccessMemoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._randomAccessMemoryTabPage.Size = new System.Drawing.Size(427, 225);
            this._randomAccessMemoryTabPage.TabIndex = 2;
            this._randomAccessMemoryTabPage.Text = "記憶體";
            this._randomAccessMemoryTabPage.UseVisualStyleBackColor = true;
            // 
            // _hardDiskTabPage
            // 
            this._hardDiskTabPage.Location = new System.Drawing.Point(4, 22);
            this._hardDiskTabPage.Name = "_hardDiskTabPage";
            this._hardDiskTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._hardDiskTabPage.Size = new System.Drawing.Size(427, 225);
            this._hardDiskTabPage.TabIndex = 3;
            this._hardDiskTabPage.Text = "硬碟";
            this._hardDiskTabPage.UseVisualStyleBackColor = true;
            // 
            // _graphicsCardTabPage
            // 
            this._graphicsCardTabPage.Location = new System.Drawing.Point(4, 22);
            this._graphicsCardTabPage.Name = "_graphicsCardTabPage";
            this._graphicsCardTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._graphicsCardTabPage.Size = new System.Drawing.Size(427, 225);
            this._graphicsCardTabPage.TabIndex = 4;
            this._graphicsCardTabPage.Text = "顯示卡";
            this._graphicsCardTabPage.UseVisualStyleBackColor = true;
            // 
            // _computerSetTabPage
            // 
            this._computerSetTabPage.Location = new System.Drawing.Point(4, 22);
            this._computerSetTabPage.Name = "_computerSetTabPage";
            this._computerSetTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._computerSetTabPage.Size = new System.Drawing.Size(427, 225);
            this._computerSetTabPage.TabIndex = 5;
            this._computerSetTabPage.Text = "套裝電腦";
            this._computerSetTabPage.UseVisualStyleBackColor = true;
            // 
            // _addButton
            // 
            this._addButton.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this._addButton.Image = global::OrderAndStorageManagementSystem.Properties.Resources.img_add;
            this._addButton.Location = new System.Drawing.Point(339, 453);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(99, 44);
            this._addButton.TabIndex = 2;
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _productInfoGroupBox
            // 
            this._productInfoGroupBox.Controls.Add(this._productInfoGroupBoxLayout);
            this._productInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoGroupBox.Location = new System.Drawing.Point(3, 260);
            this._productInfoGroupBox.Name = "_productInfoGroupBox";
            this._productInfoGroupBox.Size = new System.Drawing.Size(435, 187);
            this._productInfoGroupBox.TabIndex = 1;
            this._productInfoGroupBox.TabStop = false;
            this._productInfoGroupBox.Text = "商品介紹";
            // 
            // _productInfoGroupBoxLayout
            // 
            this._productInfoGroupBoxLayout.ColumnCount = 2;
            this._productInfoGroupBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this._productInfoGroupBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this._productInfoGroupBoxLayout.Controls.Add(this._productNameAndDescription, 0, 0);
            this._productInfoGroupBoxLayout.Controls.Add(this._productPrice, 1, 0);
            this._productInfoGroupBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoGroupBoxLayout.Location = new System.Drawing.Point(3, 16);
            this._productInfoGroupBoxLayout.Name = "_productInfoGroupBoxLayout";
            this._productInfoGroupBoxLayout.RowCount = 1;
            this._productInfoGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productInfoGroupBoxLayout.Size = new System.Drawing.Size(429, 168);
            this._productInfoGroupBoxLayout.TabIndex = 2;
            // 
            // _productNameAndDescription
            // 
            this._productNameAndDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productNameAndDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._productNameAndDescription.Location = new System.Drawing.Point(3, 3);
            this._productNameAndDescription.Name = "_productNameAndDescription";
            this._productNameAndDescription.ReadOnly = true;
            this._productNameAndDescription.Size = new System.Drawing.Size(244, 162);
            this._productNameAndDescription.TabIndex = 0;
            this._productNameAndDescription.Text = "";
            // 
            // _productPrice
            // 
            this._productPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._productPrice.Location = new System.Drawing.Point(253, 3);
            this._productPrice.Name = "_productPrice";
            this._productPrice.ReadOnly = true;
            this._productPrice.Size = new System.Drawing.Size(173, 162);
            this._productPrice.TabIndex = 1;
            this._productPrice.Text = "";
            // 
            // _orderFormLayout
            // 
            this._orderFormLayout.ColumnCount = 2;
            this._orderFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._orderFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._orderFormLayout.Controls.Add(this._productGroupBox, 0, 0);
            this._orderFormLayout.Controls.Add(this._cartSectionLayout, 1, 0);
            this._orderFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderFormLayout.Location = new System.Drawing.Point(0, 0);
            this._orderFormLayout.Name = "_orderFormLayout";
            this._orderFormLayout.RowCount = 1;
            this._orderFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._orderFormLayout.Size = new System.Drawing.Size(907, 534);
            this._orderFormLayout.TabIndex = 1;
            // 
            // _cartSectionLayout
            // 
            this._cartSectionLayout.ColumnCount = 1;
            this._cartSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._cartSectionLayout.Controls.Add(this._cartDataGridView, 0, 1);
            this._cartSectionLayout.Controls.Add(this._cartSectionTitle, 0, 0);
            this._cartSectionLayout.Controls.Add(this._cartTotalPrice, 0, 2);
            this._cartSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cartSectionLayout.Location = new System.Drawing.Point(456, 3);
            this._cartSectionLayout.Name = "_cartSectionLayout";
            this._cartSectionLayout.RowCount = 3;
            this._cartSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.63345F));
            this._cartSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.73309F));
            this._cartSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.63345F));
            this._cartSectionLayout.Size = new System.Drawing.Size(448, 528);
            this._cartSectionLayout.TabIndex = 1;
            // 
            // _cartDataGridView
            // 
            this._cartDataGridView.AllowUserToAddRows = false;
            this._cartDataGridView.AllowUserToDeleteRows = false;
            this._cartDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._cartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._cartDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._cartProductName,
            this._cartProductType,
            this._cartProductPrice});
            this._cartDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cartDataGridView.Location = new System.Drawing.Point(3, 69);
            this._cartDataGridView.Name = "_cartDataGridView";
            this._cartDataGridView.ReadOnly = true;
            this._cartDataGridView.RowHeadersVisible = false;
            this._cartDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cartDataGridView.Size = new System.Drawing.Size(442, 388);
            this._cartDataGridView.TabIndex = 1;
            // 
            // _cartSectionTitle
            // 
            this._cartSectionTitle.AutoSize = true;
            this._cartSectionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cartSectionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._cartSectionTitle.Location = new System.Drawing.Point(3, 0);
            this._cartSectionTitle.Name = "_cartSectionTitle";
            this._cartSectionTitle.Size = new System.Drawing.Size(442, 66);
            this._cartSectionTitle.TabIndex = 2;
            this._cartSectionTitle.Text = "我的訂單";
            this._cartSectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _cartTotalPrice
            // 
            this._cartTotalPrice.AutoSize = true;
            this._cartTotalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cartTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._cartTotalPrice.Location = new System.Drawing.Point(3, 460);
            this._cartTotalPrice.Name = "_cartTotalPrice";
            this._cartTotalPrice.Size = new System.Drawing.Size(442, 68);
            this._cartTotalPrice.TabIndex = 3;
            this._cartTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _cartProductName
            // 
            this._cartProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._cartProductName.HeaderText = "商品名稱";
            this._cartProductName.Name = "_cartProductName";
            this._cartProductName.ReadOnly = true;
            // 
            // _cartProductType
            // 
            this._cartProductType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._cartProductType.HeaderText = "商品類別";
            this._cartProductType.Name = "_cartProductType";
            this._cartProductType.ReadOnly = true;
            // 
            // _cartProductPrice
            // 
            this._cartProductPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._cartProductPrice.HeaderText = "單價";
            this._cartProductPrice.Name = "_cartProductPrice";
            this._cartProductPrice.ReadOnly = true;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 534);
            this.Controls.Add(this._orderFormLayout);
            this.Name = "OrderForm";
            this.Text = "訂購";
            this._productGroupBox.ResumeLayout(false);
            this._productGroupBoxLayout.ResumeLayout(false);
            this._productTabControl.ResumeLayout(false);
            this._productInfoGroupBox.ResumeLayout(false);
            this._productInfoGroupBoxLayout.ResumeLayout(false);
            this._orderFormLayout.ResumeLayout(false);
            this._orderFormLayout.PerformLayout();
            this._cartSectionLayout.ResumeLayout(false);
            this._cartSectionLayout.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this._cartDataGridView ) ).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _productGroupBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.TableLayoutPanel _orderFormLayout;
        private System.Windows.Forms.TableLayoutPanel _productGroupBoxLayout;
        private System.Windows.Forms.TabControl _productTabControl;
        private System.Windows.Forms.TabPage _motherBoardTabPage;
        private System.Windows.Forms.TabPage _centralProcessingUnitTabPage;
        private System.Windows.Forms.TabPage _randomAccessMemoryTabPage;
        private System.Windows.Forms.TabPage _hardDiskTabPage;
        private System.Windows.Forms.TabPage _graphicsCardTabPage;
        private System.Windows.Forms.TabPage _computerSetTabPage;
        private System.Windows.Forms.GroupBox _productInfoGroupBox;
        private System.Windows.Forms.RichTextBox _productPrice;
        private System.Windows.Forms.RichTextBox _productNameAndDescription;
        private System.Windows.Forms.TableLayoutPanel _productInfoGroupBoxLayout;
        private System.Windows.Forms.DataGridView _cartDataGridView;
        private System.Windows.Forms.TableLayoutPanel _cartSectionLayout;
        private System.Windows.Forms.Label _cartSectionTitle;
        private System.Windows.Forms.Label _cartTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cartProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cartProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cartProductPrice;
    }
}

