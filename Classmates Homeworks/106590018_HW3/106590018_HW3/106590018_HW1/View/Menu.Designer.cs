namespace _106590018_Homework
{
    partial class Menu
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
            this._orderSystemButton = new System.Windows.Forms.Button();
            this._inventoryButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _orderSystemButton
            // 
            this._orderSystemButton.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._orderSystemButton.Location = new System.Drawing.Point(77, 23);
            this._orderSystemButton.Name = "_orderSystemButton";
            this._orderSystemButton.Size = new System.Drawing.Size(636, 95);
            this._orderSystemButton.TabIndex = 0;
            this._orderSystemButton.Text = "OrderSystem";
            this._orderSystemButton.UseVisualStyleBackColor = true;
            this._orderSystemButton.Click += new System.EventHandler(this.CallOrderSystem);
            // 
            // _inventoryButton
            // 
            this._inventoryButton.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._inventoryButton.Location = new System.Drawing.Point(77, 142);
            this._inventoryButton.Name = "_inventoryButton";
            this._inventoryButton.Size = new System.Drawing.Size(636, 102);
            this._inventoryButton.TabIndex = 1;
            this._inventoryButton.Text = "InventorySystem";
            this._inventoryButton.UseVisualStyleBackColor = true;
            this._inventoryButton.Click += new System.EventHandler(this.CallInventorySystem);
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._exitButton.Location = new System.Drawing.Point(541, 250);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(172, 59);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ExitMenu);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 323);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._inventoryButton);
            this.Controls.Add(this._orderSystemButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _orderSystemButton;
        private System.Windows.Forms.Button _inventoryButton;
        private System.Windows.Forms.Button _exitButton;
    }
}