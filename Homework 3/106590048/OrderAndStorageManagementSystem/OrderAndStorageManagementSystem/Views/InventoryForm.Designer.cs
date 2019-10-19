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
            this._temporaryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _temporaryLabel
            // 
            this._temporaryLabel.AutoSize = true;
            this._temporaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._temporaryLabel.Location = new System.Drawing.Point(159, 172);
            this._temporaryLabel.Name = "_temporaryLabel";
            this._temporaryLabel.Size = new System.Drawing.Size(492, 76);
            this._temporaryLabel.TabIndex = 0;
            this._temporaryLabel.Text = "Comming Soon";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._temporaryLabel);
            this.Name = "InventoryForm";
            this.Text = "Inventory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _temporaryLabel;
    }
}