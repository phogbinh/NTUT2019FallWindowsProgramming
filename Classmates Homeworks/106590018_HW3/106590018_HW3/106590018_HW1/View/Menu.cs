using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106590018_Homework
{
    public partial class Menu : Form
    {
        private Model _model;
        private OrderForm _orderForm;
        private InventorySystem _inventorySystem;
        public Menu(Model model)
        {   
            InitializeComponent();
            this._model = model;   
        }

        //顯示orderSystem
        private void CallOrderSystem(object sender, EventArgs e)
        {
            this._orderForm = new OrderForm(_model);
            this._orderForm.Visible = true;
            _orderSystemButton.Enabled = false;
            _orderForm.FormClosed += CloseOrder;
        }

        //顯示InventorySystem
        private void CallInventorySystem(object sender, EventArgs e)
        {
            this._inventorySystem = new InventorySystem(_model);
            this._inventorySystem.Visible = true;
            _inventoryButton.Enabled = false;
            _inventorySystem.FormClosed += CloseInventory;
        }

        //關閉這個視窗
        private void ExitMenu(object sender, EventArgs e)
        {
            this.Close();
        }

        //OrderButton Enabled
        private void CloseOrder(object sender, EventArgs e)
        {
            _orderSystemButton.Enabled = true;
        }

        //InventoryButton Enabled
        private void CloseInventory(object sender, EventArgs e)
        {
            _inventoryButton.Enabled = true;
        }
    }
}
