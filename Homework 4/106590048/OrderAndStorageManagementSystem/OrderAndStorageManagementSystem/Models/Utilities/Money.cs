using System.Linq;
using System.Text;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class Money
    {
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

        /// <summary>
        /// Get the currency format of the money.
        /// </summary>
        public string GetCurrencyFormat()
        {
            var reversedValueInCurrencyFormat = new StringBuilder();
            string valueString = GetString();
            int count = 0;
            for ( int i = valueString.Length - 1; i >= 0; i-- )
            {
                int index = ( valueString.Length - 1 ) - i;
                if ( index != 0 && index % THOUSANDS_COUNT == 0 )
                {
                    reversedValueInCurrencyFormat.Insert(count, AppDefinition.COMMA);
                    count++;
                }
                reversedValueInCurrencyFormat.Insert(count, valueString[ i ]);
                count++;
            }
            return new string(reversedValueInCurrencyFormat.ToString().Reverse().ToArray());
        }

        /// <summary>
        /// Add value to the money.
        /// </summary>
        public void Add(Money additionalValue)
        {
            _value = _value + additionalValue._value;
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
