﻿using InputInspectingElements;
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
            // UI
            _productsListBox.SelectedIndexChanged += (sender, eventArguments) => UpdateProductInfoView();
            _productNameField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _productNameField.TextBoxInspectorsCollectionChanged += () => UpdateErrorProviderView(_productNameField, _productNameField.GetInputInspectorsError());
            _productPriceField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            // Initial UI States
            InitializeProductTypeField();
            InitializeProductsListBox();
            RefreshControls();
        }

        /// <summary>
        /// Update product info view.
        /// </summary>
        private void UpdateProductInfoView()
        {
            Product currentSelectedProduct = ( ( ProductsListBoxItem )_productsListBox.SelectedItem ).Product;
            _productNameField.Text = currentSelectedProduct.Name;
            _productPriceField.Text = currentSelectedProduct.Price.GetString();
            _productTypeField.Text = currentSelectedProduct.Type;
            _productImagePathField.Text = currentSelectedProduct.ImagePath;
            _productDescriptionField.Text = currentSelectedProduct.Description;
            RefreshControls();
        }

        /// <summary>
        /// Update the view of the error provider.
        /// </summary>
        private void UpdateErrorProviderView(Control control, string controlInputInspectorsError)
        {
            _errorProvider.SetError(control, controlInputInspectorsError);
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

        /// <summary>
        /// Refresh controls.
        /// </summary>
        private void RefreshControls()
        {
            _saveButton.Enabled = _productsListBox.SelectedIndex >= 0;
        }
    }
}
