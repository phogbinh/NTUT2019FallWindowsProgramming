using OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace;
using System;

namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class CreditCardPaymentPresentationModel
    {
        public ControlStates SubmitButton
        {
            get
            {
                return _submitButton;
            }
        }
        private CreditCardPaymentModel _creditCardPaymentModel;
        private ControlStates _submitButton;

        public CreditCardPaymentPresentationModel(CreditCardPaymentModel creditCardPaymentModelData)
        {
            _creditCardPaymentModel = creditCardPaymentModelData;
            _submitButton = new ControlStates();
        }

        // Protest on Dr.Smell
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            Action updateTextBoxInspectorsFunction = () => _creditCardPaymentModel.UpdateTextBoxInspectors(textBoxIndex, text, maxTextLength);
            UpdateControlInspectors(updateTextBoxInspectorsFunction);
        }

        // Protest on Dr.Smell
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            Action updateDropDownListInspectorsFunction = () => _creditCardPaymentModel.UpdateDropDownListInspectors(dropDownListIndex, selectedIndex);
            UpdateControlInspectors(updateDropDownListInspectorsFunction);
        }

        // Protest on Dr.Smell
        private void UpdateControlInspectors(Action updateControlInspectorsFunction)
        {
            updateControlInspectorsFunction();
            UpdateSubmitButton();
        }

        // Protest on Dr.Smell
        private void UpdateSubmitButton()
        {
            _submitButton.Enabled = _creditCardPaymentModel.AreAllValidInspectors();
        }

        // Protest on Dr.Smell
        public string GetControlError(int controlIndex)
        {
            return _creditCardPaymentModel.GetControlError(controlIndex);
        }
    }
}
