namespace OrderAndStorageManagementSystem.Views
{
    partial class InventoryForm
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
            this._inventoryFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this._windowTitle = new System.Windows.Forms.Label();
            this._underTitleSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productInfoLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productImageGroupBox = new System.Windows.Forms.GroupBox();
            this._productImage = new System.Windows.Forms.PictureBox();
            this._productInfoGroupBox = new System.Windows.Forms.GroupBox();
            this._productNameAndDescription = new System.Windows.Forms.RichTextBox();
            this._storageDataGridView = new System.Windows.Forms.DataGridView();
            this._storageProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._storageProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._storageProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._storageProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._storageSupplyButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._inventoryFormLayout.SuspendLayout();
            this._underTitleSectionLayout.SuspendLayout();
            this._productInfoLayout.SuspendLayout();
            this._productImageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._productImage)).BeginInit();
            this._productInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._storageDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _inventoryFormLayout
            // 
            this._inventoryFormLayout.ColumnCount = 1;
            this._inventoryFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._inventoryFormLayout.Controls.Add(this._windowTitle, 0, 0);
            this._inventoryFormLayout.Controls.Add(this._underTitleSectionLayout, 0, 1);
            this._inventoryFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inventoryFormLayout.Location = new System.Drawing.Point(0, 0);
            this._inventoryFormLayout.Name = "_inventoryFormLayout";
            this._inventoryFormLayout.RowCount = 2;
            this._inventoryFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2807F));
            this._inventoryFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.7193F));
            this._inventoryFormLayout.Size = new System.Drawing.Size(1031, 572);
            this._inventoryFormLayout.TabIndex = 0;
            // 
            // _windowTitle
            // 
            this._windowTitle.AutoSize = true;
            this._windowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._windowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._windowTitle.Location = new System.Drawing.Point(3, 0);
            this._windowTitle.Name = "_windowTitle";
            this._windowTitle.Size = new System.Drawing.Size(1025, 70);
            this._windowTitle.TabIndex = 0;
            this._windowTitle.Text = "庫存管理系統";
            this._windowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _underTitleSectionLayout
            // 
            this._underTitleSectionLayout.ColumnCount = 2;
            this._underTitleSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.70224F));
            this._underTitleSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.29776F));
            this._underTitleSectionLayout.Controls.Add(this._productInfoLayout, 1, 0);
            this._underTitleSectionLayout.Controls.Add(this._storageDataGridView, 0, 0);
            this._underTitleSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._underTitleSectionLayout.Location = new System.Drawing.Point(3, 73);
            this._underTitleSectionLayout.Name = "_underTitleSectionLayout";
            this._underTitleSectionLayout.RowCount = 1;
            this._underTitleSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._underTitleSectionLayout.Size = new System.Drawing.Size(1025, 496);
            this._underTitleSectionLayout.TabIndex = 1;
            // 
            // _productInfoLayout
            // 
            this._productInfoLayout.ColumnCount = 1;
            this._productInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._productInfoLayout.Controls.Add(this._productImageGroupBox, 0, 0);
            this._productInfoLayout.Controls.Add(this._productInfoGroupBox, 0, 1);
            this._productInfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoLayout.Location = new System.Drawing.Point(686, 3);
            this._productInfoLayout.Name = "_productInfoLayout";
            this._productInfoLayout.RowCount = 2;
            this._productInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productInfoLayout.Size = new System.Drawing.Size(336, 490);
            this._productInfoLayout.TabIndex = 1;
            // 
            // _productImageGroupBox
            // 
            this._productImageGroupBox.Controls.Add(this._productImage);
            this._productImageGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productImageGroupBox.Location = new System.Drawing.Point(3, 3);
            this._productImageGroupBox.Name = "_productImageGroupBox";
            this._productImageGroupBox.Size = new System.Drawing.Size(330, 239);
            this._productImageGroupBox.TabIndex = 0;
            this._productImageGroupBox.TabStop = false;
            this._productImageGroupBox.Text = "商品圖片";
            // 
            // _productImage
            // 
            this._productImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productImage.Location = new System.Drawing.Point(3, 16);
            this._productImage.Name = "_productImage";
            this._productImage.Size = new System.Drawing.Size(324, 220);
            this._productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._productImage.TabIndex = 0;
            this._productImage.TabStop = false;
            // 
            // _productInfoGroupBox
            // 
            this._productInfoGroupBox.Controls.Add(this._productNameAndDescription);
            this._productInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoGroupBox.Location = new System.Drawing.Point(3, 248);
            this._productInfoGroupBox.Name = "_productInfoGroupBox";
            this._productInfoGroupBox.Size = new System.Drawing.Size(330, 239);
            this._productInfoGroupBox.TabIndex = 1;
            this._productInfoGroupBox.TabStop = false;
            this._productInfoGroupBox.Text = "商品介紹";
            // 
            // _productNameAndDescription
            // 
            this._productNameAndDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productNameAndDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productNameAndDescription.Location = new System.Drawing.Point(3, 16);
            this._productNameAndDescription.Name = "_productNameAndDescription";
            this._productNameAndDescription.ReadOnly = true;
            this._productNameAndDescription.Size = new System.Drawing.Size(324, 220);
            this._productNameAndDescription.TabIndex = 0;
            this._productNameAndDescription.Text = "";
            // 
            // _storageDataGridView
            // 
            this._storageDataGridView.AllowUserToAddRows = false;
            this._storageDataGridView.AllowUserToDeleteRows = false;
            this._storageDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._storageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._storageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._storageProductName,
            this._storageProductType,
            this._storageProductPrice,
            this._storageProductQuantity,
            this._storageSupplyButton});
            this._storageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._storageDataGridView.Location = new System.Drawing.Point(3, 3);
            this._storageDataGridView.Name = "_storageDataGridView";
            this._storageDataGridView.ReadOnly = true;
            this._storageDataGridView.RowHeadersVisible = false;
            this._storageDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._storageDataGridView.Size = new System.Drawing.Size(677, 490);
            this._storageDataGridView.TabIndex = 2;
            // 
            // _storageProductName
            // 
            this._storageProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._storageProductName.HeaderText = "商品名稱";
            this._storageProductName.Name = "_storageProductName";
            this._storageProductName.ReadOnly = true;
            // 
            // _storageProductType
            // 
            this._storageProductType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._storageProductType.HeaderText = "商品類別";
            this._storageProductType.Name = "_storageProductType";
            this._storageProductType.ReadOnly = true;
            // 
            // _storageProductPrice
            // 
            this._storageProductPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._storageProductPrice.HeaderText = "單價";
            this._storageProductPrice.Name = "_storageProductPrice";
            this._storageProductPrice.ReadOnly = true;
            // 
            // _storageProductQuantity
            // 
            this._storageProductQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._storageProductQuantity.HeaderText = "數量";
            this._storageProductQuantity.Name = "_storageProductQuantity";
            this._storageProductQuantity.ReadOnly = true;
            // 
            // _storageSupplyButton
            // 
            this._storageSupplyButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._storageSupplyButton.HeaderText = "補貨";
            this._storageSupplyButton.Name = "_storageSupplyButton";
            this._storageSupplyButton.ReadOnly = true;
            this._storageSupplyButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._storageSupplyButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 572);
            this.Controls.Add(this._inventoryFormLayout);
            this.Name = "InventoryForm";
            this.Text = "庫存管理系統";
            this._inventoryFormLayout.ResumeLayout(false);
            this._inventoryFormLayout.PerformLayout();
            this._underTitleSectionLayout.ResumeLayout(false);
            this._productInfoLayout.ResumeLayout(false);
            this._productImageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._productImage)).EndInit();
            this._productInfoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._storageDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _inventoryFormLayout;
        private System.Windows.Forms.Label _windowTitle;
        private System.Windows.Forms.TableLayoutPanel _underTitleSectionLayout;
        private System.Windows.Forms.TableLayoutPanel _productInfoLayout;
        private System.Windows.Forms.GroupBox _productImageGroupBox;
        private System.Windows.Forms.GroupBox _productInfoGroupBox;
        private System.Windows.Forms.RichTextBox _productNameAndDescription;
        private System.Windows.Forms.DataGridView _storageDataGridView;
        private System.Windows.Forms.PictureBox _productImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _storageProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _storageProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _storageProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn _storageProductQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn _storageSupplyButton;
    }
}