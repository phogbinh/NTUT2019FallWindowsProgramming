using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _106590018_Homework
{
    class CreditCardPresentationModel
    {
        private const int CARD_NUMBER_AMOUNT = 4;
        private Model _model;
        private CreditCardPayment _creditCardPayment;

        public CreditCardPresentationModel(Model model)
        {
            _model = model;
            _creditCardPayment = new CreditCardPayment();
        }

        //名字是否OK
        public bool IsNameOk(string firstName, string secondName)
        {
            bool result = true;
            if (IsAnyNumberInString(firstName) == false)
                _creditCardPayment.FirstName = firstName;
            else
                result = false;
            if (IsAnyNumberInString(secondName) == false)
                _creditCardPayment.SecondName = secondName;
            else
                result = false;
            return result;
        }

        //確認CardNumber有無錯誤
        public bool IsCardNumberOk(string[] number)
        {
            const int LIMIT_LENGTH = 4;
            bool result = true;
            for (int index = 0; index < CARD_NUMBER_AMOUNT; index++)
            {
                if (int.TryParse(number[index], out int covert) && number[index].Length == LIMIT_LENGTH)
                {
                    _creditCardPayment.CardNumber[index] = covert;
                }
                else
                    result = false;
            }
            return result;
        }

        //檢查安全馬是否正確
        public bool IsSecurityNumberOk(string securityString)
        {
            const int LIMIT_LENGTH = 3;
            if (int.TryParse(securityString, out int securityNumber) && securityString.Length == LIMIT_LENGTH)
            {
                _creditCardPayment.SecurityNumber = securityNumber;
                return true;
            }
            return false;
        }

        //檢查address是否OK
        public bool IsAddress(string address)
        {
            if (address.Length != 0)
            {
                _creditCardPayment.Address = address;
                return true;
            }
            return false;
        }

        //Email是否OK
        public bool IsMailOk(string mail)
        {
            const string MOUSE = "@";
            const string TOKEN = ".com";
            if (mail.IndexOf(MOUSE) > 0 && mail.IndexOf(TOKEN) > 1)
            {
                _creditCardPayment.Mail = mail;
                return true;
            }
            return false;
        }

        //是否有數字在在串李
        private bool IsAnyNumberInString(string checkedString)
        {
            const int LIMIT = 10;
            if (checkedString == "")
                return true;
            for (int number = 0; number < LIMIT; number++)
            {
                if (checkedString.IndexOf(number.ToString()) >= 0)
                    return true;
            }
            return false;
        }

        //確認到期的日期
        public bool IsDeadlineOk(string monthOrYear, int yearIndex, int monthIndex)
        {
            const int SPLIT_AMOUNT = 2;
            if (monthOrYear.Length <= SPLIT_AMOUNT && monthOrYear != "")
            {
                _creditCardPayment.DeadLineMonthIndex = monthIndex;
                return true;
            }
            else if (monthOrYear.Length > SPLIT_AMOUNT && monthOrYear != "")
            {
                _creditCardPayment.DeadLineYearIndex = yearIndex;
                return true;
            }
            return false;
        }

        //給model 信用卡的資料
        public void GiveModelCreditCardPayment()
        {
            _model.SetOrderCreditCardPayment(_creditCardPayment);
        }
    }
}
