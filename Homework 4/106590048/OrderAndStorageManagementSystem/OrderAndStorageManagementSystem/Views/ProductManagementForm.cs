using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Views.Utilities;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class ProductManagementForm : Form
    {
        private ProductManagementPresentationModel _productManagementPresentationModel;
        private Model _model;

        public ProductManagementForm(ProductManagementPresentationModel productManagementPresentationModelData, Model modelData)
        {
            InitializeComponent();
            _productManagementPresentationModel = productManagementPresentationModelData;
            _model = modelData;
            // Initial UI States
            InitializeProductTypeField();
            InitializeProductsListBox();
        }

        /// <summary>
        /// Initialize _productTypeField.
        /// </summary>
        private void InitializeProductTypeField()
        {
            foreach ( string productType in _model.GetProductTypes() )
            {
                _productTypeField.Items.Add(productType);
            }
        }

        /// <summary>
        /// Initialize _productsListBox.
        /// </summary>
        private void InitializeProductsListBox()
        {
            foreach ( Product product in _model.Products )
            {
                _productsListBox.Items.Add(new ProductsListBoxItem(product));
            }
        }
    }
}
