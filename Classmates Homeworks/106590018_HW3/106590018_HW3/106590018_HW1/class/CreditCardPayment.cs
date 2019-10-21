using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106590018_Homework
{
    public class CreditCardPayment
    {
        public string FirstName
        {
            set
            {
                _firstName = value;
            }
            get
            {
                return _firstName;
            }
        }

        public string SecondName
        {
            set
            {
                _secondName = value;
            }
            get
            {
                return _secondName;
            }
        }

        public int[] CardNumber
        {
            get
            {
                return _cardNumber;
            }
        }

        public string Mail
        {
            set
            {
                _mail = value;
            }
            get
            {
                return _mail;
            }
        }

        public string Address
        {
            set
            {
                _address = value;
            }
            get
            {
                return _address;
            }
        }

        public int SecurityNumber
        {
            set
            {
                _securityNumber = value;
            }
            get
            {
                return _securityNumber;
            }
        }

        public int DeadLineMonthIndex
        {
            set
            {
                _deadlineMonthIndex = value;
            }
            get
            {
                return _deadlineMonthIndex;
            }
        }

        public int DeadLineYearIndex
        {
            set
            {
                _deadlineYearIndex = value;
            }
            get
            {
                return _deadlineYearIndex;
            }
        }

        private string _firstName;
        private string _secondName;
        private int[] _cardNumber = new int[CARD_NUMBER_AMOUNT];
        private string _mail;
        private string _address;
        private int _securityNumber;
        private int _deadlineMonthIndex;
        private int _deadlineYearIndex;
        private const int CARD_NUMBER_AMOUNT = 4;
    }

}
