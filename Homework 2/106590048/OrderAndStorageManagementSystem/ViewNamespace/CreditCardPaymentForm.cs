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
            InitializeControlCheckersOnValueChanged();
            InitializeControlCheckersOnControlLeave();
        }

        // Protest on Dr.Smell
        private void InitializeControlCheckersOnValueChanged()
        {
            _lastNameField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_lastNameField, CreditCardPaymentModel.LAST_NAME_FIELD_INDEX, _lastNameField.Text, _lastNameField.MaxLength);
            _firstNameField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_firstNameField, CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX, _firstNameField.Text, _firstNameField.MaxLength);
            _cardNumberFirstField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberFirstField, CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX, _cardNumberFirstField.Text, _cardNumberFirstField.MaxLength);
            _cardNumberSecondField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberSecondField, CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX, _cardNumberSecondField.Text, _cardNumberSecondField.MaxLength);
            _cardNumberThirdField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberThirdField, CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX, _cardNumberThirdField.Text, _cardNumberThirdField.MaxLength);
            _cardNumberFourthField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberFourthField, CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX, _cardNumberFourthField.Text, _cardNumberFourthField.MaxLength);
            _cardDateMonthField.SelectionChangeCommitted += (sender, eventArguments) => UpdateDropDownListCheckersAndSetError(_cardDateMonthField, CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX, _cardDateMonthField.SelectedIndex);
            _cardDateYearField.SelectionChangeCommitted += (sender, eventArguments) => UpdateDropDownListCheckersAndSetError(_cardDateYearField, CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX, _cardDateYearField.SelectedIndex);
            _cardSecurityCodeField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardSecurityCodeField, CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX, _cardSecurityCodeField.Text, _cardSecurityCodeField.MaxLength);
            _emailField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_emailField, CreditCardPaymentModel.EMAIL_FIELD_INDEX, _emailField.Text, _emailField.MaxLength);
            _addressField.TextChanged += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_addressField, CreditCardPaymentModel.ADDRESS_FIELD_INDEX, _addressField.Text, _addressField.MaxLength);
        }

        // Protest on Dr.Smell
        private void InitializeControlCheckersOnControlLeave()
        {
            _lastNameField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_lastNameField, CreditCardPaymentModel.LAST_NAME_FIELD_INDEX, _lastNameField.Text, _lastNameField.MaxLength);
            _firstNameField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_firstNameField, CreditCardPaymentModel.FIRST_NAME_FIELD_INDEX, _firstNameField.Text, _firstNameField.MaxLength);
            _cardNumberFirstField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberFirstField, CreditCardPaymentModel.CARD_NUMBER_FIRST_FIELD_INDEX, _cardNumberFirstField.Text, _cardNumberFirstField.MaxLength);
            _cardNumberSecondField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberSecondField, CreditCardPaymentModel.CARD_NUMBER_SECOND_FIELD_INDEX, _cardNumberSecondField.Text, _cardNumberSecondField.MaxLength);
            _cardNumberThirdField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberThirdField, CreditCardPaymentModel.CARD_NUMBER_THIRD_FIELD_INDEX, _cardNumberThirdField.Text, _cardNumberThirdField.MaxLength);
            _cardNumberFourthField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardNumberFourthField, CreditCardPaymentModel.CARD_NUMBER_FOURTH_FIELD_INDEX, _cardNumberFourthField.Text, _cardNumberFourthField.MaxLength);
            _cardDateMonthField.Leave += (sender, eventArguments) => UpdateDropDownListCheckersAndSetError(_cardDateMonthField, CreditCardPaymentModel.CARD_DATE_MONTH_FIELD_INDEX, _cardDateMonthField.SelectedIndex);
            _cardDateYearField.Leave += (sender, eventArguments) => UpdateDropDownListCheckersAndSetError(_cardDateYearField, CreditCardPaymentModel.CARD_DATE_YEAR_FIELD_INDEX, _cardDateYearField.SelectedIndex);
            _cardSecurityCodeField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_cardSecurityCodeField, CreditCardPaymentModel.CARD_SECURITY_CODE_FIELD_INDEX, _cardSecurityCodeField.Text, _cardSecurityCodeField.MaxLength);
            _emailField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_emailField, CreditCardPaymentModel.EMAIL_FIELD_INDEX, _emailField.Text, _emailField.MaxLength);
            _addressField.Leave += (sender, eventArguments) => UpdateTextBoxCheckersAndSetError(_addressField, CreditCardPaymentModel.ADDRESS_FIELD_INDEX, _addressField.Text, _addressField.MaxLength);
        }

        // Protest on Dr.Smell
        private void UpdateTextBoxCheckersAndSetError(RichTextBox textBox, int textBoxIndex, string text, int maxTextLength)
        {
            _creditCardPaymentPresentationModel.UpdateTextBoxCheckers(textBoxIndex, text, maxTextLength);
            _errorProvider.SetError(textBox, _creditCardPaymentPresentationModel.GetControlError(textBoxIndex));
            RefreshControls();
        }

        // Protest on Dr.Smell
        private void UpdateDropDownListCheckersAndSetError(ComboBox dropDownList, int dropDownListIndex, int selectedIndex)
        {
            _creditCardPaymentPresentationModel.UpdateDropDownListCheckers(dropDownListIndex, selectedIndex);
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
