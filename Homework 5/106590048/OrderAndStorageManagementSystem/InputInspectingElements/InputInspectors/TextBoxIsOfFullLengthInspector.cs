namespace InputInspectingElements.InputInspectors
{
    public class TextBoxIsOfFullLengthInspector : TextBoxInspector
    {
        private const string ERROR_TEXT_BOX_IS_NOT_OF_FULL_LENGTH = "Textbox is of insufficient length.";

        public TextBoxIsOfFullLengthInspector(string textData, int maxTextLengthData) : base(textData, maxTextLengthData)
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Return true if the textbox is of full length.
        /// </summary>
        public override bool IsValid()
        {
            return _text.Length == _maxTextLength;
        }

        /// <summary>
        /// Return the error of this inspector.
        /// </summary>
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_NOT_OF_FULL_LENGTH;
        }
    }
}
