namespace OrderAndStorageManagementSystem.Models.Utilities.InputInspectorUtilities
{
    public class DropDownListIsSelectedInspector : IInputInspector
    {
        private const string ERROR_DROP_DOWN_LIST_IS_IGNORED = "This field has not been selected.";
        private int _selectedIndex;

        public DropDownListIsSelectedInspector()
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Return true if the drop-down list value is selected.
        /// </summary>
        public bool IsValid()
        {
            return _selectedIndex > -1;
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
            return ERROR_DROP_DOWN_LIST_IS_IGNORED;
        }
    }
}
