using System;

namespace InputInspectingElements.InputInspectors
{
    public abstract class TextBoxInspector : IInputInspector
    {
        private const string ERROR_MAX_TEXT_LENGTH_CANNOT_BE_SET_TO_NEGATIVE = "Max text length cannot be set to negative.";
        protected string _text;
        protected int _maxTextLength;

        public TextBoxInspector(string textData, int maxTextLengthData)
        {
            if ( maxTextLengthData < 0 )
            {
                throw new ArgumentException(ERROR_MAX_TEXT_LENGTH_CANNOT_BE_SET_TO_NEGATIVE);
            }
            _text = textData;
            _maxTextLength = maxTextLengthData;
        }

        /// <summary>
        /// Set a new text and new max text length for the textbox.
        /// </summary>
        public void Set(string newText, int newMaxTextLength)
        {
            if ( newMaxTextLength < 0 )
            {
                throw new ArgumentException(ERROR_MAX_TEXT_LENGTH_CANNOT_BE_SET_TO_NEGATIVE);
            }
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
