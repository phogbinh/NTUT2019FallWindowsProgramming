using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class InventoryForm : Form
    {
        private Model _model;

        public InventoryForm(Model modelData)
        {
            InitializeComponent();
            _model = modelData;
            InitializeStorageDataGridView();
        }
        
        // Protest on Dr.Smell
        private void InitializeStorageDataGridView()
        {
            foreach (Product product in _model.Products)
            {
                _storageDataGridView.Rows.Add(product.Name, product.Type, product.Price.GetCurrencyFormat(), product.StorageQuantity, null);
            }
        }
    }
}
