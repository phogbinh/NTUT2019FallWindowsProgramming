﻿using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace;
using OrderAndStorageManagementSystem.PresentationModelNamespace;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public partial class CreditCardPaymentForm : Form
    {
        private const string ORDER_COMPLETE_MESSAGE = "訂購完成";

        private CreditCardPaymentPresentationModel _creditCardPaymentPresentationModel;

        public CreditCardPaymentForm(CreditCardPaymentPresentationModel creditCardPaymentPresentationModelData)
        {
            InitializeComponent();
            _creditCardPaymentPresentationModel = creditCardPaymentPresentationModelData;
            // UI
            _submitButton.Click += ClickSubmitButton;
            InitializeInputHandlers();
            InitializeControlInspectors();
            // Initial UI States
            InitializeInspectors();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void ClickSubmitButton(object sender, EventArgs eventArguments)
        {
            if ( MessageBox.Show(ORDER_COMPLETE_MESSAGE) == DialogResult.OK )
            {
                _cardSecurityCodeField.Text = AppDefinition.EMPTY_STRING;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Protest on Dr.Smell
        private void InitializeInputHandlers()
        {
            _lastNameField.KeyPress += InputLettersOrWhiteSpace;
            _firstNameField.KeyPress += InputLettersOrWhiteSpace;
            _cardNumberFirstField.KeyPress += InputNumbers;
            _cardNumberSecondField.KeyPress += InputNumbers;
            _cardNumberThirdField.KeyPress += InputNumbers;
            _cardNumberFourthField.KeyPress += InputNumbers;
            _cardSecurityCodeField.KeyPress += InputNumbers;
        }

        // Protest on Dr.Smell
        private void InputLettersOrWhiteSpace(object sender, KeyPressEventArgs eventArguments)
        {
            if ( !char.IsLetter(eventArguments.KeyChar) && !char.IsWhiteSpace(eventArguments.KeyChar) )
            {
                eventArguments.Handled = true;
            }
        }

        // Protest on Dr.Smell
        private void InputNumbers(object sender, KeyPressEventArgs eventArguments)
        {
            if ( !char.IsDigit(eventArguments.KeyChar) )
            {
                eventArguments.Handled = true;
            }
        }

        // Protest on Dr.Smell
        private void InitializeControlInspectors()
        {
            InitializeTextBoxInspectorsAndSetErrors();
            InitializeDropDownListInspectorsAndSetErrors();
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxInspectorsAndSetErrors()
        {
            AssignTextBoxInspectorAndSetError(_lastNameField, CreditCardPaymentModel.LAST_NAME_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_firstNameField, CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_cardNumberFirstField, CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_cardNumberSecondField, CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_cardNumberThirdField, CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_cardNumberFourthField, CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_cardSecurityCodeField, CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_mailField, CreditCardPaymentModel.MAIL_FIELD_INDEX);
            AssignTextBoxInspectorAndSetError(_addressField, CreditCardPaymentModel.ADDRESS_FIELD_INDEX);
        }

        // Protest on Dr.Smell
        private void AssignTextBoxInspectorAndSetError(RichTextBox textBox, int textBoxIndex)
        {
            textBox.TextChanged += (sender, eventArguments) => UpdateTextBoxInspectorsAndSetError(textBox, textBoxIndex);
            textBox.Leave += (sender, eventArguments) => UpdateTextBoxInspectorsAndSetError(textBox, textBoxIndex);
        }

        // Protest on Dr.Smell
        private void UpdateTextBoxInspectorsAndSetError(RichTextBox textBox, int textBoxIndex)
        {
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(textBoxIndex, textBox.Text, textBox.MaxLength);
            _errorProvider.SetError(textBox, _creditCardPaymentPresentationModel.GetControlError(textBoxIndex));
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void InitializeDropDownListInspectorsAndSetErrors()
        {
            AssignDropDownListInspectorsAndSetErrors(_cardDateMonthField, CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX);
            AssignDropDownListInspectorsAndSetErrors(_cardDateYearField, CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX);
        }

        // Protest on Dr.Smell
        private void AssignDropDownListInspectorsAndSetErrors(ComboBox dropDownList, int dropDownListIndex)
        {
            dropDownList.SelectionChangeCommitted += (sender, eventArguments) => UpdateDropDownListInspectorsAndSetError(dropDownList, dropDownListIndex);
            dropDownList.Leave += (sender, eventArguments) => UpdateDropDownListInspectorsAndSetError(dropDownList, dropDownListIndex);
        }

        // Protest on Dr.Smell
        private void UpdateDropDownListInspectorsAndSetError(ComboBox dropDownList, int dropDownListIndex)
        {
            _creditCardPaymentPresentationModel.UpdateDropDownListInspectors(dropDownListIndex, dropDownList.SelectedIndex);
            _errorProvider.SetError(dropDownList, _creditCardPaymentPresentationModel.GetControlError(dropDownListIndex));
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void InitializeInspectors()
        {
            UpdateInitialValuesForInspectors();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void UpdateInitialValuesForInspectors()
        {
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.LAST_NAME_FIELD_INDEX, _lastNameField.Text, _lastNameField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX, _firstNameField.Text, _firstNameField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX, _cardNumberFirstField.Text, _cardNumberFirstField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX, _cardNumberSecondField.Text, _cardNumberSecondField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX, _cardNumberThirdField.Text, _cardNumberThirdField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX, _cardNumberFourthField.Text, _cardNumberFourthField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateDropDownListInspectors(CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX, _cardDateMonthField.SelectedIndex);
            _creditCardPaymentPresentationModel.UpdateDropDownListInspectors(CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX, _cardDateYearField.SelectedIndex);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX, _cardSecurityCodeField.Text, _cardSecurityCodeField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.MAIL_FIELD_INDEX, _mailField.Text, _mailField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxInspectors(CreditCardPaymentModel.ADDRESS_FIELD_INDEX, _addressField.Text, _addressField.MaxLength);
        }

        // Protest on Dr.Smell
        private void RefreshControls()
        {
            _submitButton.Enabled = _creditCardPaymentPresentationModel.SubmitButton.Enabled;
        }
    }
}
