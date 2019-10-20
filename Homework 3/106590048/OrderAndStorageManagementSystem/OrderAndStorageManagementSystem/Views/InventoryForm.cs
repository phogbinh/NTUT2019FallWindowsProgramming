using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Properties;
using OrderAndStorageManagementSystem.Views.Utilities;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class InventoryForm : Form
    {
        private const int STORAGE_SUPPLY_BUTTON_COLUMN_INDEX = 4;
        private InventoryPresentationModel _inventoryPresentationModel;
        private Model _model;

        public InventoryForm(InventoryPresentationModel inventoryPresentationModelData, Model modelData)
        {
            InitializeComponent();
            _inventoryPresentationModel = inventoryPresentationModelData;
            _model = modelData;
            // UI
            _storageDataGridView.CellPainting += (sender, eventArguments) => DataGridViewHelper.InitializeButtonImageOfButtonColumn(eventArguments, STORAGE_SUPPLY_BUTTON_COLUMN_INDEX, Resources.img_delivery_truck);
            _storageDataGridView.CellContentClick += StorageDataGridViewCellContentClick;
            _storageDataGridView.SelectionChanged += (sender, eventArguments) => UpdateProductInfo();
            // Initial UI States
            InitializeStorageDataGridView();
        }

        // Protest on Dr.Smell
        private void StorageDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if ( eventArguments.RowIndex < 0 )
            {
                return;
            }
            if ( eventArguments.ColumnIndex == STORAGE_SUPPLY_BUTTON_COLUMN_INDEX )
            {
                ReplenishmentForm supplyForm;
                supplyForm = new ReplenishmentForm(_model, _inventoryPresentationModel.GetProduct(_storageDataGridView.CurrentRow.Index));
                supplyForm.ShowDialog();
            }
        }

        // Protest on Dr.Smell
        private void UpdateProductInfo()
        {
            Product currentSelectedProduct = _inventoryPresentationModel.GetProduct(_storageDataGridView.CurrentRow.Index);
            _productImage.Image = DataBaseManager.GetProductImageFromResources(currentSelectedProduct.Id);
            _productNameAndDescription.Text = currentSelectedProduct.GetProductNameAndDescription();
        }

        // Protest on Dr.Smell
        private void InitializeStorageDataGridView()
        {
            foreach ( Product product in _model.Products )
            {
                _storageDataGridView.Rows.Add(product.Name, product.Type, product.Price.GetCurrencyFormat(), product.StorageQuantity, null);
            }
        }
    }
}
