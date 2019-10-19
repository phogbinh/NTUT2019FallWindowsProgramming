using OrderAndStorageManagementSystem.PresentationModels.Utilities;

namespace OrderAndStorageManagementSystem.PresentationModels
{
    public class MainPresentationModel
    {
        public ControlStates OrderSystemButton
        {
            get
            {
                return _orderSystemButton;
            }
        }
        public ControlStates InventorySystemButton
        {
            get
            {
                return _inventorySystemButton;
            }
        }
        private ControlStates _orderSystemButton;
        private ControlStates _inventorySystemButton;

        public MainPresentationModel()
        {
            _orderSystemButton = new ControlStates();
            _inventorySystemButton = new ControlStates();
        }

        // Protest on Dr.Smell
        public void CloseOrderForm()
        {
            _orderSystemButton.Enabled = true;
        }

        // Protest on Dr.Smell
        public void CloseInventoryForm()
        {
            _inventorySystemButton.Enabled = true;
        }

        // Protest on Dr.Smell
        public void ClickOrderSystemButton()
        {
            _orderSystemButton.Enabled = false;
        }

        // Protest on Dr.Smell
        public void ClickInventorySystemButton()
        {
            _inventorySystemButton.Enabled = false;
        }
    }
}
