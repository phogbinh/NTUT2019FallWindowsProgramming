using OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void UpdateTextBoxCheckers(int textBoxIndex, string text, int maxTextLength)
        {
            _creditCardPaymentModel.UpdateTextBoxCheckers(textBoxIndex, text, maxTextLength);
            UpdateSubmitButton();
        }

        // Protest on Dr.Smell
        public void UpdateDropDownListCheckers(int dropDownListIndex, int selectedIndex)
        {
            _creditCardPaymentModel.UpdateDropDownListCheckers(dropDownListIndex, selectedIndex);
            UpdateSubmitButton();
        }

        // Protest on Dr.Smell
        private void UpdateSubmitButton()
        {
            _submitButton.Enabled = _creditCardPaymentModel.AllCheckersAreValid();
        }

        // Protest on Dr.Smell
        public string GetControlError(int controlIndex)
        {
            return _creditCardPaymentModel.GetControlError(controlIndex);
        }
    }
}
