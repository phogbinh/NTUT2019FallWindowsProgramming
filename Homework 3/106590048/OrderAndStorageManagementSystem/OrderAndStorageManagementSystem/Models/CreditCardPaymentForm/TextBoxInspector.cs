namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public abstract class TextBoxInspector : InputInspector
    {
        protected string _text;
        protected int _maxTextLength;

        public TextBoxInspector()
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
