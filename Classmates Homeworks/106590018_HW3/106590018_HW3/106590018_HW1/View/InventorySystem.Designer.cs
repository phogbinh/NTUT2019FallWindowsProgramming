namespace _106590018_Homework
{
    partial class InventorySystem
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
            this._title = new System.Windows.Forms.Label();
            this._inventoryDataGridView = new System.Windows.Forms.DataGridView();
            this._imageLabel = new System.Windows.Forms.Label();
            this._introductionLabel = new System.Windows.Forms.Label();
            this._introduction = new System.Windows.Forms.RichTextBox();
            this._image = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._inventoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._title.Location = new System.Drawing.Point(299, 9);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(241, 40);
            this._title.TabIndex = 0;
            this._title.Text = "庫存管系裡系統";
            // 
            // _inventoryDataGridView
            // 
            this._inventoryDataGridView.AllowUserToAddRows = false;
            this._inventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._inventoryDataGridView.Location = new System.Drawing.Point(12, 52);
            this._inventoryDataGridView.Name = "_inventoryDataGridView";
            this._inventoryDataGridView.RowTemplate.Height = 24;
            this._inventoryDataGridView.Size = new System.Drawing.Size(528, 460);
            this._inventoryDataGridView.TabIndex = 1;
            this._inventoryDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowImageAndIntroduction);
            this._inventoryDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddInventory);
            this._inventoryDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PaintGridCell);
            // 
            // _imageLabel
            // 
            this._imageLabel.AutoSize = true;
            this._imageLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._imageLabel.Location = new System.Drawing.Point(557, 52);
            this._imageLabel.Name = "_imageLabel";
            this._imageLabel.Size = new System.Drawing.Size(74, 21);
            this._imageLabel.TabIndex = 2;
            this._imageLabel.Text = "商品圖片";
            // 
            // _introductionLabel
            // 
            this._introductionLabel.AutoSize = true;
            this._introductionLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._introductionLabel.Location = new System.Drawing.Point(555, 288);
            this._introductionLabel.Name = "_introductionLabel";
            this._introductionLabel.Size = new System.Drawing.Size(74, 21);
            this._introductionLabel.TabIndex = 3;
            this._introductionLabel.Text = "商品介紹";
            // 
            // _introduction
            // 
            this._introduction.BackColor = System.Drawing.SystemColors.ControlLight;
            this._introduction.Location = new System.Drawing.Point(561, 312);
            this._introduction.Name = "_introduction";
            this._introduction.Size = new System.Drawing.Size(213, 200);
            this._introduction.TabIndex = 4;
            this._introduction.Text = "";
            // 
            // _image
            // 
            this._image.Location = new System.Drawing.Point(559, 82);
            this._image.Name = "_image";
            this._image.Size = new System.Drawing.Size(215, 196);
            this._image.TabIndex = 5;
            // 
            // InventorySystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 546);
            this.Controls.Add(this._image);
            this.Controls.Add(this._introduction);
            this.Controls.Add(this._introductionLabel);
            this.Controls.Add(this._imageLabel);
            this.Controls.Add(this._inventoryDataGridView);
            this.Controls.Add(this._title);
            this.Name = "InventorySystem";
            this.Text = "InventorySystem";
            ((System.ComponentModel.ISupportInitialize)(this._inventoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.DataGridView _inventoryDataGridView;
        private System.Windows.Forms.Label _imageLabel;
        private System.Windows.Forms.Label _introductionLabel;
        private System.Windows.Forms.RichTextBox _introduction;
        private System.Windows.Forms.Label _image;
    }
}