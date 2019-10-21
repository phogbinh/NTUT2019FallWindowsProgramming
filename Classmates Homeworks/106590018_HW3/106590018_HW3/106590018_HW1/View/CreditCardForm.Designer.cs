namespace _106590018_Homework
{
    partial class CreditCardForm
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
            this._header = new System.Windows.Forms.Label();
            this._period1 = new System.Windows.Forms.Label();
            this._nameLabel = new System.Windows.Forms.Label();
            this._firstName = new System.Windows.Forms.TextBox();
            this._lastName = new System.Windows.Forms.TextBox();
            this._cardNumberLabel = new System.Windows.Forms.Label();
            this._cardNumber1 = new System.Windows.Forms.TextBox();
            this._cardNumber2 = new System.Windows.Forms.TextBox();
            this._cardNumber3 = new System.Windows.Forms.TextBox();
            this._cardNumber4 = new System.Windows.Forms.TextBox();
            this._period3 = new System.Windows.Forms.Label();
            this._period2 = new System.Windows.Forms.Label();
            this._period4 = new System.Windows.Forms.Label();
            this._period5 = new System.Windows.Forms.Label();
            this._deadLineMonth = new System.Windows.Forms.ComboBox();
            this._deadLineLabel = new System.Windows.Forms.Label();
            this._period6 = new System.Windows.Forms.Label();
            this._deadLineYear = new System.Windows.Forms.ComboBox();
            this._securityNumberLabel = new System.Windows.Forms.Label();
            this._securityNumber = new System.Windows.Forms.TextBox();
            this._mailLabel = new System.Windows.Forms.Label();
            this._mail = new System.Windows.Forms.TextBox();
            this._addressLabel = new System.Windows.Forms.Label();
            this._address = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._firstNameError = new System.Windows.Forms.ErrorProvider(this.components);
            this._cardNumberError = new System.Windows.Forms.ErrorProvider(this.components);
            this._deadLineError = new System.Windows.Forms.ErrorProvider(this.components);
            this._mailError = new System.Windows.Forms.ErrorProvider(this.components);
            this._addressError = new System.Windows.Forms.ErrorProvider(this.components);
            this._deadLineMonthError = new System.Windows.Forms.ErrorProvider(this.components);
            this._deadLineYearError = new System.Windows.Forms.ErrorProvider(this.components);
            this._lastNameError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._firstNameError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cardNumberError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deadLineError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mailError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._addressError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deadLineMonthError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deadLineYearError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._lastNameError)).BeginInit();
            this.SuspendLayout();
            // 
            // _header
            // 
            this._header.AutoSize = true;
            this._header.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._header.Location = new System.Drawing.Point(140, 9);
            this._header.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._header.Name = "_header";
            this._header.Size = new System.Drawing.Size(205, 47);
            this._header.TabIndex = 0;
            this._header.Text = "信用卡支付";
            // 
            // _period1
            // 
            this._period1.AutoSize = true;
            this._period1.Location = new System.Drawing.Point(2, 56);
            this._period1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._period1.Name = "_period1";
            this._period1.Size = new System.Drawing.Size(502, 21);
            this._period1.TabIndex = 1;
            this._period1.Text = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(26, 81);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(97, 21);
            this._nameLabel.TabIndex = 2;
            this._nameLabel.Text = "持卡人姓名*";
            // 
            // _firstName
            // 
            this._firstName.Location = new System.Drawing.Point(30, 106);
            this._firstName.Name = "_firstName";
            this._firstName.Size = new System.Drawing.Size(193, 29);
            this._firstName.TabIndex = 3;
            this._firstName.Leave += new System.EventHandler(this.IsNameOk);
            // 
            // _lastName
            // 
            this._lastName.Location = new System.Drawing.Point(256, 106);
            this._lastName.Name = "_lastName";
            this._lastName.Size = new System.Drawing.Size(193, 29);
            this._lastName.TabIndex = 5;
            this._lastName.Leave += new System.EventHandler(this.IsNameOk);
            // 
            // _cardNumberLabel
            // 
            this._cardNumberLabel.AutoSize = true;
            this._cardNumberLabel.Location = new System.Drawing.Point(26, 150);
            this._cardNumberLabel.Name = "_cardNumberLabel";
            this._cardNumberLabel.Size = new System.Drawing.Size(97, 21);
            this._cardNumberLabel.TabIndex = 6;
            this._cardNumberLabel.Text = "信用卡卡號*";
            // 
            // _cardNumber1
            // 
            this._cardNumber1.Location = new System.Drawing.Point(30, 171);
            this._cardNumber1.Name = "_cardNumber1";
            this._cardNumber1.Size = new System.Drawing.Size(77, 29);
            this._cardNumber1.TabIndex = 7;
            this._cardNumber1.Leave += new System.EventHandler(this.IsAllCardNumberOk);
            // 
            // _cardNumber2
            // 
            this._cardNumber2.Location = new System.Drawing.Point(140, 171);
            this._cardNumber2.Name = "_cardNumber2";
            this._cardNumber2.Size = new System.Drawing.Size(83, 29);
            this._cardNumber2.TabIndex = 8;
            this._cardNumber2.Leave += new System.EventHandler(this.IsAllCardNumberOk);
            // 
            // _cardNumber3
            // 
            this._cardNumber3.Location = new System.Drawing.Point(252, 171);
            this._cardNumber3.Name = "_cardNumber3";
            this._cardNumber3.Size = new System.Drawing.Size(77, 29);
            this._cardNumber3.TabIndex = 9;
            this._cardNumber3.Leave += new System.EventHandler(this.IsAllCardNumberOk);
            // 
            // _cardNumber4
            // 
            this._cardNumber4.Location = new System.Drawing.Point(362, 171);
            this._cardNumber4.Name = "_cardNumber4";
            this._cardNumber4.Size = new System.Drawing.Size(87, 29);
            this._cardNumber4.TabIndex = 10;
            this._cardNumber4.Leave += new System.EventHandler(this.IsAllCardNumberOk);
            // 
            // _period3
            // 
            this._period3.AutoSize = true;
            this._period3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._period3.Location = new System.Drawing.Point(113, 174);
            this._period3.Name = "_period3";
            this._period3.Size = new System.Drawing.Size(21, 26);
            this._period3.TabIndex = 11;
            this._period3.Text = "-";
            // 
            // _period2
            // 
            this._period2.AutoSize = true;
            this._period2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._period2.Location = new System.Drawing.Point(229, 106);
            this._period2.Name = "_period2";
            this._period2.Size = new System.Drawing.Size(21, 26);
            this._period2.TabIndex = 12;
            this._period2.Text = "-";
            // 
            // _period4
            // 
            this._period4.AutoSize = true;
            this._period4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._period4.Location = new System.Drawing.Point(229, 174);
            this._period4.Name = "_period4";
            this._period4.Size = new System.Drawing.Size(21, 26);
            this._period4.TabIndex = 13;
            this._period4.Text = "-";
            // 
            // _period5
            // 
            this._period5.AutoSize = true;
            this._period5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._period5.Location = new System.Drawing.Point(335, 171);
            this._period5.Name = "_period5";
            this._period5.Size = new System.Drawing.Size(21, 26);
            this._period5.TabIndex = 14;
            this._period5.Text = "-";
            // 
            // _deadLineMonth
            // 
            this._deadLineMonth.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._deadLineMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._deadLineMonth.FormattingEnabled = true;
            this._cardNumberError.SetIconAlignment(this._deadLineMonth, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this._deadLineMonth.Items.AddRange(new object[] {
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
            this._deadLineMonth.Location = new System.Drawing.Point(30, 251);
            this._deadLineMonth.Name = "_deadLineMonth";
            this._deadLineMonth.Size = new System.Drawing.Size(193, 29);
            this._deadLineMonth.TabIndex = 15;
            this._deadLineMonth.Leave += new System.EventHandler(this.IsDeadLineOk);
            // 
            // _deadLineLabel
            // 
            this._deadLineLabel.AutoSize = true;
            this._deadLineLabel.Location = new System.Drawing.Point(26, 219);
            this._deadLineLabel.Name = "_deadLineLabel";
            this._deadLineLabel.Size = new System.Drawing.Size(132, 21);
            this._deadLineLabel.TabIndex = 16;
            this._deadLineLabel.Text = "有效日期*(月/年)";
            // 
            // _period6
            // 
            this._period6.AutoSize = true;
            this._period6.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._period6.Location = new System.Drawing.Point(229, 254);
            this._period6.Name = "_period6";
            this._period6.Size = new System.Drawing.Size(21, 26);
            this._period6.TabIndex = 17;
            this._period6.Text = "/";
            // 
            // _deadLineYear
            // 
            this._deadLineYear.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._deadLineYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._deadLineYear.FormattingEnabled = true;
            this._deadLineYear.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028"});
            this._deadLineYear.Location = new System.Drawing.Point(256, 251);
            this._deadLineYear.Name = "_deadLineYear";
            this._deadLineYear.Size = new System.Drawing.Size(193, 29);
            this._deadLineYear.TabIndex = 18;
            this._deadLineYear.Leave += new System.EventHandler(this.IsDeadLineOk);
            // 
            // _securityNumberLabel
            // 
            this._securityNumberLabel.AutoSize = true;
            this._securityNumberLabel.Location = new System.Drawing.Point(26, 311);
            this._securityNumberLabel.Name = "_securityNumberLabel";
            this._securityNumberLabel.Size = new System.Drawing.Size(97, 21);
            this._securityNumberLabel.TabIndex = 19;
            this._securityNumberLabel.Text = "背面末三碼*";
            // 
            // _securityNumber
            // 
            this._securityNumber.Location = new System.Drawing.Point(30, 335);
            this._securityNumber.Name = "_securityNumber";
            this._securityNumber.Size = new System.Drawing.Size(419, 29);
            this._securityNumber.TabIndex = 20;
            this._securityNumber.Leave += new System.EventHandler(this.IsSecurityNumberOk);
            // 
            // _mailLabel
            // 
            this._mailLabel.AutoSize = true;
            this._mailLabel.Location = new System.Drawing.Point(26, 367);
            this._mailLabel.Name = "_mailLabel";
            this._mailLabel.Size = new System.Drawing.Size(58, 21);
            this._mailLabel.TabIndex = 21;
            this._mailLabel.Text = "Email*";
            // 
            // _mail
            // 
            this._mail.Location = new System.Drawing.Point(30, 391);
            this._mail.Name = "_mail";
            this._mail.Size = new System.Drawing.Size(419, 29);
            this._mail.TabIndex = 22;
            this._mail.Leave += new System.EventHandler(this.IsMailOk);
            // 
            // _addressLabel
            // 
            this._addressLabel.AutoSize = true;
            this._addressLabel.Location = new System.Drawing.Point(26, 423);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(81, 21);
            this._addressLabel.TabIndex = 23;
            this._addressLabel.Text = "帳單地址*";
            // 
            // _address
            // 
            this._address.Location = new System.Drawing.Point(30, 447);
            this._address.Name = "_address";
            this._address.Size = new System.Drawing.Size(419, 29);
            this._address.TabIndex = 24;
            // 
            // _okButton
            // 
            this._okButton.BackColor = System.Drawing.Color.Gray;
            this._okButton.Enabled = false;
            this._okButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._okButton.Location = new System.Drawing.Point(30, 521);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(419, 36);
            this._okButton.TabIndex = 25;
            this._okButton.Text = "確認";
            this._okButton.UseVisualStyleBackColor = false;
            this._okButton.Click += new System.EventHandler(this.CheckButton);
            // 
            // _firstNameError
            // 
            this._firstNameError.ContainerControl = this;
            // 
            // _cardNumberError
            // 
            this._cardNumberError.ContainerControl = this;
            // 
            // _deadLineError
            // 
            this._deadLineError.ContainerControl = this;
            // 
            // _mailError
            // 
            this._mailError.ContainerControl = this;
            // 
            // _addressError
            // 
            this._addressError.ContainerControl = this;
            // 
            // _deadLineMonthError
            // 
            this._deadLineMonthError.ContainerControl = this;
            // 
            // _deadLineYearError
            // 
            this._deadLineYearError.ContainerControl = this;
            // 
            // _lastNameError
            // 
            this._lastNameError.ContainerControl = this;
            // 
            // CreditCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 598);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._address);
            this.Controls.Add(this._addressLabel);
            this.Controls.Add(this._mail);
            this.Controls.Add(this._mailLabel);
            this.Controls.Add(this._securityNumber);
            this.Controls.Add(this._securityNumberLabel);
            this.Controls.Add(this._deadLineYear);
            this.Controls.Add(this._period6);
            this.Controls.Add(this._deadLineLabel);
            this.Controls.Add(this._deadLineMonth);
            this.Controls.Add(this._period5);
            this.Controls.Add(this._period4);
            this.Controls.Add(this._period2);
            this.Controls.Add(this._period3);
            this.Controls.Add(this._cardNumber4);
            this.Controls.Add(this._cardNumber3);
            this.Controls.Add(this._cardNumber2);
            this.Controls.Add(this._cardNumber1);
            this.Controls.Add(this._cardNumberLabel);
            this.Controls.Add(this._lastName);
            this.Controls.Add(this._firstName);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._period1);
            this.Controls.Add(this._header);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CreditCardForm";
            this.Text = "CreditCardPayment";
            this.Leave += new System.EventHandler(this.ClickElement);
            ((System.ComponentModel.ISupportInitialize)(this._firstNameError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cardNumberError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deadLineError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mailError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._addressError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deadLineMonthError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deadLineYearError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._lastNameError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _header;
        private System.Windows.Forms.Label _period1;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox _firstName;
        private System.Windows.Forms.TextBox _lastName;
        private System.Windows.Forms.Label _cardNumberLabel;
        private System.Windows.Forms.TextBox _cardNumber1;
        private System.Windows.Forms.TextBox _cardNumber2;
        private System.Windows.Forms.TextBox _cardNumber3;
        private System.Windows.Forms.TextBox _cardNumber4;
        private System.Windows.Forms.Label _period3;
        private System.Windows.Forms.Label _period2;
        private System.Windows.Forms.Label _period4;
        private System.Windows.Forms.Label _period5;
        private System.Windows.Forms.ComboBox _deadLineMonth;
        private System.Windows.Forms.Label _deadLineLabel;
        private System.Windows.Forms.Label _period6;
        private System.Windows.Forms.ComboBox _deadLineYear;
        private System.Windows.Forms.Label _securityNumberLabel;
        private System.Windows.Forms.TextBox _securityNumber;
        private System.Windows.Forms.Label _mailLabel;
        private System.Windows.Forms.TextBox _mail;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.TextBox _address;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.ErrorProvider _firstNameError;
        private System.Windows.Forms.ErrorProvider _cardNumberError;
        private System.Windows.Forms.ErrorProvider _deadLineError;
        private System.Windows.Forms.ErrorProvider _mailError;
        private System.Windows.Forms.ErrorProvider _addressError;
        private System.Windows.Forms.ErrorProvider _deadLineMonthError;
        private System.Windows.Forms.ErrorProvider _deadLineYearError;
        private System.Windows.Forms.ErrorProvider _lastNameError;
    }
}