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
        private CreditCardPaymentPresentationModel _creditCardPaymentPresentationModel;
        private CreditCardPaymentModel _creditCardPaymentModel;
        private Model _model;
        private IDictionary<TextBox, int> _textBoxWithTextBoxModelIndexContainers;

        public CreditCardPaymentForm(CreditCardPaymentPresentationModel creditCardPaymentPresentationModelData, CreditCardPaymentModel creditCardPaymentModelData, Model modelData)
        {
            InitializeComponent();
            _creditCardPaymentPresentationModel = creditCardPaymentPresentationModelData;
            _creditCardPaymentModel = creditCardPaymentModelData;
            _model = modelData;
            // UI
            this.FormClosed += (sender, eventArguments) => _cardSecurityCodeField.Text = AppDefinition.EMPTY_STRING;
            _submitButton.Click += ClickSubmitButton;
            InitializeInputLimits();
            InitializeTextBoxWithTextBoxModelIndexContainers();
            InitializeControlInspectors();
            // Initial UI States
            InitializeInspectors();
            RefreshControls();
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
        /// Initialize inspectors for all textboxes and drop-down lists.
        /// </summary>
        private void InitializeControlInspectors()
        {
            InitializeTextBoxInspectorsAndSetErrors();
            InitializeDropDownListInspectorsAndSetErrors();
        }

        /// <summary>
        /// Initialize inspectors for textboxes and set error for them.
        /// </summary>
        private void InitializeTextBoxInspectorsAndSetErrors()
        {
            foreach ( KeyValuePair<TextBox, int> container in _textBoxWithTextBoxModelIndexContainers )
            {
                AssignTextBoxInspectorAndSetError(container.Key, container.Value);
            }
        }

        /// <summary>
        /// Assign inspectors for textbox and set error for it.
        /// </summary>
        private void AssignTextBoxInspectorAndSetError(TextBox textBox, int textBoxIndex)
        {
            textBox.TextChanged += (sender, eventArguments) => UpdateTextBoxInspectorsAndSetError(textBox, textBoxIndex);
            textBox.Leave += (sender, eventArguments) => UpdateTextBoxInspectorsAndSetError(textBox, textBoxIndex);
        }

        /// <summary>
        /// Update inspectors for textbox and set error for it.
        /// </summary>
        private void UpdateTextBoxInspectorsAndSetError(TextBox textBox, int textBoxIndex)
        {
            Action updateTextBoxInspectorsFunction = () => _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(textBoxIndex, textBox.Text, textBox.MaxLength);
            UpdateControlInspectorsAndSetError(textBox, textBoxIndex, updateTextBoxInspectorsFunction);
        }

        /// <summary>
        /// Update inspectors for control and set error for it.
        /// </summary>
        private void UpdateControlInspectorsAndSetError(Control control, int controlIndex, Action updateControlInspectorsFunction)
        {
            updateControlInspectorsFunction();
            _errorProvider.SetError(control, _creditCardPaymentModel.GetControlError(controlIndex));
            RefreshControls();
        }

        /// <summary>
        /// Initialize inspectors for drop-down lists and set error for them.
        /// </summary>
        private void InitializeDropDownListInspectorsAndSetErrors()
        {
            AssignDropDownListInspectorsAndSetErrors(_cardDateMonthField, CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX);
            AssignDropDownListInspectorsAndSetErrors(_cardDateYearField, CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX);
        }

        /// <summary>
        /// Assign inspectors for drop-down list and set error for it.
        /// </summary>
        private void AssignDropDownListInspectorsAndSetErrors(ComboBox dropDownList, int dropDownListIndex)
        {
            dropDownList.SelectionChangeCommitted += (sender, eventArguments) => UpdateDropDownListInspectorsAndSetError(dropDownList, dropDownListIndex);
            dropDownList.Leave += (sender, eventArguments) => UpdateDropDownListInspectorsAndSetError(dropDownList, dropDownListIndex);
        }

        /// <summary>
        /// Update inspectors for drop-down list and set error for it.
        /// </summary>
        private void UpdateDropDownListInspectorsAndSetError(ComboBox dropDownList, int dropDownListIndex)
        {
            Action updateDropDownListInspectorsFunction = () => _creditCardPaymentPresentationModel.UpdateDropDownListInspectors(dropDownListIndex, dropDownList.SelectedIndex);
            UpdateControlInspectorsAndSetError(dropDownList, dropDownListIndex, updateDropDownListInspectorsFunction);
        }

        /// <summary>
        /// Initialize all inspectors.
        /// </summary>
        private void InitializeInspectors()
        {
            UpdateInitialValuesForInspectors();
            RefreshControls();
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
                _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(textBoxModelIndex, textBox.Text, textBox.MaxLength);
            }
            _creditCardPaymentPresentationModel.UpdateDropDownListInspectors(CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX, _cardDateMonthField.SelectedIndex);
            _creditCardPaymentPresentationModel.UpdateDropDownListInspectors(CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX, _cardDateYearField.SelectedIndex);
        }

        /// <summary>
        /// Refresh controls.
        /// </summary>
        private void RefreshControls()
        {
            _submitButton.Enabled = _creditCardPaymentPresentationModel.SubmitButton.Enabled;
        }
    }
}
