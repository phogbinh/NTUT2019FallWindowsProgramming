namespace InputInspectingElements
{
    public static class InputInspectorTypeHelper
    {
        public const int FLAG_TEXT_BOX_IS_MAIL = 1;
        public const int FLAG_TEXT_BOX_IS_NOT_EMPTY = FLAG_TEXT_BOX_IS_MAIL << 1;
        public const int FLAG_TEXT_BOX_IS_OF_FULL_LENGTH = FLAG_TEXT_BOX_IS_NOT_EMPTY << 1;
        public const int FLAG_DROP_DOWN_LIST_IS_SELECTED = FLAG_TEXT_BOX_IS_OF_FULL_LENGTH << 1;

        /// <summary>
        /// Return true if the given inputInspectorTypeFlag is in range of textbox inspector types.
        /// </summary>
        public static bool IsInRangeOfTextBoxInspectorTypes(int inputInspectorTypeFlag)
        {
            return ( FLAG_TEXT_BOX_IS_MAIL <= inputInspectorTypeFlag ) && ( inputInspectorTypeFlag <= ( FLAG_TEXT_BOX_IS_MAIL & FLAG_TEXT_BOX_IS_NOT_EMPTY & FLAG_TEXT_BOX_IS_OF_FULL_LENGTH ) );
        }

        /// <summary>
        /// Return true if the given inputInspectorTypeFlag is in range of drop-down list inspector types.
        /// </summary>
        public static bool IsInRangeOfDropDownListInspectorTypes(int inputInspectorTypeFlag)
        {
            return inputInspectorTypeFlag == FLAG_DROP_DOWN_LIST_IS_SELECTED;
        }

        /// <summary>
        /// Return true if inputInspectorTypeFlag contains the textbox-is-mail-flag.
        /// </summary>
        public static bool IsContainingTextBoxIsMailFlag(int inputInspectorTypeFlag)
        {
            return BitHelper.IsContainingOneBitOnFlag(inputInspectorTypeFlag, FLAG_TEXT_BOX_IS_MAIL);
        }

        /// <summary>
        /// Return true if inputInspectorTypeFlag contains the textbox-is-not-empty-flag.
        /// </summary>
        public static bool IsContainingTextBoxIsNotEmptyFlag(int inputInspectorTypeFlag)
        {
            return BitHelper.IsContainingOneBitOnFlag(inputInspectorTypeFlag, FLAG_TEXT_BOX_IS_NOT_EMPTY);
        }

        /// <summary>
        /// Return true if inputInspectorTypeFlag contains the textbox-is-of-full-length-flag.
        /// </summary>
        public static bool IsContainingTextBoxIsOfFullLengthFlag(int inputInspectorTypeFlag)
        {
            return BitHelper.IsContainingOneBitOnFlag(inputInspectorTypeFlag, FLAG_TEXT_BOX_IS_OF_FULL_LENGTH);
        }

        /// <summary>
        /// Return true if inputInspectorTypeFlag contains the drop-down-list-is-selected-flag.
        /// </summary>
        public static bool IsContainingDropDownListIsSelectedFlag(int inputInspectorTypeFlag)
        {
            return BitHelper.IsContainingOneBitOnFlag(inputInspectorTypeFlag, FLAG_DROP_DOWN_LIST_IS_SELECTED);
        }
    }
}
