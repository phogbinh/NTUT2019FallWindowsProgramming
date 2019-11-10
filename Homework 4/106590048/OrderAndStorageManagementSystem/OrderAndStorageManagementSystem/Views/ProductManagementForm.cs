using InputInspectingElements;
using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
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
            this.Disposed += RemoveEvents;
            // Observers
            _productManagementPresentationModel.CurrentSelectedProductChanged += UpdateProductInfoView;
            _productManagementPresentationModel.SaveButtonEnabledChanged += UpdateSaveButtonView;
            // UI
            _productsListBox.SelectedIndexChanged += (sender, eventArguments) => _productManagementPresentationModel.SetCurrentSelectedProduct(( ( ProductsListBoxItem )_productsListBox.SelectedItem ).Product);
            _productNameField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _productNameField.TextBoxInspectorsCollectionChanged += () => UpdateErrorProviderView(_productNameField, _productNameField.GetInputInspectorsError());
            _productPriceField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _productImageBrowseButton.Click += (sender, eventArguments) => BrowseImageAndSetProductImagePath();
            // Initial UI States
            InitializeProductTypeField();
            InitializeProductsListBox();
            UpdateSaveButtonView();
        }

        /// <summary>
        /// Unsubscribe from all events that were subscribed by this form.
        /// </summary>
        private void RemoveEvents(object sender, EventArgs eventArguments)
        {
            _productManagementPresentationModel.CurrentSelectedProductChanged -= UpdateProductInfoView;
            _productManagementPresentationModel.SaveButtonEnabledChanged -= UpdateSaveButtonView;
        }

        /// <summary>
        /// Update product info view.
        /// </summary>
        private void UpdateProductInfoView()
        {
            _productNameField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Name;
            _productPriceField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Price.GetString();
            _productTypeField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Type;
            _productImagePathField.Text = _productManagementPresentationModel.CurrentSelectedProduct.ImagePath;
            _productDescriptionField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Description;
        }

        /// <summary>
        /// Update save button view.
        /// </summary>
        private void UpdateSaveButtonView()
        {
            _saveButton.Enabled = _productManagementPresentationModel.SaveButton.Enabled;
        }

        /// <summary>
        /// Update the view of the error provider.
        /// </summary>
        private void UpdateErrorProviderView(Control control, string controlInputInspectorsError)
        {
            _errorProvider.SetError(control, controlInputInspectorsError);
        }

        /// <summary>
        /// Browse for image and set _productImagePathField.
        /// </summary>
        private void BrowseImageAndSetProductImagePath()
        {
            var dialog = new OpenFileDialog();
            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                _productImagePathField.Text = dialog.FileName;
            }
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
