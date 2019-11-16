namespace InputInspectingElements.InputInspectors
{
    public class DropDownListIsSelectedInspector : IInputInspector
    {
        private const string ERROR_DROP_DOWN_LIST_IS_NOT_SELECTED = "Drop-down list is not selected.";
        private const int EMPTY_SELECTION_INDEX = -1;
        private int _selectedIndex;

        public DropDownListIsSelectedInspector(int selectedIndexData)
        {
            _selectedIndex = selectedIndexData;
        }

        /// <summary>
        /// Return true if the drop-down list value is selected.
        /// </summary>
        public bool IsValid()
        {
            return _selectedIndex > EMPTY_SELECTION_INDEX;
        }

        /// <summary>
        /// Set a new selected index for the drop-down list.
        /// </summary>
        public void Set(int newSelectedIndex)
        {
            _selectedIndex = newSelectedIndex;
        }

        /// <summary>
        /// Return the error of this inspector.
        /// </summary>
        public string GetError()
        {
            return ERROR_DROP_DOWN_LIST_IS_NOT_SELECTED;
        }
    }
}
