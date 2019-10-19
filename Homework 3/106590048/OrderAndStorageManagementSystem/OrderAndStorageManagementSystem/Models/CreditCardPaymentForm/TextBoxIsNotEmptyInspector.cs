namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public class TextBoxIsNotEmptyInspector : TextBoxInspector
    {
        private const string ERROR_TEXT_BOX_IS_EMPTY = "This field is empty.";

        public TextBoxIsNotEmptyInspector() : base()
        {
            /* Body intentionally empty */
        }

        // Protest on Dr.Smell
        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_text);
        }

        // Protest on Dr.Smell
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_EMPTY;
        }
    }
}
