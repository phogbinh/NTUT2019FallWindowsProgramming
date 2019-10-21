using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106590018_Homework
{
    public partial class CreditCardForm : Form
    {
        private CreditCardPayment _creditCardPayment;
        private CreditCardPresentationModel _creditCardPresentation;
        private Model _model;
        const string ERROR_MESSAGE = "請選擇到期的月份或年分";
        public CreditCardForm(Model model)
        {
            InitializeComponent();
            _model = model;
            _creditCardPresentation = new CreditCardPresentationModel(model);
            _creditCardPayment = _model.GetCreditCardPayment();
            if (_creditCardPayment != null)
                LoadForm();
        }

        //讀取CreditModel的資料
        private void LoadForm()
        {
            _firstName.Text = _creditCardPayment.FirstName;
            _lastName.Text = _creditCardPayment.SecondName;

            _cardNumber1.Text = _creditCardPayment.CardNumber[0].ToString();
            _cardNumber2.Text = _creditCardPayment.CardNumber[1].ToString();
            _cardNumber3.Text = _creditCardPayment.CardNumber[2].ToString();
            _cardNumber4.Text = _creditCardPayment.CardNumber[3].ToString();

            _deadLineMonth.SelectedIndex = _creditCardPayment.DeadLineMonthIndex;
            _deadLineYear.SelectedIndex = _creditCardPayment.DeadLineYearIndex;

            _mail.Text = _creditCardPayment.Mail;
            _address.Text = _creditCardPayment.Address;
        }

        //確認有無資料錯誤
        private void ClickElement(object sender, EventArgs e)
        {
            bool nameResult = IsAllNameOk();
            bool cardNumberResult = IsAllCardNumberOk();
            bool securityResult = IsSecurityNumberOk();
            bool mailResult = IsMailOk();
            bool addressResult = IsAddressOk();
            bool deadLineResult = IsDeadlineOk();

            if (nameResult && cardNumberResult && securityResult && mailResult && addressResult)
            {
                _okButton.Enabled = true;
                _okButton.BackColor = System.Drawing.Color.Red;
            }
        }

        //確認所有字的格字都資料正確
        private bool IsAllNameOk()
        {
            bool result = true;
            if (_creditCardPresentation.IsNameOk(_firstName.Text.ToString(), _lastName.Text.ToString()) == false)
            {
                _lastNameError.SetError(_lastName, "請輸入中文或英文");
                result = false;
            }
            else
            {
                _lastNameError.Clear();
            }
            return result;
        }

        //確認所有卡號的格式是否正確
        private bool IsAllCardNumberOk()
        {
            string[] cardNumberArray = new string[4] { _cardNumber1.Text, _cardNumber2.Text, _cardNumber3.Text, _cardNumber4.Text };
            if (_creditCardPresentation.IsCardNumberOk(cardNumberArray) == false)
            {
                _cardNumberError.SetError(_cardNumber4, "每隔請輸入4字的數字");
                return false;
            }
            else
            {
                _cardNumberError.Clear();
                return true;
            }
        }

        //確認安全碼是否正確
        private bool IsSecurityNumberOk()
        {
            const string ERROR_MESSAGE = "請輸3位的數字";
            if (_creditCardPresentation.IsSecurityNumberOk(_securityNumber.Text.ToString()) == false)
            {
                _deadLineError.SetError(_securityNumber, ERROR_MESSAGE);
                return false;
            }
            else
            {
                _deadLineError.Clear();
                return true;
            }
        }

        //到期日是否OK
        private bool IsDeadlineOk()
        {
            bool result = true;
            if (_creditCardPresentation.IsDeadlineOk(_deadLineMonth.Text.ToString(), _deadLineYear.SelectedIndex, _deadLineMonth.SelectedIndex) == false)
            {
                _deadLineMonthError.SetError(_deadLineMonth, ERROR_MESSAGE);
                result = false;
            }
            if (_creditCardPresentation.IsDeadlineOk(_deadLineYear.Text.ToString(), _deadLineYear.SelectedIndex, _deadLineMonth.SelectedIndex) == false)
            {
                _deadLineYearError.SetError(_deadLineYear, ERROR_MESSAGE);
                result = false;
            }
            if (result == true)
            {
                _deadLineYearError.Clear();
                _deadLineMonthError.Clear();
            }
            return result;
        }

        //確認Email格式正確
        private bool IsMailOk()
        {
            const string ERROR_MESSAGE = "請輸入正確的MAIL格式";
            if (_creditCardPresentation.IsMailOk(_mail.Text.ToString()) == false)
            {
                _mailError.SetError(_mail, ERROR_MESSAGE);
                return false;
            }
            else
            {
                _mailError.Clear();
                return true;
            }

        }

        //確認 Address 格式正確
        private bool IsAddressOk()
        {
            if (_creditCardPresentation.IsAddress(_address.Text.ToString()) == false)
            {
                _addressError.SetError(_address, "此為必填資料");
                return false;
            }
            else
            {
                _addressError.Clear();
                return true;
            }

        }

        //當確認鍵按下，設定DialogResult
        private void CheckButton(object sender, EventArgs e)
        {
            const string MESSAGE = ("訂購成功");
            this.Visible = false;
            DialogResult result = MessageBox.Show(MESSAGE);
            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                _creditCardPresentation.GiveModelCreditCardPayment();
                _model.ReduceInventoryWithOrder();
            }
        }

        //名字確認事件
        private void IsNameOk(object sender, EventArgs e)
        {
            IsAllNameOk();
        }

        //卡號ok事件
        private void IsAllCardNumberOk(object sender, EventArgs e)
        {
            IsAllCardNumberOk();
        }
        
        //安全碼事件
        private void IsSecurityNumberOk(object sender, EventArgs e)
        {
            IsSecurityNumberOk();
        }

        //mailOK事件
        private void IsMailOk(object sender, EventArgs e)
        {
            IsMailOk();
        }

        //Deadline OK
        private void IsDeadLineOk(object sender, EventArgs e)
        {
            IsDeadlineOk();
        }

        //address OK
        private void IsAddressOk(object sender, EventArgs e)
        {
            IsAddressOk();
        }
    }
}
