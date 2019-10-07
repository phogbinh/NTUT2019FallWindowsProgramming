namespace OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace
{
    public class TextBoxIsNonEmptyChecker : TextBoxChecker
    {
        private const string ERROR_TEXT_BOX_IS_EMPTY = "This field is empty.";

        public TextBoxIsNonEmptyChecker() : base()
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
