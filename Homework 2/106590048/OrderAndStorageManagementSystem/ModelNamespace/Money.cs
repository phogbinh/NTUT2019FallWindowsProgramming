using System.Linq;
using System.Text;

namespace OrderAndStorageManagementSystem.ModelNamespace
{
    public class Money
    {
        private const int THOUSANDS_COUNT = 3;
        private int _value;

        public Money(int valueData)
        {
            _value = valueData;
        }

        // Protest on Dr.Smell
        public string GetStringWithCurrencyUnit(string currencyUnit)
        {
            return GetCurrencyFormat() + " " + currencyUnit;
        }

        // Protest on Dr.Smell
        public string GetCurrencyFormat()
        {
            var reversedValueInCurrencyFormat = new StringBuilder();
            string valueString = _value.ToString();
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

        // Protest on Dr.Smell
        public void Add(Money additionalValue)
        {
            _value = _value + additionalValue._value;
        }

        // Protest on Dr.Smell
        public void Substract(Money substractedValue)
        {
            _value = _value - substractedValue._value;
        }
    }
}
