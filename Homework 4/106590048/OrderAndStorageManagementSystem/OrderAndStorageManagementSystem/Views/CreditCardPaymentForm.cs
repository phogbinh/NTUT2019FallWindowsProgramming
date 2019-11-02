using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class CreditCardPaymentForm : Form
    {
        private const string ORDER_COMPLETE_TITLE = "訂購狀態";
        private const string ORDER_COMPLETE_MESSAGE = "訂購完成";
        private CreditCardPaymentModel _creditCardPaymentModel;
        private Model _model;
        private IDictionary<TextBox, int> _textBoxWithTextBoxModelIndexContainers;
        private IDictionary<ComboBox, int> _dropDownListWithDropDownListModelIndexContainers;

        public CreditCardPaymentForm(CreditCardPaymentModel creditCardPaymentModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentModel = creditCardPaymentModelData;
            _model = modelData;
            // Observers
            _creditCardPaymentModel.TextBoxInspectorChanged += (textBoxIndex) => UpdateErrorProviderAndSubmitButtonOnControlInspectorChanged(textBoxIndex, GetTextBox);
            _creditCardPaymentModel.DropDownListInspectorChanged += (dropDownListIndex) => UpdateErrorProviderAndSubmitButtonOnControlInspectorChanged(dropDownListIndex, GetDropDownList);
            // UI
            this.FormClosed += (sender, eventArguments) => _cardSecurityCodeField.Text = AppDefinition.EMPTY_STRING;
            _submitButton.Click += ClickSubmitButton;
            InitializeInputLimits();
            InitializeTextBoxWithTextBoxModelIndexContainers();
            InitializeDropDownListWithDropDownListModelIndexContainers();
            InitializeControlInspectors();
            // Initial UI States
            UpdateInitialValuesForInspectors();
        }

        /// <summary>
        /// Update error provider and submit button on control inspector changed.
        /// </summary>
        private void UpdateErrorProviderAndSubmitButtonOnControlInspectorChanged(int controlIndex, Func<int, Control> getControlFunction)
        {
            _errorProvider.SetError(getControlFunction(controlIndex), _creditCardPaymentModel.GetControlError(controlIndex));
            _submitButton.Enabled = _creditCardPaymentModel.AreAllValidInspectors();
        }

        /// <summary>
        /// Get textbox by textbox model index.
        /// </summary>
        private TextBox GetTextBox(int textBoxModelIndex)
        {
            foreach ( KeyValuePair<TextBox, int> container in _textBoxWithTextBoxModelIndexContainers )
            {
                if ( container.Value == textBoxModelIndex )
                {
                    return container.Key;
                }
            }
            throw new ArgumentException(AppDefinition.ERROR_TEXT_BOX_MODEL_INDEX_OUT_OF_RANGE);
        }

        /// <summary>
        /// Get ComboBox by drop-down list model index.
        /// </summary>
        private ComboBox GetDropDownList(int dropDownListModelIndex)
        {
            foreach ( KeyValuePair<ComboBox, int> container in _dropDownListWithDropDownListModelIndexContainers )
            {
                if ( container.Value == dropDownListModelIndex )
                {
                    return container.Key;
                }
            }
            throw new ArgumentException(AppDefinition.ERROR_DROP_DOWN_LIST_MODEL_INDEX_OUT_OF_RANGE);
        }

        /// <summary>
        /// Click submit button.
        /// </summary>
        private void ClickSubmitButton(object sender, EventArgs eventArguments)
        {
            if ( MessageBox.Show(this, ORDER_COMPLETE_MESSAGE, ORDER_COMPLETE_TITLE) == DialogResult.OK )
            {
                _model.SubmitOrder();
                this.Close();
            }
        }

        /// <summary>
        /// Initialize input limits.
        /// </summary>
        private void InitializeInputLimits()
        {
            _lastNameField.KeyPress += InputHelper.InputLettersOrWhiteSpaceOrBackSpace;
            _firstNameField.KeyPress += InputHelper.InputLettersOrWhiteSpaceOrBackSpace;
            _cardNumberFirstField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardNumberSecondField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardNumberThirdField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardNumberFourthField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardSecurityCodeField.KeyPress += InputHelper.InputNumbersOrBackSpace;
        }

        /// <summary>
        /// Initialize _textBoxWithTextBoxModelIndexContainers.
        /// </summary>
        private void InitializeTextBoxWithTextBoxModelIndexContainers()
        {
            _textBoxWithTextBoxModelIndexContainers = new Dictionary<TextBox, int>();
            _textBoxWithTextBoxModelIndexContainers.Add(_lastNameField, CreditCardPaymentModel.LAST_NAME_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_firstNameField, CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_cardNumberFirstField, CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_cardNumberSecondField, CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_cardNumberThirdField, CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_cardNumberFourthField, CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_cardSecurityCodeField, CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_mailField, CreditCardPaymentModel.MAIL_FIELD_INDEX);
            _textBoxWithTextBoxModelIndexContainers.Add(_addressField, CreditCardPaymentModel.ADDRESS_FIELD_INDEX);
        }

        /// <summary>
        /// Initialize _dropDownListWithDropDownListModelIndexContainers.
        /// </summary>
        private void InitializeDropDownListWithDropDownListModelIndexContainers()
        {
            _dropDownListWithDropDownListModelIndexContainers = new Dictionary<ComboBox, int>();
            _dropDownListWithDropDownListModelIndexContainers.Add(_cardDateMonthField, CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX);
            _dropDownListWithDropDownListModelIndexContainers.Add(_cardDateYearField, CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX);
        }

        /// <summary>
        /// Initialize inspectors for all textboxes and drop-down lists.
        /// </summary>
        private void InitializeControlInspectors()
        {
            InitializeTextBoxInspectors();
            InitializeDropDownListInspectors();
        }

        /// <summary>
        /// Initialize inspectors for textboxes.
        /// </summary>
        private void InitializeTextBoxInspectors()
        {
            foreach ( KeyValuePair<TextBox, int> container in _textBoxWithTextBoxModelIndexContainers )
            {
                AssignTextBoxInspectors(container.Key, container.Value);
            }
        }

        /// <summary>
        /// Assign inspectors for textbox.
        /// </summary>
        private void AssignTextBoxInspectors(TextBox textBox, int textBoxIndex)
        {
            textBox.TextChanged += (sender, eventArguments) => _creditCardPaymentModel.UpdateTextBoxInspectors(textBoxIndex, textBox.Text, textBox.MaxLength);
            textBox.Leave += (sender, eventArguments) => _creditCardPaymentModel.UpdateTextBoxInspectors(textBoxIndex, textBox.Text, textBox.MaxLength);
        }

        /// <summary>
        /// Initialize inspectors for drop-down lists.
        /// </summary>
        private void InitializeDropDownListInspectors()
        {
            foreach ( KeyValuePair<ComboBox, int> container in _dropDownListWithDropDownListModelIndexContainers )
            {
                AssignDropDownListInspectors(container.Key, container.Value);
            }
        }

        /// <summary>
        /// Assign inspectors for drop-down list.
        /// </summary>
        private void AssignDropDownListInspectors(ComboBox dropDownList, int dropDownListIndex)
        {
            dropDownList.SelectionChangeCommitted += (sender, eventArguments) => _creditCardPaymentModel.UpdateDropDownListInspectors(dropDownListIndex, dropDownList.SelectedIndex);
            dropDownList.Leave += (sender, eventArguments) => _creditCardPaymentModel.UpdateDropDownListInspectors(dropDownListIndex, dropDownList.SelectedIndex);
        }

        /// <summary>
        /// Update initial values for all inspectors.
        /// </summary>
        private void UpdateInitialValuesForInspectors()
        {
            foreach ( KeyValuePair<TextBox, int> container in _textBoxWithTextBoxModelIndexContainers )
            {
                TextBox textBox = container.Key;
                int textBoxModelIndex = container.Value;
                _creditCardPaymentModel.UpdateTextBoxInspectors(textBoxModelIndex, textBox.Text, textBox.MaxLength);
            }
            foreach ( KeyValuePair<ComboBox, int> container in _dropDownListWithDropDownListModelIndexContainers )
            {
                ComboBox dropDownList = container.Key;
                int dropDownListModelIndex = container.Value;
                _creditCardPaymentModel.UpdateDropDownListInspectors(dropDownListModelIndex, dropDownList.SelectedIndex);
            }
        }
    }
}
