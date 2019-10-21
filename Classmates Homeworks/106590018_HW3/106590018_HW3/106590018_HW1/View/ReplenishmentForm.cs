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
    public partial class ReplenishmentForm : Form
    {

        private int _amount = 0;
        public ReplenishmentForm()
        {
            InitializeComponent();
        }

        //constructor
        public ReplenishmentForm(string name, string type, string price, string inventory)
        {   
            InitializeComponent();
            _productName.Text = name;
            _productType.Text = type;
            _productPrice.Text = price;
            _inventory.Text = inventory;
        }

        //確認補貨數量
        private void CorrectTheReplenishment(object sender, EventArgs e)
        {
            if (int.TryParse(_replenishment.Text, out _amount))
            {
                InventorySystem inventorySystem = (InventorySystem)this.Owner;
                inventorySystem.InventoryAmount = int.Parse(_replenishment.Text);
                MessageBox.Show("補貨成功");
                this.Close();
            }
            else
                MessageBox.Show("請輸入整數數字");
        }
    }
}
