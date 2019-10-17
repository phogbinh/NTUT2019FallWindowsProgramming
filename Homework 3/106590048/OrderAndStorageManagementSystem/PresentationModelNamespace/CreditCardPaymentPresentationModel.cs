using OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace;

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

        private delegate void UpdateControlInspectorsFunction();

        // Protest on Dr.Smell
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            UpdateControlInspectorsFunction updateTextBoxInspectorsFunction = delegate ()
            {
                _creditCardPaymentModel.UpdateTextBoxInspectors(textBoxIndex, text, maxTextLength);
            };
            UpdateControlInspectors(updateTextBoxInspectorsFunction);
        }

        // Protest on Dr.Smell
        private void UpdateControlInspectors(UpdateControlInspectorsFunction updateControlInspectorsFunction)
        {
            updateControlInspectorsFunction();
            UpdateSubmitButton();
        }

        // Protest on Dr.Smell
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            UpdateControlInspectorsFunction updateDropDownListInspectorsFunction = delegate ()
            {
                _creditCardPaymentModel.UpdateDropDownListInspectors(dropDownListIndex, selectedIndex);
            };
            UpdateControlInspectors(updateDropDownListInspectorsFunction);
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
