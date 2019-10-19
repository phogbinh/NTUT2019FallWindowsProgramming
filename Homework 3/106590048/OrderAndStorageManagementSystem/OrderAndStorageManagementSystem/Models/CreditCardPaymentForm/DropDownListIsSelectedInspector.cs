namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public class DropDownListIsSelectedInspector : IInputInspector
    {
        private const string ERROR_DROP_DOWN_LIST_IS_IGNORED = "This field has not been selected.";
        private int _selectedIndex;

        public DropDownListIsSelectedInspector()
        {
            /* Body intentionally empty */
        }

        // Protest on Dr.Smell
        public bool IsValid()
        {
            return _selectedIndex > -1;
        }

        // Protest on Dr.Smell
        public void Set(int newSelectedIndex)
        {
            _selectedIndex = newSelectedIndex;
        }

        // Protest on Dr.Smell
        public string GetError()
        {
            return ERROR_DROP_DOWN_LIST_IS_IGNORED;
        }
    }
}
