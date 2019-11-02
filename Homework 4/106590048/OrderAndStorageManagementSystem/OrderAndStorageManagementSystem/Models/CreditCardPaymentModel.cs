using OrderAndStorageManagementSystem.Models.Utilities.InputInspectorUtilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models
{
    public class CreditCardPaymentModel
    {
        public delegate void TextBoxInspectorChangedEventHandler(int textBoxIndex);
        private event TextBoxInspectorChangedEventHandler _textBoxInspectorChanged;
        public TextBoxInspectorChangedEventHandler TextBoxInspectorChanged
        {
            get
            {
                return _textBoxInspectorChanged;
            }
            set
            {
                _textBoxInspectorChanged = value;
            }
        }
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
        private List<int> _textBoxIsNotEmptyInspectorControlIndices;
        private List<int> _textBoxIsOfFullLengthInspectorControlIndices;
        private List<int> _textBoxIsMailInspectorControlIndices;
        private List<int> _dropDownListIsSelectedInspectorControlIndices;
        private InputInspectorManager _inputInspectorManager;

        public CreditCardPaymentModel()
        {
            InitializeTextBoxIsNotEmptyInspectorControlIndices();
            InitializeTextBoxIsOfFullLengthInspectorControlIndices();
            InitializeTextBoxIsMailInspectorControlIndices();
            InitializeDropDownListIsSelectedInspectorControlIndices();
            _inputInspectorManager = new InputInspectorManager(CONTROLS_COUNT, _textBoxIsNotEmptyInspectorControlIndices, _textBoxIsOfFullLengthInspectorControlIndices, _textBoxIsMailInspectorControlIndices, _dropDownListIsSelectedInspectorControlIndices);
        }

        /// <summary>
        /// Initialize _textBoxIsNotEmptyInspectorControlIndices.
        /// </summary>
        private void InitializeTextBoxIsNotEmptyInspectorControlIndices()
        {
            _textBoxIsNotEmptyInspectorControlIndices = new List<int>();
            for ( int i = LAST_NAME_FIELD_INDEX; i <= ADDRESS_FIELD_INDEX; i++ )
            {
                _textBoxIsNotEmptyInspectorControlIndices.Add(i);
            }
        }

        /// <summary>
        /// Initialize _textBoxIsOfFullLengthInspectorControlIndices.
        /// </summary>
        private void InitializeTextBoxIsOfFullLengthInspectorControlIndices()
        {
            _textBoxIsOfFullLengthInspectorControlIndices = new List<int>();
            for ( int i = CARD_NUMBER_FIRST_FIELD_INDEX; i <= CARD_SECURITY_CODE_FIELD_INDEX; i++ )
            {
                _textBoxIsOfFullLengthInspectorControlIndices.Add(i);
            }
        }

        /// <summary>
        /// Initialize _textBoxIsMailInspectorControlIndices.
        /// </summary>
        private void InitializeTextBoxIsMailInspectorControlIndices()
        {
            _textBoxIsMailInspectorControlIndices = new List<int>();
            _textBoxIsMailInspectorControlIndices.Add(MAIL_FIELD_INDEX);
        }

        /// <summary>
        /// Initialize _dropDownListIsSelectedInspectorControlIndices.
        /// </summary>
        private void InitializeDropDownListIsSelectedInspectorControlIndices()
        {
            _dropDownListIsSelectedInspectorControlIndices = new List<int>();
            _dropDownListIsSelectedInspectorControlIndices.Add(CARD_DATE_MONTH_FIELD_INDEX);
            _dropDownListIsSelectedInspectorControlIndices.Add(CARD_DATE_YEAR_FIELD_INDEX);
        }

        /// <summary>
        /// Update member variables of all TextBoxInspectors of the textbox at textBoxIndex.
        /// </summary>
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            _inputInspectorManager.UpdateTextBoxInspectors(textBoxIndex, text, maxTextLength);
            NotifyObserverChangeTextBoxInspector(textBoxIndex);
        }

        /// <summary>
        /// Notify observer change textbox inspector.
        /// </summary>
        private void NotifyObserverChangeTextBoxInspector(int textBoxIndex)
        {
            if ( TextBoxInspectorChanged != null )
            {
                TextBoxInspectorChanged(textBoxIndex);
            }
        }

        /// <summary>
        /// Update member variable of all DropDownListInspectors of the drop-down list at dropDownListIndex.
        /// </summary>
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            _inputInspectorManager.UpdateDropDownListInspectors(dropDownListIndex, selectedIndex);
        }

        /// <summary>
        /// Return true if all inspectors are valid.
        /// </summary>
        public bool AreAllValidInspectors()
        {
            return _inputInspectorManager.AreAllValidInspectors();
        }

        /// <summary>
        /// Get the first InputInspector error of the control at controlIndex.
        /// </summary>
        public string GetControlError(int controlIndex)
        {
            return _inputInspectorManager.GetControlError(controlIndex);
        }
    }
}
