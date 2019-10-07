using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace
{
    public class CreditCardPaymentModel
    {
        public const int LAST_NAME_FIELD_INDEX = 0;
        public const int FIRST_NAME_FIELD_INDEX = 1;
        public const int CARD_NUMBER_FIRST_FIELD_INDEX = 2;
        public const int CARD_NUMBER_SECOND_FIELD_INDEX = 3;
        public const int CARD_NUMBER_THIRD_FIELD_INDEX = 4;
        public const int CARD_NUMBER_FOURTH_FIELD_INDEX = 5;
        public const int CARD_SECURITY_CODE_FIELD_INDEX = 6;
        public const int EMAIL_FIELD_INDEX = 7;
        public const int ADDRESS_FIELD_INDEX = 8;
        public const int CARD_DATE_MONTH_FIELD_INDEX = 9;
        public const int CARD_DATE_YEAR_FIELD_INDEX = 10;
        private const int CONTROLS_COUNT = 11;
        private const string ERROR_FREE = "";
        private IDictionary<int, List<InputChecker>> _controlWithCheckersContainers;

        public CreditCardPaymentModel()
        {
            InitializeControlWithCheckersContainers();
            InitializeTextBoxIsNonEmptyCheckers();
            InitializeTextBoxIsOfFullLengthCheckers();
            InitializeTextBoxIsEmailChecker();
            InitializeDropDownListIsSelectedCheckers();
        }

        // Protest on Dr.Smell
        private void InitializeControlWithCheckersContainers()
        {
            _controlWithCheckersContainers = new Dictionary<int, List<InputChecker>>();
            for ( int i = 0; i < CONTROLS_COUNT; i++ )
            {
                _controlWithCheckersContainers.Add(i, new List<InputChecker>());
            }
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxIsNonEmptyCheckers()
        {
            for ( int i = LAST_NAME_FIELD_INDEX; i <= ADDRESS_FIELD_INDEX; i++ )
            {
                _controlWithCheckersContainers[ i ].Add(new TextBoxIsNonEmptyChecker());
            }
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxIsOfFullLengthCheckers()
        {
            for ( int i = CARD_NUMBER_FIRST_FIELD_INDEX; i <= CARD_SECURITY_CODE_FIELD_INDEX; i++ )
            {
                _controlWithCheckersContainers[ i ].Add(new TextBoxIsOfFullLengthChecker());
            }
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxIsEmailChecker()
        {
            _controlWithCheckersContainers[ EMAIL_FIELD_INDEX ].Add(new TextBoxIsEmailChecker());
        }

        // Protest on Dr.Smell
        private void InitializeDropDownListIsSelectedCheckers()
        {
            for ( int i = CARD_DATE_MONTH_FIELD_INDEX; i <= CARD_DATE_YEAR_FIELD_INDEX; i++ )
            {
                _controlWithCheckersContainers[ i ].Add(new DropDownListIsSelectedChecker());
            }
        }

        // Protest on Dr.Smell
        public void UpdateTextBoxCheckers(int textBoxIndex, string text, int maxTextLength)
        {
            foreach ( TextBoxChecker checker in _controlWithCheckersContainers[ textBoxIndex ] )
            {
                checker.Set(text, maxTextLength);
            }
        }

        // Protest on Dr.Smell
        public void UpdateDropDownListCheckers(int dropDownListIndex, int selectedIndex)
        {
            foreach ( DropDownListIsSelectedChecker checker in _controlWithCheckersContainers[ dropDownListIndex ] )
            {
                checker.Set(selectedIndex);
            }
        }

        // Protest on Dr.Smell
        public bool AllCheckersAreValid()
        {
            foreach ( KeyValuePair<int, List<InputChecker>> container in _controlWithCheckersContainers )
            {
                List<InputChecker> checkers = container.Value;
                foreach ( InputChecker checker in checkers )
                {
                    if ( !checker.IsValid() )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Protest on Dr.Smell
        public string GetControlError(int controlIndex)
        {
            foreach ( InputChecker checker in _controlWithCheckersContainers[ controlIndex ] )
            {
                if ( !checker.IsValid() )
                {
                    return checker.GetError();
                }
            }
            return ERROR_FREE;
        }
    }
}
