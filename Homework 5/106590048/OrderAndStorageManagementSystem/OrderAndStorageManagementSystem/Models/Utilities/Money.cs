using System;
using System.Linq;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class Money
    {
        private const string NEGATIVE_SIGN = "-";
        private const string ERROR_NON_NEGATIVE_VALUE_IS_NEGATIVE = "The given non-negative value is negative";
        private const string ERROR_ADDITIONAL_MONEY_IS_NULL = "The given additional money is null.";
        private const int THOUSANDS_COUNT = 3;
        private int _value;

        public Money(int valueData)
        {
            _value = valueData;
        }

        /// <summary>
        /// Get the currency format of the money with currency unit.
        /// </summary>
        public string GetCurrencyFormatWithCurrencyUnit(string currencyUnit)
        {
            return GetCurrencyFormat() + AppDefinition.SPACE + currencyUnit;
        }

        /// <summary>Gets the currency format.</summary>
        public string GetCurrencyFormat()
        {
            return _value < 0 ? NEGATIVE_SIGN + GetNonNegativeCurrencyFormat(-_value) : GetNonNegativeCurrencyFormat(_value);
        }

        /// <summary>
        /// Get non-negative currency format.
        /// </summary>
        private string GetNonNegativeCurrencyFormat(int nonNegativeValue)
        {
            if ( nonNegativeValue < 0 )
            {
                throw new ArgumentException(ERROR_NON_NEGATIVE_VALUE_IS_NEGATIVE);
            }
            string valueInReversedOrder = new string (nonNegativeValue.ToString().Reverse().ToArray());
            string valueInCurrencyFormatInReversedOrder = "";
            for ( int index = 0; index < valueInReversedOrder.Length; index++ )
            {
                if ( index != 0 && index % THOUSANDS_COUNT == 0 )
                {
                    valueInCurrencyFormatInReversedOrder += AppDefinition.COMMA;
                }
                valueInCurrencyFormatInReversedOrder += valueInReversedOrder[ index ];
            }
            return new string (valueInCurrencyFormatInReversedOrder.Reverse().ToArray());
        }

        /// <summary>
        /// Add value to the money.
        /// </summary>
        public void Add(Money additionalMoney)
        {
            if ( additionalMoney == null )
            {
                throw new ArgumentNullException(ERROR_ADDITIONAL_MONEY_IS_NULL);
            }
            _value = _value + additionalMoney._value;
        }

        /// <summary>
        /// Return the money multiplication of the money with constant.
        /// </summary>
        public Money MultiplyConstant(int constant)
        {
            return new Money(_value * constant);
        }

        /// <summary>
        /// Get value string.
        /// </summary>
        public string GetString()
        {
            return _value.ToString();
        }
    }
}
