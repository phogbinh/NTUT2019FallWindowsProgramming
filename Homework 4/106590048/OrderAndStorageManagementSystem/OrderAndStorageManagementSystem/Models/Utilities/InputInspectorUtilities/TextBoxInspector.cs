namespace OrderAndStorageManagementSystem.Models.Utilities.InputInspectorUtilities
{
    public abstract class TextBoxInspector : IInputInspector
    {
        protected string _text;
        protected int _maxTextLength;

        public TextBoxInspector()
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Set a new text and new max text length for the textbox.
        /// </summary>
        public void Set(string newText, int newMaxTextLength)
        {
            _text = newText;
            _maxTextLength = newMaxTextLength;
        }

        /// <summary>
        /// Return true if the textbox is valid.
        /// </summary>
        public abstract bool IsValid();

        /// <summary>
        /// Return the error of this inspector.
        /// </summary>
        public abstract string GetError();
    }
}
