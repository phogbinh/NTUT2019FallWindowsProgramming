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
        private const string PRODUCT_INFO_GROUP_BOX_TEXT_EDIT_PRODUCT = "編輯商品";
        private const string PRODUCT_INFO_GROUP_BOX_TEXT_ADD_PRODUCT = "新增商品";
        private const string PRODUCT_TYPE_INFO_GROUP_BOX_TEXT_VIEW_PRODUCT_TYPE = "類別";
        private const string PRODUCT_TYPE_INFO_GROUP_BOX_TEXT_ADD_PRODUCT_TYPE = "新增類別";
        private const string SAVE_BUTTON_TEXT_SAVE_PRODUCT = "儲存";
        private const string SAVE_BUTTON_TEXT_ADD_PRODUCT = "新增";
        private ProductsManagementTabPagePresentationModel _productsManagementTabPagePresentationModel;
        private ProductTypesManagementTabPagePresentationModel _productTypesManagementTabPagePresentationModel;
        private Model _model;
        private List<InputInspectingTextBox> _textBoxes;
        private List<InputInspectingDropDownList> _dropDownLists;
        private InputInspectorsCollection _inputInspectorsCollection;

        public ProductManagementForm(ProductsManagementTabPagePresentationModel productsManagementTabPagePresentationModelData, ProductTypesManagementTabPagePresentationModel productTypesManagementTabPagePresentationModelData, Model modelData)
        {
            InitializeComponent();
            _productsManagementTabPagePresentationModel = productsManagementTabPagePresentationModelData;
            _productTypesManagementTabPagePresentationModel = productTypesManagementTabPagePresentationModelData;
            _model = modelData;
            this.Disposed += RemoveEvents;
            // Observers
            _model.ProductInfoChanged += ResetViewOnProductInfoChangedOrOnProductAdded;
            _model.ProductAdded += ResetViewOnProductInfoChangedOrOnProductAdded;
            _model.ProductTypeAdded += ResetViewOnProductTypeAdded;
            _productsManagementTabPagePresentationModel.CurrentSelectedProductChanged += UpdateProductInfoViewAndSetIsEditedProductInfo;
            _productsManagementTabPagePresentationModel.SubmitProductInfoButtonEnabledChanged += UpdateSaveButtonView;
            _productTypesManagementTabPagePresentationModel.CurrentSelectedProductTypeChanged += UpdateProductTypeInfoView;
            _productTypesManagementTabPagePresentationModel.SubmitProductTypeInfoButtonEnabledChanged += UpdateProductTypeInfoButtonView;
            // UI
            _productsListBox.SelectedIndexChanged += ChangeProductsListBoxSelectedIndex;
            _productTypesListBox.SelectedIndexChanged += ChangeProductTypesListBoxSelectedIndex;
            _productPriceField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _productImageBrowseButton.Click += (sender, eventArguments) => BrowseImageAndSetProductImagePath();
            _submitProductInfoButton.Click += (sender, eventArguments) => _productsManagementTabPagePresentationModel.ClickSubmitProductInfoButton(new ProductInfo(_productNameField.Text, _productTypeField.Text, new Money(int.Parse(_productPriceField.Text)), _productDescriptionField.Text, _productImagePathField.Text));
            _submitProductTypeInfoButton.Click += (sender, eventArguments) => _productTypesManagementTabPagePresentationModel.ClickSubmitProductTypeInfoButton(_productTypeNameField.Text);
            _addProductButton.Click += (sender, eventArguments) => SetStateAndUpdateViewOnAddProductButtonClicked();
            _addProductTypeButton.Click += (sender, eventArguments) => SetProductTypesManagementTabPageStateAndUpdateViewOnAddProductTypeButtonClicked();
            // Product info
            _productNameField.TextChanged += (sender, eventArguments) => _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(true);
            _productPriceField.TextChanged += (sender, eventArguments) => _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(true);
            _productTypeField.TextChanged += (sender, eventArguments) => _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(true);
            _productImagePathField.TextChanged += (sender, eventArguments) => _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(true);
            _productDescriptionField.TextChanged += (sender, eventArguments) => _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(true);
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
            InitializeProductTypesListBox();
            _productsManagementTabPagePresentationModel.SetCurrentSelectedProductAndNotifyObserver(null);
            _productsManagementTabPagePresentationModel.SetIsValidProductInfoAndNotifyObserver(false);
            _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(false);
            _productsManagementTabPagePresentationModel.SetProductsManagementTabPageStateAndNotifyObserver(ProductsManagementTabPageState.EditProduct);
            _productTypesManagementTabPagePresentationModel.SetCurrentSelectedProductTypeAndNotifyObserver(null);
            _productTypesManagementTabPagePresentationModel.SetProductTypesManagementTabPageStateAndNotifyObserver(ProductTypesManagementTabPageState.ViewProductType);
        }

        /// <summary>
        /// Unsubscribe from all events that were subscribed by this form.
        /// </summary>
        private void RemoveEvents(object sender, EventArgs eventArguments)
        {
            _model.ProductInfoChanged -= ResetViewOnProductInfoChangedOrOnProductAdded;
            _model.ProductAdded -= ResetViewOnProductInfoChangedOrOnProductAdded;
            _model.ProductTypeAdded -= ResetViewOnProductTypeAdded;
            _productsManagementTabPagePresentationModel.CurrentSelectedProductChanged -= UpdateProductInfoViewAndSetIsEditedProductInfo;
            _productsManagementTabPagePresentationModel.SubmitProductInfoButtonEnabledChanged -= UpdateSaveButtonView;
            _productTypesManagementTabPagePresentationModel.CurrentSelectedProductTypeChanged -= UpdateProductTypeInfoView;
            _productTypesManagementTabPagePresentationModel.SubmitProductTypeInfoButtonEnabledChanged -= UpdateProductTypeInfoButtonView;
        }

        /// <summary>
        /// Reset view on product info changed.
        /// </summary>
        private void ResetViewOnProductInfoChangedOrOnProductAdded(Product product)
        {
            ResetProductTypeFieldView();
            ResetProductsListBoxView();
            ResetProductTypesListBoxView();
            ResetProductInfoAndErrorProviderView();
            ResetProductTypeInfoAndErrorProviderView();
        }

        /// <summary>
        /// Resets the product type field view.
        /// </summary>
        private void ResetProductTypeFieldView()
        {
            _productTypeField.Items.Clear();
            InitializeProductTypeField();
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
        /// Resets the product types ListBox view.
        /// </summary>
        private void ResetProductTypesListBoxView()
        {
            _productTypesListBox.Items.Clear();
            InitializeProductTypesListBox();
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
        /// Resets the product type information and error provider view.
        /// </summary>
        private void ResetProductTypeInfoAndErrorProviderView()
        {
            _productTypeNameField.Text = "";
            _productTypeProductsListBox.Items.Clear();
            _errorProvider.Clear();
        }

        /// <summary>
        /// Resets the view on product type added.
        /// </summary>
        private void ResetViewOnProductTypeAdded(string productType)
        {
            ResetProductTypeFieldView();
            ResetProductsListBoxView();
            ResetProductTypesListBoxView();
            ResetProductInfoAndErrorProviderView();
            ResetProductTypeInfoAndErrorProviderView();
        }

        /// <summary>
        /// Update product info view and set _isEditedProductInfo in the presentation model.
        /// </summary>
        private void UpdateProductInfoViewAndSetIsEditedProductInfo()
        {
            _productNameField.Text = _productsManagementTabPagePresentationModel.GetCurrentSelectedProductName();
            _productPriceField.Text = _productsManagementTabPagePresentationModel.GetCurrentSelectedProductPrice();
            _productTypeField.Text = _productsManagementTabPagePresentationModel.GetCurrentSelectedProductType();
            _productImagePathField.Text = _productsManagementTabPagePresentationModel.GetCurrentSelectedProductImagePath();
            _productDescriptionField.Text = _productsManagementTabPagePresentationModel.GetCurrentSelectedProductDescription();
            _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(false);
        }

        /// <summary>
        /// Update save button view.
        /// </summary>
        private void UpdateSaveButtonView()
        {
            _submitProductInfoButton.Enabled = _productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled();
        }

        /// <summary>
        /// Updates the product type information view.
        /// </summary>
        private void UpdateProductTypeInfoView()
        {
            _productTypeNameField.Text = _productTypesManagementTabPagePresentationModel.GetCurrentSelectedProductTypeName();
            _productTypeProductsListBox.Items.Clear();
            _productTypeProductsListBox.Items.AddRange(_productTypesManagementTabPagePresentationModel.GetCurrentSelectedProductTypeProducts().ToArray());
        }

        /// <summary>
        /// Updates the product type information button view.
        /// </summary>
        private void UpdateProductTypeInfoButtonView()
        {
            _submitProductTypeInfoButton.Enabled = _productTypesManagementTabPagePresentationModel.IsSubmitProductTypeInfoButtonEnabled();
        }

        /// <summary>
        /// Change _productsListBox.SelectedIndex.
        /// </summary>
        private void ChangeProductsListBoxSelectedIndex(object sender, EventArgs eventArguments)
        {
            _productsManagementTabPagePresentationModel.SetProductsManagementTabPageStateAndNotifyObserver(ProductsManagementTabPageState.EditProduct);
            _productsManagementTabPagePresentationModel.SetCurrentSelectedProductAndNotifyObserver(( ( ProductsListBoxItem )_productsListBox.SelectedItem ).Product);
            UpdateViewOnProductsListBoxSelectedIndexChanged();
        }

        /// <summary>
        /// Update view on _productsListBox.SelectedIndexChanged.
        /// </summary>
        private void UpdateViewOnProductsListBoxSelectedIndexChanged()
        {
            _addProductButton.Enabled = true;
            _productInfoGroupBox.Text = PRODUCT_INFO_GROUP_BOX_TEXT_EDIT_PRODUCT;
            _submitProductInfoButton.Text = SAVE_BUTTON_TEXT_SAVE_PRODUCT;
        }

        /// <summary>
        /// Changes the index of the product types ListBox selected.
        /// </summary>
        private void ChangeProductTypesListBoxSelectedIndex(object sender, EventArgs eventArguments)
        {
            _productTypesManagementTabPagePresentationModel.SetProductTypesManagementTabPageStateAndNotifyObserver(ProductTypesManagementTabPageState.ViewProductType);
            _productTypesManagementTabPagePresentationModel.SetCurrentSelectedProductTypeAndNotifyObserver(( string )_productTypesListBox.SelectedItem);
            UpdateViewOnProductTypesListBoxSelectedIndexChanged();
        }

        /// <summary>
        /// Updates the view on product types ListBox selected index changed.
        /// </summary>
        private void UpdateViewOnProductTypesListBoxSelectedIndexChanged()
        {
            _addProductTypeButton.Enabled = true;
            _productTypeInfoGroupBox.Text = PRODUCT_TYPE_INFO_GROUP_BOX_TEXT_VIEW_PRODUCT_TYPE;
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
        /// Set state and update view on add product button clicked.
        /// </summary>
        private void SetStateAndUpdateViewOnAddProductButtonClicked()
        {
            _productsManagementTabPagePresentationModel.SetProductsManagementTabPageStateAndNotifyObserver(ProductsManagementTabPageState.AddProduct);
            UpdateViewOnAddProductButtonClicked();
        }

        /// <summary>
        /// Update view on add product button clicked.
        /// </summary>
        private void UpdateViewOnAddProductButtonClicked()
        {
            _addProductButton.Enabled = false;
            _productInfoGroupBox.Text = PRODUCT_INFO_GROUP_BOX_TEXT_ADD_PRODUCT;
            _submitProductInfoButton.Text = SAVE_BUTTON_TEXT_ADD_PRODUCT;
            ResetProductInfoAndErrorProviderView();
        }

        /// <summary>
        /// Sets the product types management tab page state and update view on add product type button clicked.
        /// </summary>
        private void SetProductTypesManagementTabPageStateAndUpdateViewOnAddProductTypeButtonClicked()
        {
            _productTypesManagementTabPagePresentationModel.SetProductTypesManagementTabPageStateAndNotifyObserver(ProductTypesManagementTabPageState.AddProductType);
            UpdateViewOnAddProductTypeButtonClicked();
        }

        /// <summary>
        /// Updates the view on add product type button clicked.
        /// </summary>
        private void UpdateViewOnAddProductTypeButtonClicked()
        {
            _addProductTypeButton.Enabled = false;
            _productTypeInfoGroupBox.Text = PRODUCT_TYPE_INFO_GROUP_BOX_TEXT_ADD_PRODUCT_TYPE;
            ResetProductTypeInfoAndErrorProviderView();
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
            _productsManagementTabPagePresentationModel.SetIsValidProductInfoAndNotifyObserver(_inputInspectorsCollection.AreAllValidInputInspectors());
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

        /// <summary>
        /// Initializes the product types ListBox.
        /// </summary>
        private void InitializeProductTypesListBox()
        {
            foreach ( string productType in _model.ProductTypes )
            {
                _productTypesListBox.Items.Add(productType);
            }
        }
    }
}
