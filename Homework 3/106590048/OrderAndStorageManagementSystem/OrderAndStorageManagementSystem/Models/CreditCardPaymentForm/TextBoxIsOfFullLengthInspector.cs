namespace OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace
{
    public class TextBoxIsOfFullLengthInspector : TextBoxInspector
    {
        private const string ERROR_TEXT_BOX_IS_OF_LOSS_LENGTH = "This field is of insufficient length.";

        public TextBoxIsOfFullLengthInspector() : base()
        {
            /* Body intentionally empty */
        }

        // Protest on Dr.Smell
        public override bool IsValid()
        {
            return _text.Length == _maxTextLength;
        }

        // Protest on Dr.Smell
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_OF_LOSS_LENGTH;
        }
    }
}
