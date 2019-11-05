namespace InputInspectingElements.InputInspectors
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

        /// <summary>
        /// Return true if the textbox is of full length.
        /// </summary>
        public override bool IsValid()
        {
            return Text.Length == MaxTextLength;
        }

        /// <summary>
        /// Return the error of this inspector.
        /// </summary>
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_OF_LOSS_LENGTH;
        }
    }
}
