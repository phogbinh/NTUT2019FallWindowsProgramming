namespace Shop_System
{
    partial class FormMenu
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
            this._orderSystem = new System.Windows.Forms.Button();
            this._inventorySystem = new System.Windows.Forms.Button();
            this._exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _orderSystem
            // 
            this._orderSystem.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._orderSystem.Location = new System.Drawing.Point(12, 12);
            this._orderSystem.Name = "_orderSystem";
            this._orderSystem.Size = new System.Drawing.Size(701, 82);
            this._orderSystem.TabIndex = 0;
            this._orderSystem.Text = "Order System";
            this._orderSystem.UseVisualStyleBackColor = true;
            this._orderSystem.Click += new System.EventHandler(this.ClickOrderSystem);
            // 
            // _inventorySystem
            // 
            this._inventorySystem.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._inventorySystem.Location = new System.Drawing.Point(12, 100);
            this._inventorySystem.Name = "_inventorySystem";
            this._inventorySystem.Size = new System.Drawing.Size(701, 82);
            this._inventorySystem.TabIndex = 1;
            this._inventorySystem.Text = "Inventory System";
            this._inventorySystem.UseVisualStyleBackColor = true;
            this._inventorySystem.Click += new System.EventHandler(this.ClickInventorySystem);
            // 
            // _exit
            // 
            this._exit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._exit.Location = new System.Drawing.Point(498, 189);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(215, 44);
            this._exit.TabIndex = 2;
            this._exit.Text = "Exit";
            this._exit.UseVisualStyleBackColor = true;
            this._exit.Click += new System.EventHandler(this.ClickExit);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 245);
            this.Controls.Add(this._exit);
            this.Controls.Add(this._inventorySystem);
            this.Controls.Add(this._orderSystem);
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _orderSystem;
        private System.Windows.Forms.Button _inventorySystem;
        private System.Windows.Forms.Button _exit;
    }
}