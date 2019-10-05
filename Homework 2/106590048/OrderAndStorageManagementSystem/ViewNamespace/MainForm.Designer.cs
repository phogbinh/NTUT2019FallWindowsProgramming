namespace OrderAndStorageManagementSystem.ViewNamespace
{
    partial class MainForm
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
            this._mainFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this._orderSystemButton = new System.Windows.Forms.Button();
            this._inventorySystemButton = new System.Windows.Forms.Button();
            this._lastRowLayout = new System.Windows.Forms.TableLayoutPanel();
            this._exitButton = new System.Windows.Forms.Button();
            this._mainFormLayout.SuspendLayout();
            this._lastRowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainFormLayout
            // 
            this._mainFormLayout.ColumnCount = 1;
            this._mainFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainFormLayout.Controls.Add(this._orderSystemButton, 0, 0);
            this._mainFormLayout.Controls.Add(this._inventorySystemButton, 0, 1);
            this._mainFormLayout.Controls.Add(this._lastRowLayout, 0, 2);
            this._mainFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainFormLayout.Location = new System.Drawing.Point(0, 0);
            this._mainFormLayout.Name = "_mainFormLayout";
            this._mainFormLayout.RowCount = 3;
            this._mainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mainFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mainFormLayout.Size = new System.Drawing.Size(800, 450);
            this._mainFormLayout.TabIndex = 0;
            // 
            // _orderSystemButton
            // 
            this._orderSystemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._orderSystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._orderSystemButton.Location = new System.Drawing.Point(3, 3);
            this._orderSystemButton.Name = "_orderSystemButton";
            this._orderSystemButton.Size = new System.Drawing.Size(794, 143);
            this._orderSystemButton.TabIndex = 0;
            this._orderSystemButton.Text = "Order System";
            this._orderSystemButton.UseVisualStyleBackColor = true;
            // 
            // _inventorySystemButton
            // 
            this._inventorySystemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inventorySystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._inventorySystemButton.Location = new System.Drawing.Point(3, 152);
            this._inventorySystemButton.Name = "_inventorySystemButton";
            this._inventorySystemButton.Size = new System.Drawing.Size(794, 143);
            this._inventorySystemButton.TabIndex = 1;
            this._inventorySystemButton.Text = "Inventory System";
            this._inventorySystemButton.UseVisualStyleBackColor = true;
            // 
            // _lastRowLayout
            // 
            this._lastRowLayout.ColumnCount = 2;
            this._lastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._lastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._lastRowLayout.Controls.Add(this._exitButton, 1, 0);
            this._lastRowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lastRowLayout.Location = new System.Drawing.Point(3, 301);
            this._lastRowLayout.Name = "_lastRowLayout";
            this._lastRowLayout.RowCount = 1;
            this._lastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._lastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this._lastRowLayout.Size = new System.Drawing.Size(794, 146);
            this._lastRowLayout.TabIndex = 2;
            // 
            // _exitButton
            // 
            this._exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte )( 136 ) ));
            this._exitButton.Location = new System.Drawing.Point(400, 3);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(391, 140);
            this._exitButton.TabIndex = 0;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._mainFormLayout);
            this.Name = "MainForm";
            this.Text = "Menu";
            this._mainFormLayout.ResumeLayout(false);
            this._lastRowLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainFormLayout;
        private System.Windows.Forms.Button _orderSystemButton;
        private System.Windows.Forms.Button _inventorySystemButton;
        private System.Windows.Forms.TableLayoutPanel _lastRowLayout;
        private System.Windows.Forms.Button _exitButton;
    }
}