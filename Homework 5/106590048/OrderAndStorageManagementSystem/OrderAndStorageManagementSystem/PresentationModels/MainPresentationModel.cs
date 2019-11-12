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
        public ControlStates ProductManageSystemButton
        {
            get
            {
                return _productManageSystemButton;
            }
        }
        private ControlStates _orderSystemButton;
        private ControlStates _inventorySystemButton;
        private ControlStates _productManageSystemButton;

        public MainPresentationModel()
        {
            _orderSystemButton = new ControlStates();
            _inventorySystemButton = new ControlStates();
            _productManageSystemButton = new ControlStates();
        }

        /// <summary>
        /// Close the order form.
        /// </summary>
        public void CloseOrderForm()
        {
            _orderSystemButton.Enabled = true;
        }

        /// <summary>
        /// Close the inventory form.
        /// </summary>
        public void CloseInventoryForm()
        {
            _inventorySystemButton.Enabled = true;
        }

        /// <summary>
        /// Close the product management form.
        /// </summary>
        public void CloseProductManagementForm()
        {
            _productManageSystemButton.Enabled = true;
        }

        /// <summary>
        /// Click order system button.
        /// </summary>
        public void ClickOrderSystemButton()
        {
            _orderSystemButton.Enabled = false;
        }

        /// <summary>
        /// Click inventory system button.
        /// </summary>
        public void ClickInventorySystemButton()
        {
            _inventorySystemButton.Enabled = false;
        }

        /// <summary>
        /// Click product manage system button.
        /// </summary>
        public void ClickProductManageSystemButton()
        {
            _productManageSystemButton.Enabled = false;
        }
    }
}
