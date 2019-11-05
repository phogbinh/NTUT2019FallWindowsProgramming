namespace InputInspectingElements.InputInspectors
{
    public class TextBoxIsNotEmptyInspector : TextBoxInspector
    {
        private const string ERROR_TEXT_BOX_IS_EMPTY = "This field is empty.";

        public TextBoxIsNotEmptyInspector() : base()
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Return true if the textbox is not empty.
        /// </summary>
        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_text);
        }

        /// <summary>
        /// Return the error of this inspector.
        /// </summary>
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_EMPTY;
        }
    }
}
