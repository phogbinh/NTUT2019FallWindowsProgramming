using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_System
{
    public partial class FormMenu : Form
    {
        ModelData _model;
        public FormMenu(ref ModelData model)
        {
            InitializeComponent();
            _model = model;
        }

        // Create Order System Form
        private void ClickOrderSystem(object sender, EventArgs e)
        {
            SetButtonEnable(false);
            new OrderSystem(ref _model).ShowDialog();
            SetButtonEnable(true);
        }

        // Exit the system
        private void ClickExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Create Inventory System Form
        private void ClickInventorySystem(object sender, EventArgs e)
        {
            SetButtonEnable(false);
            new InventorySystem().ShowDialog();
            SetButtonEnable(true);
        }

        // Change enability of buttons
        private void SetButtonEnable(bool trigger)
        {
            _orderSystem.Enabled = trigger;
            _inventorySystem.Enabled = trigger;
        }
    }
}
