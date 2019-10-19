namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public abstract class TextBoxInspector : IInputInspector
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

        // Protest on Dr.Smell
        public abstract bool IsValid();

        // Protest on Dr.Smell
        public abstract string GetError();
    }
}
