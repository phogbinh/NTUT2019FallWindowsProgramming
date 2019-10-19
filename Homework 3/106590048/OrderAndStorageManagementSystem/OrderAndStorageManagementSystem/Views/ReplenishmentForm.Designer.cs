namespace OrderAndStorageManagementSystem.Views
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
            this._supplyFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this._buttonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this._submitButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._windowTitle = new System.Windows.Forms.Label();
            this._productName = new System.Windows.Forms.Label();
            this._productType = new System.Windows.Forms.Label();
            this._productPrice = new System.Windows.Forms.Label();
            this._productStorageQuantity = new System.Windows.Forms.Label();
            this._productSupplyQuantityFieldLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productSupplyQuantityLabel = new System.Windows.Forms.Label();
            this._productSupplyQuantityField = new System.Windows.Forms.TextBox();
            this._supplyFormLayout.SuspendLayout();
            this._buttonsLayout.SuspendLayout();
            this._productSupplyQuantityFieldLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _supplyFormLayout
            // 
            this._supplyFormLayout.ColumnCount = 1;
            this._supplyFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._supplyFormLayout.Controls.Add(this._buttonsLayout, 0, 6);
            this._supplyFormLayout.Controls.Add(this._windowTitle, 0, 0);
            this._supplyFormLayout.Controls.Add(this._productName, 0, 1);
            this._supplyFormLayout.Controls.Add(this._productType, 0, 2);
            this._supplyFormLayout.Controls.Add(this._productPrice, 0, 3);
            this._supplyFormLayout.Controls.Add(this._productStorageQuantity, 0, 4);
            this._supplyFormLayout.Controls.Add(this._productSupplyQuantityFieldLayout, 0, 5);
            this._supplyFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._supplyFormLayout.Location = new System.Drawing.Point(0, 0);
            this._supplyFormLayout.Name = "_supplyFormLayout";
            this._supplyFormLayout.RowCount = 7;
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this._supplyFormLayout.Size = new System.Drawing.Size(490, 338);
            this._supplyFormLayout.TabIndex = 0;
            // 
            // _buttonsLayout
            // 
            this._buttonsLayout.ColumnCount = 2;
            this._buttonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonsLayout.Controls.Add(this._submitButton, 0, 0);
            this._buttonsLayout.Controls.Add(this._cancelButton, 1, 0);
            this._buttonsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsLayout.Location = new System.Drawing.Point(3, 291);
            this._buttonsLayout.Name = "_buttonsLayout";
            this._buttonsLayout.RowCount = 1;
            this._buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this._buttonsLayout.Size = new System.Drawing.Size(484, 44);
            this._buttonsLayout.TabIndex = 0;
            // 
            // _submitButton
            // 
            this._submitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._submitButton.Location = new System.Drawing.Point(3, 3);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(236, 38);
            this._submitButton.TabIndex = 0;
            this._submitButton.Text = "確認";
            this._submitButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelButton.Location = new System.Drawing.Point(245, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(236, 38);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "取消";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _windowTitle
            // 
            this._windowTitle.AutoSize = true;
            this._windowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._windowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._windowTitle.Location = new System.Drawing.Point(3, 0);
            this._windowTitle.Name = "_windowTitle";
            this._windowTitle.Size = new System.Drawing.Size(484, 48);
            this._windowTitle.TabIndex = 0;
            this._windowTitle.Text = "補貨單";
            this._windowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _productName
            // 
            this._productName.AutoSize = true;
            this._productName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productName.Location = new System.Drawing.Point(3, 48);
            this._productName.Name = "_productName";
            this._productName.Size = new System.Drawing.Size(484, 48);
            this._productName.TabIndex = 2;
            // 
            // _productType
            // 
            this._productType.AutoSize = true;
            this._productType.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productType.Location = new System.Drawing.Point(3, 96);
            this._productType.Name = "_productType";
            this._productType.Size = new System.Drawing.Size(484, 48);
            this._productType.TabIndex = 3;
            // 
            // _productPrice
            // 
            this._productPrice.AutoSize = true;
            this._productPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPrice.Location = new System.Drawing.Point(3, 144);
            this._productPrice.Name = "_productPrice";
            this._productPrice.Size = new System.Drawing.Size(484, 48);
            this._productPrice.TabIndex = 4;
            // 
            // _productStorageQuantity
            // 
            this._productStorageQuantity.AutoSize = true;
            this._productStorageQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productStorageQuantity.Location = new System.Drawing.Point(3, 192);
            this._productStorageQuantity.Name = "_productStorageQuantity";
            this._productStorageQuantity.Size = new System.Drawing.Size(484, 48);
            this._productStorageQuantity.TabIndex = 5;
            // 
            // _productSupplyQuantityFieldLayout
            // 
            this._productSupplyQuantityFieldLayout.ColumnCount = 2;
            this._productSupplyQuantityFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productSupplyQuantityFieldLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productSupplyQuantityFieldLayout.Controls.Add(this._productSupplyQuantityLabel, 0, 0);
            this._productSupplyQuantityFieldLayout.Controls.Add(this._productSupplyQuantityField, 1, 0);
            this._productSupplyQuantityFieldLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productSupplyQuantityFieldLayout.Location = new System.Drawing.Point(3, 243);
            this._productSupplyQuantityFieldLayout.Name = "_productSupplyQuantityFieldLayout";
            this._productSupplyQuantityFieldLayout.RowCount = 1;
            this._productSupplyQuantityFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productSupplyQuantityFieldLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this._productSupplyQuantityFieldLayout.Size = new System.Drawing.Size(484, 42);
            this._productSupplyQuantityFieldLayout.TabIndex = 6;
            // 
            // _productSupplyQuantityLabel
            // 
            this._productSupplyQuantityLabel.AutoSize = true;
            this._productSupplyQuantityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productSupplyQuantityLabel.Location = new System.Drawing.Point(3, 0);
            this._productSupplyQuantityLabel.Name = "_productSupplyQuantityLabel";
            this._productSupplyQuantityLabel.Size = new System.Drawing.Size(236, 42);
            this._productSupplyQuantityLabel.TabIndex = 0;
            // 
            // _productSupplyQuantityField
            // 
            this._productSupplyQuantityField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productSupplyQuantityField.Location = new System.Drawing.Point(245, 3);
            this._productSupplyQuantityField.Name = "_productSupplyQuantityField";
            this._productSupplyQuantityField.Size = new System.Drawing.Size(236, 20);
            this._productSupplyQuantityField.TabIndex = 1;
            // 
            // ReplenishmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 338);
            this.Controls.Add(this._supplyFormLayout);
            this.Name = "ReplenishmentForm";
            this.Text = "補貨單";
            this._supplyFormLayout.ResumeLayout(false);
            this._supplyFormLayout.PerformLayout();
            this._buttonsLayout.ResumeLayout(false);
            this._productSupplyQuantityFieldLayout.ResumeLayout(false);
            this._productSupplyQuantityFieldLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _supplyFormLayout;
        private System.Windows.Forms.TableLayoutPanel _buttonsLayout;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _windowTitle;
        private System.Windows.Forms.Label _productName;
        private System.Windows.Forms.Label _productType;
        private System.Windows.Forms.Label _productPrice;
        private System.Windows.Forms.Label _productStorageQuantity;
        private System.Windows.Forms.TableLayoutPanel _productSupplyQuantityFieldLayout;
        private System.Windows.Forms.Label _productSupplyQuantityLabel;
        private System.Windows.Forms.TextBox _productSupplyQuantityField;
    }
}