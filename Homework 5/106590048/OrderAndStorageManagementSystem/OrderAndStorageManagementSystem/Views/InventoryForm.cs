using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.Properties;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class InventoryForm : Form
    {
        private const string ERROR_PRODUCT_IS_NOT_FOUND = "The given product is not found.";
        private const int STORAGE_PRODUCT_QUANTITY_COLUMN_INDEX = 3;
        private const int STORAGE_SUPPLY_BUTTON_COLUMN_INDEX = 4;
        private Model _model;

        public InventoryForm(Model modelData)
        {
            InitializeComponent();
            _model = modelData;
            this.Disposed += RemoveEvents;
            // Observers
            _model.ProductStorageQuantityChanged += UpdateProductStorageQuantityInStorageDataGridView;
            _model.ProductInfoChanged += ResetStorageDataGridViewOnProductInfoChangedOrOnProductAdded;
            _model.ProductAdded += ResetStorageDataGridViewOnProductInfoChangedOrOnProductAdded;
            // UI
            _storageDataGridView.CellPainting += (sender, eventArguments) => DataGridViewHelper.InitializeButtonImageOfButtonColumn(eventArguments, STORAGE_SUPPLY_BUTTON_COLUMN_INDEX, Resources.img_delivery_truck);
            _storageDataGridView.CellContentClick += ClickStorageDataGridViewCellContent;
            _storageDataGridView.SelectionChanged += (sender, eventArguments) => UpdateProductInfoView();
            // Initial UI States
            InitializeStorageDataGridView();
        }

        /// <summary>
        /// Unsubscribe from all events that were subscribed by this form.
        /// </summary>
        private void RemoveEvents(object sender, EventArgs eventArguments)
        {
            _model.ProductStorageQuantityChanged -= UpdateProductStorageQuantityInStorageDataGridView;
            _model.ProductInfoChanged -= ResetStorageDataGridViewOnProductInfoChangedOrOnProductAdded;
            _model.ProductAdded -= ResetStorageDataGridViewOnProductInfoChangedOrOnProductAdded;
        }

        /// <summary>
        /// Update storage quantity of the product in storage data grid view.
        /// </summary>
        private void UpdateProductStorageQuantityInStorageDataGridView(Product product)
        {
            int rowIndex = GetProductRowIndexInStorageDataGridView(product);
            _storageDataGridView.Rows[ rowIndex ].Cells[ STORAGE_PRODUCT_QUANTITY_COLUMN_INDEX ].Value = product.StorageQuantity;
        }

        /// <summary>
        /// Get row index of product in storage data grid view.
        /// </summary>
        private int GetProductRowIndexInStorageDataGridView(Product product)
        {
            for ( int rowIndex = 0; rowIndex < _storageDataGridView.Rows.Count; rowIndex++ )
            {
                if ( _model.GetProductAt(rowIndex) == product )
                {
                    return rowIndex;
                }
            }
            throw new ArgumentException(ERROR_PRODUCT_IS_NOT_FOUND);
        }

        /// <summary>
        /// Reset storage data grid view on product info changed.
        /// </summary>
        private void ResetStorageDataGridViewOnProductInfoChangedOrOnProductAdded(Product product)
        {
            _storageDataGridView.Rows.Clear();
            InitializeStorageDataGridView();
        }

        /// <summary>
        /// Click cell content of storage data grid view. Used to handle button column click.
        /// </summary>
        private void ClickStorageDataGridViewCellContent(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if ( eventArguments.RowIndex < 0 )
            {
                return;
            }
            if ( eventArguments.ColumnIndex == STORAGE_SUPPLY_BUTTON_COLUMN_INDEX )
            {
                ReplenishmentForm supplyForm;
                supplyForm = new ReplenishmentForm(_model, GetCurrentSelectedProduct());
                supplyForm.ShowDialog();
            }
        }

        /// <summary>
        /// Update product info view.
        /// </summary>
        private void UpdateProductInfoView()
        {
            Product currentSelectedProduct = GetCurrentSelectedProduct();
            _productImage.Image = System.Drawing.Image.FromFile(currentSelectedProduct.ImagePath);
            _productNameAndDescription.Text = currentSelectedProduct.GetProductNameAndDescription();
        }

        /// <summary>
        /// Get the current selected product.
        /// </summary>
        private Product GetCurrentSelectedProduct()
        {
            return _model.GetProductAt(_storageDataGridView.CurrentRow.Index);
        }

        /// <summary>
        /// Initialize storage data grid view.
        /// </summary>
        private void InitializeStorageDataGridView()
        {
            foreach ( Product product in _model.Products )
            {
                _storageDataGridView.Rows.Add(product.Name, product.Type, product.Price.GetCurrencyFormat(), product.StorageQuantity, null);
            }
        }
    }
}
