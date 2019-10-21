namespace _106590018_Homework
{
    partial class ReplenishmentForm
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
            if (disposing && (components != null))
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
            this._replenishmentLabel = new System.Windows.Forms.Label();
            this._replenishment = new System.Windows.Forms.TextBox();
            this._corrcectReplenishment = new System.Windows.Forms.Button();
            this._productNameLabel = new System.Windows.Forms.Label();
            this._productName = new System.Windows.Forms.Label();
            this._productTypeLabel = new System.Windows.Forms.Label();
            this._productType = new System.Windows.Forms.Label();
            this._productPriceLabel = new System.Windows.Forms.Label();
            this._inventoryLabel = new System.Windows.Forms.Label();
            this._productPrice = new System.Windows.Forms.Label();
            this._inventory = new System.Windows.Forms.Label();
            this._title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _replenishmentLabel
            // 
            this._replenishmentLabel.AutoSize = true;
            this._replenishmentLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._replenishmentLabel.Location = new System.Drawing.Point(12, 229);
            this._replenishmentLabel.Name = "_replenishmentLabel";
            this._replenishmentLabel.Size = new System.Drawing.Size(91, 24);
            this._replenishmentLabel.TabIndex = 6;
            this._replenishmentLabel.Text = "補貨數量:";
            // 
            // _replenishment
            // 
            this._replenishment.Location = new System.Drawing.Point(109, 229);
            this._replenishment.Name = "_replenishment";
            this._replenishment.Size = new System.Drawing.Size(82, 22);
            this._replenishment.TabIndex = 7;
            // 
            // _corrcectReplenishment
            // 
            this._corrcectReplenishment.Location = new System.Drawing.Point(73, 269);
            this._corrcectReplenishment.Name = "_corrcectReplenishment";
            this._corrcectReplenishment.Size = new System.Drawing.Size(75, 23);
            this._corrcectReplenishment.TabIndex = 8;
            this._corrcectReplenishment.Text = "確認";
            this._corrcectReplenishment.UseVisualStyleBackColor = true;
            this._corrcectReplenishment.Click += new System.EventHandler(this.CorrectTheReplenishment);
            // 
            // _productNameLabel
            // 
            this._productNameLabel.AutoSize = true;
            this._productNameLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productNameLabel.Location = new System.Drawing.Point(12, 83);
            this._productNameLabel.Name = "_productNameLabel";
            this._productNameLabel.Size = new System.Drawing.Size(91, 24);
            this._productNameLabel.TabIndex = 2;
            this._productNameLabel.Text = "商品名稱:";
            // 
            // _productName
            // 
            this._productName.AutoSize = true;
            this._productName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productName.Location = new System.Drawing.Point(117, 83);
            this._productName.Name = "_productName";
            this._productName.Size = new System.Drawing.Size(0, 24);
            this._productName.TabIndex = 9;
            // 
            // _productTypeLabel
            // 
            this._productTypeLabel.AutoSize = true;
            this._productTypeLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productTypeLabel.Location = new System.Drawing.Point(12, 123);
            this._productTypeLabel.Name = "_productTypeLabel";
            this._productTypeLabel.Size = new System.Drawing.Size(91, 24);
            this._productTypeLabel.TabIndex = 10;
            this._productTypeLabel.Text = "商品種類:";
            // 
            // _productType
            // 
            this._productType.AutoSize = true;
            this._productType.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productType.Location = new System.Drawing.Point(117, 123);
            this._productType.Name = "_productType";
            this._productType.Size = new System.Drawing.Size(0, 24);
            this._productType.TabIndex = 11;
            // 
            // _productPriceLabel
            // 
            this._productPriceLabel.AutoSize = true;
            this._productPriceLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productPriceLabel.Location = new System.Drawing.Point(12, 159);
            this._productPriceLabel.Name = "_productPriceLabel";
            this._productPriceLabel.Size = new System.Drawing.Size(91, 24);
            this._productPriceLabel.TabIndex = 12;
            this._productPriceLabel.Text = "商品單價:";
            // 
            // _inventoryLabel
            // 
            this._inventoryLabel.AutoSize = true;
            this._inventoryLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._inventoryLabel.Location = new System.Drawing.Point(12, 192);
            this._inventoryLabel.Name = "_inventoryLabel";
            this._inventoryLabel.Size = new System.Drawing.Size(91, 24);
            this._inventoryLabel.TabIndex = 13;
            this._inventoryLabel.Text = "庫存數量:";
            // 
            // _productPrice
            // 
            this._productPrice.AutoSize = true;
            this._productPrice.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productPrice.Location = new System.Drawing.Point(117, 159);
            this._productPrice.Name = "_productPrice";
            this._productPrice.Size = new System.Drawing.Size(0, 24);
            this._productPrice.TabIndex = 14;
            // 
            // _inventory
            // 
            this._inventory.AutoSize = true;
            this._inventory.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._inventory.Location = new System.Drawing.Point(117, 192);
            this._inventory.Name = "_inventory";
            this._inventory.Size = new System.Drawing.Size(0, 24);
            this._inventory.TabIndex = 15;
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._title.Location = new System.Drawing.Point(54, 20);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(125, 45);
            this._title.TabIndex = 16;
            this._title.Text = "補貨單";
            // 
            // ReplenishmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 304);
            this.Controls.Add(this._title);
            this.Controls.Add(this._inventory);
            this.Controls.Add(this._productPrice);
            this.Controls.Add(this._inventoryLabel);
            this.Controls.Add(this._productPriceLabel);
            this.Controls.Add(this._productType);
            this.Controls.Add(this._productTypeLabel);
            this.Controls.Add(this._productName);
            this.Controls.Add(this._corrcectReplenishment);
            this.Controls.Add(this._replenishment);
            this.Controls.Add(this._replenishmentLabel);
            this.Controls.Add(this._productNameLabel);
            this.Name = "ReplenishmentForm";
            this.Text = "ReplenishmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label _replenishmentLabel;
        private System.Windows.Forms.TextBox _replenishment;
        private System.Windows.Forms.Button _corrcectReplenishment;
        private System.Windows.Forms.Label _productNameLabel;
        private System.Windows.Forms.Label _productName;
        private System.Windows.Forms.Label _productTypeLabel;
        private System.Windows.Forms.Label _productType;
        private System.Windows.Forms.Label _productPriceLabel;
        private System.Windows.Forms.Label _inventoryLabel;
        private System.Windows.Forms.Label _productPrice;
        private System.Windows.Forms.Label _inventory;
        private System.Windows.Forms.Label _title;
    }
}