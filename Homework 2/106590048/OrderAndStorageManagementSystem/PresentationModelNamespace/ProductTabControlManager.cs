using OrderAndStorageManagementSystem.ViewNamespace;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class ProductTabControlManager
    {
        private OrderForm _orderForm;
        private TabControl _tabControl;
        private ProductTabPagesManager _tabPagesManager;

        public ProductTabControlManager(OrderForm orderFormData, TabControl tabControlData)
        {
            _orderForm = orderFormData;
            _tabControl = tabControlData;
            _tabPagesManager = new ProductTabPagesManager(_orderForm, _tabControl.TabPages);
        }

        /// <summary>
        /// Initialize tab control.
        /// </summary>
        public void InitializeTabControl()
        {
            _tabControl.SelectedIndexChanged += new EventHandler(ChangeTabPage);
            _tabPagesManager.InitializeTabPages();
        }

        /// <summary>
        /// Change tab page event handler.
        /// </summary>
        private void ChangeTabPage(object sender, EventArgs events)
        {
            _orderForm.SelectNoProduct();
        }
    }
}
