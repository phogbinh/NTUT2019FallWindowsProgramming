﻿namespace OrderAndStorageManagementSystem.Views
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
            this._productInfoGroupBox = new System.Windows.Forms.GroupBox();
            this._productInfoGroupBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productNameAndDescription = new System.Windows.Forms.RichTextBox();
            this._productPrice = new System.Windows.Forms.RichTextBox();
            this._productGroupBoxLastRowLayout = new System.Windows.Forms.TableLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._pageArrowsLayout = new System.Windows.Forms.TableLayoutPanel();
            this._leftArrowButton = new System.Windows.Forms.Button();
            this._rightArrowButton = new System.Windows.Forms.Button();
            this._pageLabel = new System.Windows.Forms.Label();
            this._orderFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this._cartSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this._cartDataGridView = new System.Windows.Forms.DataGridView();
            this._cartDeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._cartProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cartProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cartProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cartSectionTitle = new System.Windows.Forms.Label();
            this._cartSectionLastRowLayout = new System.Windows.Forms.TableLayoutPanel();
            this._cartTotalPrice = new System.Windows.Forms.Label();
            this._orderButton = new System.Windows.Forms.Button();
            this._productGroupBox.SuspendLayout();
            this._productGroupBoxLayout.SuspendLayout();
            this._productTabControl.SuspendLayout();
            this._productInfoGroupBox.SuspendLayout();
            this._productInfoGroupBoxLayout.SuspendLayout();
            this._productGroupBoxLastRowLayout.SuspendLayout();
            this._pageArrowsLayout.SuspendLayout();
            this._orderFormLayout.SuspendLayout();
            this._cartSectionLayout.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this._cartDataGridView ) ).BeginInit();
            this._cartSectionLastRowLayout.SuspendLayout();
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
            this._productGroupBoxLayout.Controls.Add(this._productInfoGroupBox, 0, 1);
            this._productGroupBoxLayout.Controls.Add(this._productGroupBoxLastRowLayout, 0, 2);
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
            // _productGroupBoxLastRowLayout
            // 
            this._productGroupBoxLastRowLayout.ColumnCount = 3;
            this._productGroupBoxLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._productGroupBoxLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._productGroupBoxLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._productGroupBoxLastRowLayout.Controls.Add(this._addButton, 2, 0);
            this._productGroupBoxLastRowLayout.Controls.Add(this._pageArrowsLayout, 1, 0);
            this._productGroupBoxLastRowLayout.Controls.Add(this._pageLabel, 0, 0);
            this._productGroupBoxLastRowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productGroupBoxLastRowLayout.Location = new System.Drawing.Point(3, 453);
            this._productGroupBoxLastRowLayout.Name = "_productGroupBoxLastRowLayout";
            this._productGroupBoxLastRowLayout.RowCount = 1;
            this._productGroupBoxLastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productGroupBoxLastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this._productGroupBoxLastRowLayout.Size = new System.Drawing.Size(435, 53);
            this._productGroupBoxLastRowLayout.TabIndex = 2;
            // 
            // _addButton
            // 
            this._addButton.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
            | System.Windows.Forms.AnchorStyles.Right ) ) );
            this._addButton.Image = global::OrderAndStorageManagementSystem.Properties.Resources.img_add;
            this._addButton.Location = new System.Drawing.Point(333, 3);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(99, 47);
            this._addButton.TabIndex = 3;
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // _pageArrowsLayout
            // 
            this._pageArrowsLayout.ColumnCount = 2;
            this._pageArrowsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._pageArrowsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._pageArrowsLayout.Controls.Add(this._leftArrowButton, 0, 0);
            this._pageArrowsLayout.Controls.Add(this._rightArrowButton, 1, 0);
            this._pageArrowsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pageArrowsLayout.Location = new System.Drawing.Point(147, 3);
            this._pageArrowsLayout.Name = "_pageArrowsLayout";
            this._pageArrowsLayout.RowCount = 1;
            this._pageArrowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._pageArrowsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this._pageArrowsLayout.Size = new System.Drawing.Size(139, 47);
            this._pageArrowsLayout.TabIndex = 4;
            // 
            // _leftArrowButton
            // 
            this._leftArrowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._leftArrowButton.Image = global::OrderAndStorageManagementSystem.Properties.Resources.img_left_arrow;
            this._leftArrowButton.Location = new System.Drawing.Point(3, 3);
            this._leftArrowButton.Name = "_leftArrowButton";
            this._leftArrowButton.Size = new System.Drawing.Size(63, 41);
            this._leftArrowButton.TabIndex = 0;
            this._leftArrowButton.UseVisualStyleBackColor = true;
            // 
            // _rightArrowButton
            // 
            this._rightArrowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rightArrowButton.Image = global::OrderAndStorageManagementSystem.Properties.Resources.img_right_arrow;
            this._rightArrowButton.Location = new System.Drawing.Point(72, 3);
            this._rightArrowButton.Name = "_rightArrowButton";
            this._rightArrowButton.Size = new System.Drawing.Size(64, 41);
            this._rightArrowButton.TabIndex = 1;
            this._rightArrowButton.UseVisualStyleBackColor = true;
            // 
            // _pageLabel
            // 
            this._pageLabel.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
            | System.Windows.Forms.AnchorStyles.Left ) ) );
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._pageLabel.Location = new System.Drawing.Point(3, 0);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(0, 53);
            this._pageLabel.TabIndex = 5;
            this._pageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this._cartSectionLayout.Controls.Add(this._cartSectionLastRowLayout, 0, 2);
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
            this._cartDeleteButton,
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
            // _cartDeleteButton
            // 
            this._cartDeleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._cartDeleteButton.FillWeight = 30F;
            this._cartDeleteButton.HeaderText = "刪除";
            this._cartDeleteButton.Name = "_cartDeleteButton";
            this._cartDeleteButton.ReadOnly = true;
            this._cartDeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._cartDeleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // _cartSectionLastRowLayout
            // 
            this._cartSectionLastRowLayout.ColumnCount = 2;
            this._cartSectionLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.35443F));
            this._cartSectionLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.64557F));
            this._cartSectionLastRowLayout.Controls.Add(this._cartTotalPrice, 0, 0);
            this._cartSectionLastRowLayout.Controls.Add(this._orderButton, 1, 0);
            this._cartSectionLastRowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cartSectionLastRowLayout.Location = new System.Drawing.Point(3, 463);
            this._cartSectionLastRowLayout.Name = "_cartSectionLastRowLayout";
            this._cartSectionLastRowLayout.RowCount = 1;
            this._cartSectionLastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._cartSectionLastRowLayout.Size = new System.Drawing.Size(442, 62);
            this._cartSectionLastRowLayout.TabIndex = 3;
            // 
            // _cartTotalPrice
            // 
            this._cartTotalPrice.AutoSize = true;
            this._cartTotalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cartTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._cartTotalPrice.Location = new System.Drawing.Point(3, 0);
            this._cartTotalPrice.Name = "_cartTotalPrice";
            this._cartTotalPrice.Size = new System.Drawing.Size(296, 62);
            this._cartTotalPrice.TabIndex = 4;
            this._cartTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _orderButton
            // 
            this._orderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._orderButton.Location = new System.Drawing.Point(305, 3);
            this._orderButton.Name = "_orderButton";
            this._orderButton.Size = new System.Drawing.Size(134, 56);
            this._orderButton.TabIndex = 5;
            this._orderButton.Text = "訂購";
            this._orderButton.UseVisualStyleBackColor = true;
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
            this._productGroupBoxLastRowLayout.ResumeLayout(false);
            this._productGroupBoxLastRowLayout.PerformLayout();
            this._pageArrowsLayout.ResumeLayout(false);
            this._orderFormLayout.ResumeLayout(false);
            this._orderFormLayout.PerformLayout();
            this._cartSectionLayout.ResumeLayout(false);
            this._cartSectionLayout.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this._cartDataGridView ) ).EndInit();
            this._cartSectionLastRowLayout.ResumeLayout(false);
            this._cartSectionLastRowLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _productGroupBox;
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
        private System.Windows.Forms.TableLayoutPanel _productGroupBoxLastRowLayout;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.TableLayoutPanel _pageArrowsLayout;
        private System.Windows.Forms.Button _leftArrowButton;
        private System.Windows.Forms.Button _rightArrowButton;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.DataGridViewButtonColumn _cartDeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cartProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cartProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cartProductPrice;
        private System.Windows.Forms.TableLayoutPanel _cartSectionLastRowLayout;
        private System.Windows.Forms.Label _cartTotalPrice;
        private System.Windows.Forms.Button _orderButton;
    }
}

