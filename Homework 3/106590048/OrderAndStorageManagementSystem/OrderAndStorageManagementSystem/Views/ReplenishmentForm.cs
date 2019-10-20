using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class ReplenishmentForm : Form
    {
        private Model _model;
        private Product _product;

        public ReplenishmentForm(Model modelData, Product productData)
        {
            InitializeComponent();
            _model = modelData;
            _product = productData;
        }
    }
}
