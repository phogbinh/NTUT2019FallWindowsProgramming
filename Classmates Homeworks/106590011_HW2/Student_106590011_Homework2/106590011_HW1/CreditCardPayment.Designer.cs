namespace Shop_System
{
    partial class CreditCardPayment
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
            this.components = new System.ComponentModel.Container();
            this._label1 = new System.Windows.Forms.Label();
            this._nameLabel = new System.Windows.Forms.Label();
            this._dash1 = new System.Windows.Forms.Label();
            this._dash2 = new System.Windows.Forms.Label();
            this._dash3 = new System.Windows.Forms.Label();
            this._dash4 = new System.Windows.Forms.Label();
            this._creditLabel = new System.Windows.Forms.Label();
            this._slash1 = new System.Windows.Forms.Label();
            this._dateLabel = new System.Windows.Forms.Label();
            this._year = new System.Windows.Forms.ComboBox();
            this._password = new System.Windows.Forms.TextBox();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._mailLabel = new System.Windows.Forms.Label();
            this._addressLabel = new System.Windows.Forms.Label();
            this._submit = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._address = new System.Windows.Forms.TextBox();
            this._mail = new System.Windows.Forms.TextBox();
            this._month = new System.Windows.Forms.ComboBox();
            this._credit4 = new System.Windows.Forms.TextBox();
            this._credit3 = new System.Windows.Forms.TextBox();
            this._credit2 = new System.Windows.Forms.TextBox();
            this._credit1 = new System.Windows.Forms.TextBox();
            this._name2 = new System.Windows.Forms.TextBox();
            this._name1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._label1.Location = new System.Drawing.Point(128, 9);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(177, 40);
            this._label1.TabIndex = 0;
            this._label1.Text = "信用卡支付";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 80);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(71, 12);
            this._nameLabel.TabIndex = 1;
            this._nameLabel.Text = "持卡人姓名*";
            // 
            // _dash1
            // 
            this._dash1.AutoSize = true;
            this._dash1.Location = new System.Drawing.Point(205, 98);
            this._dash1.Name = "_dash1";
            this._dash1.Size = new System.Drawing.Size(9, 12);
            this._dash1.TabIndex = 4;
            this._dash1.Text = "-";
            // 
            // _dash2
            // 
            this._dash2.AutoSize = true;
            this._dash2.Location = new System.Drawing.Point(103, 144);
            this._dash2.Name = "_dash2";
            this._dash2.Size = new System.Drawing.Size(9, 12);
            this._dash2.TabIndex = 9;
            this._dash2.Text = "-";
            // 
            // _dash3
            // 
            this._dash3.AutoSize = true;
            this._dash3.Location = new System.Drawing.Point(204, 144);
            this._dash3.Name = "_dash3";
            this._dash3.Size = new System.Drawing.Size(9, 12);
            this._dash3.TabIndex = 10;
            this._dash3.Text = "-";
            // 
            // _dash4
            // 
            this._dash4.AutoSize = true;
            this._dash4.Location = new System.Drawing.Point(304, 144);
            this._dash4.Name = "_dash4";
            this._dash4.Size = new System.Drawing.Size(9, 12);
            this._dash4.TabIndex = 11;
            this._dash4.Text = "-";
            // 
            // _creditLabel
            // 
            this._creditLabel.AutoSize = true;
            this._creditLabel.Location = new System.Drawing.Point(12, 129);
            this._creditLabel.Name = "_creditLabel";
            this._creditLabel.Size = new System.Drawing.Size(71, 12);
            this._creditLabel.TabIndex = 12;
            this._creditLabel.Text = "信用卡卡號*";
            // 
            // _slash1
            // 
            this._slash1.AutoSize = true;
            this._slash1.Location = new System.Drawing.Point(205, 196);
            this._slash1.Name = "_slash1";
            this._slash1.Size = new System.Drawing.Size(8, 12);
            this._slash1.TabIndex = 16;
            this._slash1.Text = "/";
            // 
            // _dateLabel
            // 
            this._dateLabel.AutoSize = true;
            this._dateLabel.Location = new System.Drawing.Point(12, 177);
            this._dateLabel.Name = "_dateLabel";
            this._dateLabel.Size = new System.Drawing.Size(94, 12);
            this._dateLabel.TabIndex = 13;
            this._dateLabel.Text = "有效期限*(月/年)";
            // 
            // _year
            // 
            this._year.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_year", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._year.FormattingEnabled = true;
            this._year.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028"});
            this._year.Location = new System.Drawing.Point(219, 193);
            this._year.Name = "_year";
            this._year.Size = new System.Drawing.Size(185, 20);
            this._year.TabIndex = 18;
            this._year.Text = global::Order_System.Properties.Settings.Default._year;
            // 
            // _password
            // 
            this._password.Location = new System.Drawing.Point(14, 235);
            this._password.MaxLength = 3;
            this._password.Name = "_password";
            this._password.Size = new System.Drawing.Size(390, 22);
            this._password.TabIndex = 20;
            this._password.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _passwordLabel
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(12, 220);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(71, 12);
            this._passwordLabel.TabIndex = 19;
            this._passwordLabel.Text = "背面末三碼*";
            // 
            // _mailLabel
            // 
            this._mailLabel.AutoSize = true;
            this._mailLabel.Location = new System.Drawing.Point(12, 264);
            this._mailLabel.Name = "_mailLabel";
            this._mailLabel.Size = new System.Drawing.Size(38, 12);
            this._mailLabel.TabIndex = 21;
            this._mailLabel.Text = "Email*";
            // 
            // _addressLabel
            // 
            this._addressLabel.AutoSize = true;
            this._addressLabel.Location = new System.Drawing.Point(12, 308);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(59, 12);
            this._addressLabel.TabIndex = 23;
            this._addressLabel.Text = "帳單地址*";
            // 
            // _submit
            // 
            this._submit.BackColor = System.Drawing.Color.Red;
            this._submit.Enabled = false;
            this._submit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._submit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._submit.Location = new System.Drawing.Point(14, 386);
            this._submit.Name = "_submit";
            this._submit.Size = new System.Drawing.Size(390, 31);
            this._submit.TabIndex = 25;
            this._submit.Text = "確認";
            this._submit.UseVisualStyleBackColor = false;
            this._submit.Click += new System.EventHandler(this.ClickSubmit);
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _address
            // 
            this._address.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._address.Location = new System.Drawing.Point(14, 323);
            this._address.Name = "_address";
            this._address.Size = new System.Drawing.Size(390, 22);
            this._address.TabIndex = 24;
            this._address.Text = global::Order_System.Properties.Settings.Default._address;
            this._address.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _mail
            // 
            this._mail.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_mail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._mail.Location = new System.Drawing.Point(14, 279);
            this._mail.Name = "_mail";
            this._mail.Size = new System.Drawing.Size(390, 22);
            this._mail.TabIndex = 22;
            this._mail.Text = global::Order_System.Properties.Settings.Default._mail;
            this._mail.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _month
            // 
            this._month.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_month", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._month.FormattingEnabled = true;
            this._month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this._month.Location = new System.Drawing.Point(14, 193);
            this._month.Name = "_month";
            this._month.Size = new System.Drawing.Size(185, 20);
            this._month.TabIndex = 17;
            this._month.Tag = "";
            this._month.Text = global::Order_System.Properties.Settings.Default._month;
            // 
            // _credit4
            // 
            this._credit4.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_credit4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._credit4.Location = new System.Drawing.Point(319, 141);
            this._credit4.MaxLength = 4;
            this._credit4.Name = "_credit4";
            this._credit4.Size = new System.Drawing.Size(85, 22);
            this._credit4.TabIndex = 8;
            this._credit4.Text = global::Order_System.Properties.Settings.Default._credit4;
            this._credit4.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _credit3
            // 
            this._credit3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_credit3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._credit3.Location = new System.Drawing.Point(217, 141);
            this._credit3.MaxLength = 4;
            this._credit3.Name = "_credit3";
            this._credit3.Size = new System.Drawing.Size(85, 22);
            this._credit3.TabIndex = 7;
            this._credit3.Text = global::Order_System.Properties.Settings.Default._credit3;
            this._credit3.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _credit2
            // 
            this._credit2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_credit2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._credit2.Location = new System.Drawing.Point(116, 141);
            this._credit2.MaxLength = 4;
            this._credit2.Name = "_credit2";
            this._credit2.Size = new System.Drawing.Size(85, 22);
            this._credit2.TabIndex = 6;
            this._credit2.Text = global::Order_System.Properties.Settings.Default._credit2;
            this._credit2.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _credit1
            // 
            this._credit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_credit1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._credit1.Location = new System.Drawing.Point(14, 141);
            this._credit1.MaxLength = 4;
            this._credit1.Name = "_credit1";
            this._credit1.Size = new System.Drawing.Size(85, 22);
            this._credit1.TabIndex = 5;
            this._credit1.Text = global::Order_System.Properties.Settings.Default._credit1;
            this._credit1.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _name2
            // 
            this._name2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_name2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._name2.Location = new System.Drawing.Point(217, 95);
            this._name2.Name = "_name2";
            this._name2.Size = new System.Drawing.Size(187, 22);
            this._name2.TabIndex = 3;
            this._name2.Text = global::Order_System.Properties.Settings.Default._name2;
            this._name2.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // _name1
            // 
            this._name1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Order_System.Properties.Settings.Default, "_name1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._name1.Location = new System.Drawing.Point(14, 95);
            this._name1.Name = "_name1";
            this._name1.Size = new System.Drawing.Size(187, 22);
            this._name1.TabIndex = 2;
            this._name1.Text = global::Order_System.Properties.Settings.Default._name1;
            this._name1.LostFocus += new System.EventHandler(this.LoseFocus);
            // 
            // CreditCardPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 429);
            this.Controls.Add(this._submit);
            this.Controls.Add(this._address);
            this.Controls.Add(this._addressLabel);
            this.Controls.Add(this._mail);
            this.Controls.Add(this._mailLabel);
            this.Controls.Add(this._password);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._year);
            this.Controls.Add(this._month);
            this.Controls.Add(this._slash1);
            this.Controls.Add(this._dateLabel);
            this.Controls.Add(this._creditLabel);
            this.Controls.Add(this._dash4);
            this.Controls.Add(this._dash3);
            this.Controls.Add(this._dash2);
            this.Controls.Add(this._credit4);
            this.Controls.Add(this._credit3);
            this.Controls.Add(this._credit2);
            this.Controls.Add(this._credit1);
            this.Controls.Add(this._dash1);
            this.Controls.Add(this._name2);
            this.Controls.Add(this._name1);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._label1);
            this.Name = "CreditCardPayment";
            this.Text = "CreditCardPayment";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox _name1;
        private System.Windows.Forms.TextBox _name2;
        private System.Windows.Forms.Label _dash1;
        private System.Windows.Forms.TextBox _credit1;
        private System.Windows.Forms.TextBox _credit2;
        private System.Windows.Forms.TextBox _credit3;
        private System.Windows.Forms.TextBox _credit4;
        private System.Windows.Forms.Label _dash2;
        private System.Windows.Forms.Label _dash3;
        private System.Windows.Forms.Label _dash4;
        private System.Windows.Forms.Label _creditLabel;
        private System.Windows.Forms.Label _slash1;
        private System.Windows.Forms.Label _dateLabel;
        private System.Windows.Forms.ComboBox _year;
        private System.Windows.Forms.ComboBox _month;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.TextBox _mail;
        private System.Windows.Forms.Label _mailLabel;
        private System.Windows.Forms.TextBox _address;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Button _submit;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}