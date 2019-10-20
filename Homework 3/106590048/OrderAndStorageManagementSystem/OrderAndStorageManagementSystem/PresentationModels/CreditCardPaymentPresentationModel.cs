using OrderAndStorageManagementSystem.Models.CreditCardPaymentForm;
using OrderAndStorageManagementSystem.PresentationModels.Utilities;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels
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

        /// <summary>
        /// Update member variables of all TextBoxInspectors of the textbox at textBoxIndex.
        /// </summary>
        public void UpdateTextBoxInspectors(int textBoxIndex, string text, int maxTextLength)
        {
            Action updateTextBoxInspectorsFunction = () => _creditCardPaymentModel.UpdateTextBoxInspectors(textBoxIndex, text, maxTextLength);
            UpdateControlInspectors(updateTextBoxInspectorsFunction);
        }

        /// <summary>
        /// Update member variable of all DropDownListInspectors of the drop-down list at dropDownListIndex.
        /// </summary>
        public void UpdateDropDownListInspectors(int dropDownListIndex, int selectedIndex)
        {
            Action updateDropDownListInspectorsFunction = () => _creditCardPaymentModel.UpdateDropDownListInspectors(dropDownListIndex, selectedIndex);
            UpdateControlInspectors(updateDropDownListInspectorsFunction);
        }

        /// <summary>
        /// Update member variable(s) of all InputInspectors of the control at controlIndex.
        /// </summary>
        private void UpdateControlInspectors(Action updateControlInspectorsFunction)
        {
            updateControlInspectorsFunction();
            UpdateSubmitButton();
        }

        /// <summary>
        /// Update enabled state of the submit button.
        /// </summary>
        private void UpdateSubmitButton()
        {
            _submitButton.Enabled = _creditCardPaymentModel.AreAllValidInspectors();
        }

        /// <summary>
        /// Get the first InputInspector error of the control at controlIndex.
        /// </summary>
        public string GetControlError(int controlIndex)
        {
            return _creditCardPaymentModel.GetControlError(controlIndex);
        }
    }
}
