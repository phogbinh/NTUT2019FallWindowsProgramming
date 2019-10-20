using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
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
        public const int MAIL_FIELD_INDEX = 7;
        public const int ADDRESS_FIELD_INDEX = 8;
        public const int CARD_DATE_MONTH_FIELD_INDEX = 9;
        public const int CARD_DATE_YEAR_FIELD_INDEX = 10;
        private const int CONTROLS_COUNT = 11;
        private const string ERROR_FREE = "";
        private IDictionary<int, List<IInputInspector>> _controlWithInspectorsContainers;

        public CreditCardPaymentModel()
        {
            InitializeControlWithInspectorsContainers();
            InitializeTextBoxIsNotEmptyInspectors();
            InitializeTextBoxIsOfFullLengthInspectors();
            InitializeTextBoxIsMailInspector();
            InitializeDropDownListIsSelectedInspectors();
        }

        /// <summary>
        /// Initialize _controlWithInspectorsContainers.
        /// </summary>
        private void InitializeControlWithInspectorsContainers()
        {
            _controlWithInspectorsContainers = new Dictionary<int, List<IInputInspector>>();
            for ( int i = 0; i < CONTROLS_COUNT; i++ )
            {
                _controlWithInspectorsContainers.Add(i, new List<IInputInspector>());
            }
        }

        /// <summary>
        /// Initialize TextBoxIsNotEmptyInspector for all textboxes.
        /// </summary>
        private void InitializeTextBoxIsNotEmptyInspectors()
        {
            for ( int i = LAST_NAME_FIELD_INDEX; i <= ADDRESS_FIELD_INDEX; i++ )
            {
                _controlWithInspectorsContainers[ i ].Add(new TextBoxIsNotEmptyInspector());
            }
        }

        /// <summary>
        /// Initialize TextBoxIsOfFullLengthInspector for card number and card security code textboxes.
        /// </summary>
        private void InitializeTextBoxIsOfFullLengthInspectors()
        {
            for ( int i = CARD_NUMBER_FIRST_FIELD_INDEX; i <= CARD_SECURITY_CODE_FIELD_INDEX; i++ )
            {
                _controlWithInspectorsContainers[ i ].Add(new TextBoxIsOfFullLengthInspector());
            }
        }

        /// <summary>
        /// Initialize TextBoxIsMailInspector for email textbox.
        /// </summary>
        private void InitializeTextBoxIsMailInspector()
        {
            _controlWithInspectorsContainers[ MAIL_FIELD_INDEX ].Add(new TextBoxIsMailInspector());
        }

        /// <summary>
        /// Initialize DropDownListIsSelectedInspector for all drop-down lists.
        /// </summary>
        private void InitializeDropDownListIsSelectedInspectors()
        {
            for ( int i = CARD_DATE_MONTH_FIELD_INDEX; i <= CARD_DATE_YEAR_FIELD_INDEX; i++ )
            {
                _controlWithInspectorsContainers[ i ].Add(new DropDownListIsSelectedInspector());
            }
        }

        /// <summary>
        /// Update member variables of all TextBoxInspectors of the textbox at textBoxIndex.
        /// </summary>
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            Action<IInputInspector> setTextBoxInspectorFunction = (inspector) => ( ( TextBoxInspector )inspector ).Set(text, maxTextLength);
            UpdateControlInspectors(textBoxIndex, setTextBoxInspectorFunction);
        }

        /// <summary>
        /// Update member variable of all DropDownListInspectors of the drop-down list at dropDownListIndex.
        /// </summary>
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            Action<IInputInspector> setDropDownListIsSelectedInspectorFunction = (inspector) => ( ( DropDownListIsSelectedInspector )inspector ).Set(selectedIndex);
            UpdateControlInspectors(dropDownListIndex, setDropDownListIsSelectedInspectorFunction);
        }

        /// <summary>
        /// Update member variable(s) of all InputInspectors of the control at controlIndex.
        /// </summary>
        private void UpdateControlInspectors(int controlIndex, Action<IInputInspector> setInspectorFunction)
        {
            foreach ( IInputInspector inspector in _controlWithInspectorsContainers[ controlIndex ] )
            {
                setInspectorFunction(inspector);
            }
        }

        /// <summary>
        /// Return true if all inspectors are valid.
        /// </summary>
        public bool AreAllValidInspectors()
        {
            foreach ( KeyValuePair<int, List<IInputInspector>> container in _controlWithInspectorsContainers )
            {
                List<IInputInspector> inspectors = container.Value;
                foreach ( IInputInspector inspector in inspectors )
                {
                    if ( !inspector.IsValid() )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get the first InputInspector error of the control at controlIndex.
        /// </summary>
        public string GetControlError(int controlIndex)
        {
            foreach ( IInputInspector inspector in _controlWithInspectorsContainers[ controlIndex ] )
            {
                if ( !inspector.IsValid() )
                {
                    return GetInspectorError(inspector);
                }
            }
            return ERROR_FREE;
        }

        /// <summary>
        /// Get the error of the inspector.
        /// </summary>
        private string GetInspectorError(IInputInspector inspector)
        {
            return inspector.GetError();
        }
    }
}
