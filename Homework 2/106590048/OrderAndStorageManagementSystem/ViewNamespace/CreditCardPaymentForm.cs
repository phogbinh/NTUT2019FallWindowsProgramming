using OrderAndStorageManagementSystem.ModelNamespace;
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
            InitializeControlCheckers();
            // Initial UI States
            InitializeCheckers();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void ClickSubmitButton(object sender, EventArgs eventArguments)
        {
            if ( MessageBox.Show(ORDER_COMPLETE_MESSAGE) == DialogResult.OK )
            {
                _cardSecurityCodeField.Text = AppDefinition.EMPTY_STRING;
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
        private void InitializeControlCheckers()
        {
            InitializeTextBoxCheckersAndSetErrors();
            InitializeDropDownListCheckersAndSetErrors();
        }

        // Protest on Dr.Smell
        private void InitializeTextBoxCheckersAndSetErrors()
        {
            AssignTextBoxCheckerAndSetError(_lastNameField, CreditCardPaymentModel.LAST_NAME_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_firstNameField, CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_cardNumberFirstField, CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_cardNumberSecondField, CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_cardNumberThirdField, CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_cardNumberFourthField, CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_cardSecurityCodeField, CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_emailField, CreditCardPaymentModel.EMAIL_FIELD_INDEX);
            AssignTextBoxCheckerAndSetError(_addressField, CreditCardPaymentModel.ADDRESS_FIELD_INDEX);
        }

        // Protest on Dr.Smell
        private void AssignTextBoxCheckerAndSetError(RichTextBox textBox, int textBoxIndex)
        {
            textBox.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(textBox, textBoxIndex);
            textBox.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(textBox, textBoxIndex);
        }

        // Protest on Dr.Smell
        private void UpdateTextBoxCheckersAndSetError(RichTextBox textBox, int textBoxIndex)
        {
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(textBoxIndex, textBox.Text, textBox.MaxLength);
            _errorProvider.SetError(textBox, _creditCardPaymentPresentationModel.GetControlError(textBoxIndex));
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void InitializeDropDownListCheckersAndSetErrors()
        {
            AssignDropDownListCheckersAndSetErrors(_cardDateMonthField, CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX);
            AssignDropDownListCheckersAndSetErrors(_cardDateYearField, CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX);
        }

        // Protest on Dr.Smell
        private void AssignDropDownListCheckersAndSetErrors(ComboBox dropDownList, int dropDownListIndex)
        {
            dropDownList.SelectionChangeCommitted += (sender, eventArguments) => UpdateDropDownListCheckersAndSetError(dropDownList, dropDownListIndex);
            dropDownList.Leave += (sender, eventArguments) => UpdateDropDownListCheckersAndSetError(dropDownList, dropDownListIndex);
        }

        // Protest on Dr.Smell
        private void UpdateDropDownListCheckersAndSetError(ComboBox dropDownList, int dropDownListIndex)
        {
            _creditCardPaymentPresentationModel.UpdateDropDownListCheckers(dropDownListIndex, dropDownList.SelectedIndex);
            _errorProvider.SetError(dropDownList, _creditCardPaymentPresentationModel.GetControlError(dropDownListIndex));
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void InitializeCheckers()
        {
            UpdateInitialValuesForCheckers();
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void UpdateInitialValuesForCheckers()
        {
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.LAST_NAME_FIELD_INDEX, _lastNameField.Text, _lastNameField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX, _firstNameField.Text, _firstNameField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX, _cardNumberFirstField.Text, _cardNumberFirstField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX, _cardNumberSecondField.Text, _cardNumberSecondField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX, _cardNumberThirdField.Text, _cardNumberThirdField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX, _cardNumberFourthField.Text, _cardNumberFourthField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateDropDownListCheckers(CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX, _cardDateMonthField.SelectedIndex);
            _creditCardPaymentPresentationModel.UpdateDropDownListCheckers(CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX, _cardDateYearField.SelectedIndex);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX, _cardSecurityCodeField.Text, _cardSecurityCodeField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.EMAIL_FIELD_INDEX, _emailField.Text, _emailField.MaxLength);
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(CreditCardPaymentModel.ADDRESS_FIELD_INDEX, _addressField.Text, _addressField.MaxLength);
        }

        // Protest on Dr.Smell
        private void RefreshControls()
        {
            _submitButton.Enabled = _creditCardPaymentPresentationModel.SubmitButton.Enabled;
        }
    }
}
