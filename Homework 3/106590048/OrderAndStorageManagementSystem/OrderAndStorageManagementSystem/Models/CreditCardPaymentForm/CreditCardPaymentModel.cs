﻿using System;
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

        // Protest on Dr.Smell
        private void InitializeControlWithInspectorsContainers()
        {
            _controlWithInspectorsContainers = new Dictionary<int, List<IInputInspector>>();
            for ( int i = 0; i < CONTROLS_COUNT; i++ )
            {
                _controlWithInspectorsContainers.Add(i, new List<IInputInspector>());
            }
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxIsNotEmptyInspectors()
        {
            for ( int i = LAST_NAME_FIELD_INDEX; i <= ADDRESS_FIELD_INDEX; i++ )
            {
                _controlWithInspectorsContainers[ i ].Add(new TextBoxIsNotEmptyInspector());
            }
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxIsOfFullLengthInspectors()
        {
            for ( int i = CARD_NUMBER_FIRST_FIELD_INDEX; i <= CARD_SECURITY_CODE_FIELD_INDEX; i++ )
            {
                _controlWithInspectorsContainers[ i ].Add(new TextBoxIsOfFullLengthInspector());
            }
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxIsMailInspector()
        {
            _controlWithInspectorsContainers[ MAIL_FIELD_INDEX ].Add(new TextBoxIsMailInspector());
        }

        // Protest on Dr.Smell
        private void InitializeDropDownListIsSelectedInspectors()
        {
            for ( int i = CARD_DATE_MONTH_FIELD_INDEX; i <= CARD_DATE_YEAR_FIELD_INDEX; i++ )
            {
                _controlWithInspectorsContainers[ i ].Add(new DropDownListIsSelectedInspector());
            }
        }

        // Protest on Dr.Smell
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            Action<IInputInspector> setTextBoxInspectorFunction = (inspector) => ( ( TextBoxInspector )inspector ).Set(text, maxTextLength);
            UpdateControlInspectors(textBoxIndex, setTextBoxInspectorFunction);
        }

        // Protest on Dr.Smell
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            Action<IInputInspector> setDropDownListIsSelectedInspectorFunction = (inspector) => ( ( DropDownListIsSelectedInspector )inspector ).Set(selectedIndex);
            UpdateControlInspectors(dropDownListIndex, setDropDownListIsSelectedInspectorFunction);
        }

        // Protest on Dr.Smell
        private void UpdateControlInspectors(int controlIndex, Action<IInputInspector> setInspectorFunction)
        {
            foreach ( IInputInspector inspector in _controlWithInspectorsContainers[ controlIndex ] )
            {
                setInspectorFunction(inspector);
            }
        }

        // Protest on Dr.Smell
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

        // Protest on Dr.Smell
        public string GetControlError(int controlIndex)
        {
            foreach ( IInputInspector inspector in _controlWithInspectorsContainers[ controlIndex ] )
            {
                if ( !inspector.IsValid() )
                {
                    return inspector.GetError();
                }
            }
            return ERROR_FREE;
        }
    }
}
