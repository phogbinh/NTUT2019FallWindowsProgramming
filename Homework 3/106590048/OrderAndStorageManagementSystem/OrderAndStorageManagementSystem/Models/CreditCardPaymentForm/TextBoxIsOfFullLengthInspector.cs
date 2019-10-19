namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public class TextBoxIsOfFullLengthInspector : TextBoxInspector
    {
        private const string ERROR_TEXT_BOX_IS_OF_LOSS_LENGTH = "This field is of insufficient length.";
        private string Text
        {
            get
            {
                return _text;
            }
        }
        private int MaxTextLength
        {
            get
            {
                return _maxTextLength;
            }
        }

        public TextBoxIsOfFullLengthInspector() : base()
        {
            /* Body intentionally empty */
        }

        // Protest on Dr.Smell
        public override bool IsValid()
        {
            return Text.Length == MaxTextLength;
        }

        // Protest on Dr.Smell
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_OF_LOSS_LENGTH;
        }
    }
}
