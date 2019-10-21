using Order_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_System
{
    public partial class CreditCardPayment : Form
    {
        private PresentationModelOfCreditCardSystem _presentationModel = new PresentationModelOfCreditCardSystem();
        public CreditCardPayment()
        {
            InitializeComponent();
            this._name1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyAlphabet);
            this._name2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyAlphabet);
            this._credit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyNumber);
            this._credit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyNumber);
            this._credit3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyNumber);
            this._credit4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyNumber);
            this._password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(_presentationModel.PressKeyTextBoxOnlyNumber);
        }

        // Click submit button
        private void ClickSubmit(object sender, EventArgs e)
        {
            const string MESSAGE = "訂購完成";
            MessageBox.Show(MESSAGE);
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        // Process when losing focus
        private void LoseFocus(Object sender, EventArgs e)
        {
            const int CREDIT_LENGTH = 4;
            const int PASSWORD_LENGTH = 3;
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _mail as Object, PresentationModelOfOrderSystem.CheckValidMail(_mail.Text));
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _name1 as Object, ((TextBox)sender).Text != "");
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _name2 as Object, ((TextBox)sender).Text != "");
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _address as Object, ((TextBox)sender).Text != "");
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _credit1 as Object, ((TextBox)sender).Text.Length.Equals(CREDIT_LENGTH));
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _credit2 as Object, ((TextBox)sender).Text.Length.Equals(CREDIT_LENGTH));
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _credit3 as Object, ((TextBox)sender).Text.Length.Equals(CREDIT_LENGTH));
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _credit4 as Object, ((TextBox)sender).Text.Length.Equals(CREDIT_LENGTH));
            _presentationModel.SetErrorToObject(ref _errorProvider, sender, _password as Object, ((TextBox)sender).Text.Length.Equals(PASSWORD_LENGTH));
            _submit.Enabled = _presentationModel.CheckErrorProvider(ref _errorProvider);
        }
    }
}
