using InputInspectingElements;
using InputInspectingElements.InputInspectingControls;
using InputInspectingElements.InputInspectorsCollections;
using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystem.PresentationModels;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class ProductManagementForm : Form
    {
        private const string ERROR_NULL_CURRENT_SELECTED_PRODUCT = "The current selected product is null.";
        private ProductManagementPresentationModel _productManagementPresentationModel;
        private Model _model;
        private List<InputInspectingTextBox> _textBoxes;
        private List<InputInspectingDropDownList> _dropDownLists;
        private InputInspectorsCollection _inputInspectorsCollection;

        public ProductManagementForm(ProductManagementPresentationModel productManagementPresentationModelData, Model modelData)
        {
            InitializeComponent();
            _productManagementPresentationModel = productManagementPresentationModelData;
            _model = modelData;
            this.Disposed += RemoveEvents;
            // Observers
            _model.ProductInfoChanged += ResetViewOnProductInfoChanged;
            _productManagementPresentationModel.CurrentSelectedProductChanged += UpdateProductInfoViewAndSetIsEditedProductInfo;
            _productManagementPresentationModel.SaveButtonEnabledChanged += UpdateSaveButtonView;
            // UI
            _productsListBox.SelectedIndexChanged += (sender, eventArguments) => _productManagementPresentationModel.SetCurrentSelectedProduct(( ( ProductsListBoxItem )_productsListBox.SelectedItem ).Product);
            _productPriceField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _productImageBrowseButton.Click += (sender, eventArguments) => BrowseImageAndSetProductImagePath();
            _saveButton.Click += (sender, eventArguments) => UpdateCurrentSelectedProductInfoAndSetIsEditedProductInfo();
            // Product info
            _productNameField.TextChanged += (sender, eventArguments) => _productManagementPresentationModel.SetIsEditedProductInfo(true);
            _productPriceField.TextChanged += (sender, eventArguments) => _productManagementPresentationModel.SetIsEditedProductInfo(true);
            _productTypeField.TextChanged += (sender, eventArguments) => _productManagementPresentationModel.SetIsEditedProductInfo(true);
            _productImagePathField.TextChanged += (sender, eventArguments) => _productManagementPresentationModel.SetIsEditedProductInfo(true);
            _productDescriptionField.TextChanged += (sender, eventArguments) => _productManagementPresentationModel.SetIsEditedProductInfo(true);
            // Input inspecting textboxes
            InitializeInputInspectingTextBoxesTextBoxInspectors();
            InitializeInputInspectingTextBoxes();
            InitializeInputInspectingTextBoxesTextBoxInspectorsCollectionChangedEventHandlers();
            // Input inspecting drop-down lists
            InitializeInputInspectingDropDownListsDropDownListInspectors();
            InitializeInputInspectingDropDownLists();
            InitializeInputInspectingDropDownListsDropDownListInspectorsCollectionChangedEventHandlers();
            // Input inspectors collection
            InitializeInputInspectorsCollection();
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
            _model.ProductInfoChanged -= ResetViewOnProductInfoChanged;
            _productManagementPresentationModel.CurrentSelectedProductChanged -= UpdateProductInfoViewAndSetIsEditedProductInfo;
            _productManagementPresentationModel.SaveButtonEnabledChanged -= UpdateSaveButtonView;
        }

        /// <summary>
        /// Reset view on product info changed.
        /// </summary>
        private void ResetViewOnProductInfoChanged(Product product)
        {
            ResetProductsListBoxView();
            ResetProductInfoAndErrorProviderView();
        }

        /// <summary>
        /// Reset products list box view.
        /// </summary>
        private void ResetProductsListBoxView()
        {
            _productsListBox.Items.Clear();
            InitializeProductsListBox();
        }

        /// <summary>
        /// Reset product info and error provider view.
        /// </summary>
        private void ResetProductInfoAndErrorProviderView()
        {
            _productNameField.Text = "";
            _productPriceField.Text = "";
            _productTypeField.SelectedIndex = -1;
            _productImagePathField.Text = "";
            _productDescriptionField.Text = "";
            _errorProvider.Clear();
        }

        /// <summary>
        /// Update product info view and set _isEditedProductInfo in the presentation model.
        /// </summary>
        private void UpdateProductInfoViewAndSetIsEditedProductInfo()
        {
            if ( _productManagementPresentationModel.CurrentSelectedProduct == null )
            {
                throw new ArgumentException(ERROR_NULL_CURRENT_SELECTED_PRODUCT);
            }
            _productNameField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Name;
            _productPriceField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Price.GetString();
            _productTypeField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Type;
            _productImagePathField.Text = _productManagementPresentationModel.CurrentSelectedProduct.ImagePath;
            _productDescriptionField.Text = _productManagementPresentationModel.CurrentSelectedProduct.Description;
            _productManagementPresentationModel.SetIsEditedProductInfo(false);
        }

        /// <summary>
        /// Update save button view.
        /// </summary>
        private void UpdateSaveButtonView()
        {
            _saveButton.Enabled = _productManagementPresentationModel.SaveButton.Enabled;
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
        /// Update current selected product info and set _isEditedProductInfo in the presentation model.
        /// </summary>
        private void UpdateCurrentSelectedProductInfoAndSetIsEditedProductInfo()
        {
            _productManagementPresentationModel.UpdateCurrentSelectedProductInfo(new Product(_productNameField.Text, _productTypeField.Text, _productPriceField.Text, _productDescriptionField.Text, _productImagePathField.Text));
            _productManagementPresentationModel.SetIsEditedProductInfo(false);
        }

        /// <summary>
        /// Initialize textbox inspectors for input inspecting textboxes.
        /// </summary>
        private void InitializeInputInspectingTextBoxesTextBoxInspectors()
        {
            _productNameField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _productPriceField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _productImagePathField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
        }

        /// <summary>
        /// Initialize the input inspecting textboxes _textBoxes.
        /// </summary>
        private void InitializeInputInspectingTextBoxes()
        {
            _textBoxes = new List<InputInspectingTextBox>();
            _textBoxes.Add(_productNameField);
            _textBoxes.Add(_productPriceField);
            _textBoxes.Add(_productImagePathField);
        }

        /// <summary>
        /// Initialize the handlers for the event TextBoxInspectorsCollectionChanged of input inspecting textboxes.
        /// </summary>
        private void InitializeInputInspectingTextBoxesTextBoxInspectorsCollectionChangedEventHandlers()
        {
            foreach ( InputInspectingTextBox textBox in _textBoxes )
            {
                textBox.TextBoxInspectorsCollectionChanged += () => UpdateErrorProviderViewAndIsValidProductInfo(textBox, textBox.GetInputInspectorsError());
            }
        }

        /// <summary>
        /// Update the view of the error provider and the member variable _isValidProductInfo inside the presentation model.
        /// </summary>
        private void UpdateErrorProviderViewAndIsValidProductInfo(Control control, string controlInputInspectorsError)
        {
            _errorProvider.SetError(control, controlInputInspectorsError);
            _productManagementPresentationModel.SetIsValidProductInfo(_inputInspectorsCollection.AreAllValidInputInspectors());
        }

        /// <summary>
        /// Initialize drop-down list inspectors for input inspecting drop-down lists.
        /// </summary>
        private void InitializeInputInspectingDropDownListsDropDownListInspectors()
        {
            _productTypeField.AddDropDownListInspectors(InputInspectorTypeHelper.FLAG_DROP_DOWN_LIST_IS_SELECTED);
        }

        /// <summary>
        /// Initialize the input inspecting drop-down lists _dropDownLists.
        /// </summary>
        private void InitializeInputInspectingDropDownLists()
        {
            _dropDownLists = new List<InputInspectingDropDownList>();
            _dropDownLists.Add(_productTypeField);
        }

        /// <summary>
        /// Initialize the handlers for the event DropDownListInspectorsCollectionChanged of input inspecting drop-down lists.
        /// </summary>
        private void InitializeInputInspectingDropDownListsDropDownListInspectorsCollectionChangedEventHandlers()
        {
            foreach ( InputInspectingDropDownList dropDownList in _dropDownLists )
            {
                dropDownList.DropDownListInspectorsCollectionChanged += () => UpdateErrorProviderViewAndIsValidProductInfo(dropDownList, dropDownList.GetInputInspectorsError());
            }
        }

        /// <summary>
        /// Initialize the input inspectors collection.
        /// </summary>
        private void InitializeInputInspectorsCollection()
        {
            _inputInspectorsCollection = new InputInspectorsCollection();
            foreach ( InputInspectingTextBox textBox in _textBoxes )
            {
                _inputInspectorsCollection.AddInputInspectorsList(textBox.GetInputInspectors());
            }
            foreach ( InputInspectingDropDownList dropDownList in _dropDownLists )
            {
                _inputInspectorsCollection.AddInputInspectorsList(dropDownList.GetInputInspectors());
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
