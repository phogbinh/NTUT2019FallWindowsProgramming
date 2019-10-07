namespace OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace
{
    public abstract class TextBoxChecker : InputChecker
    {
        protected string _text;
        protected int _maxTextLength;

        public TextBoxChecker()
        {
            /* Body intentionally empty */
        }

        // Protest on Dr.Smell
        public void Set(string newText, int newMaxTextLength)
        {
            _text = newText;
            _maxTextLength = newMaxTextLength;
        }
    }
}
