using InputInspectingElements;
using InputInspectingElements.InputInspectingControls;
using InputInspectingElements.InputInspectorsCollections;
using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Views.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public partial class CreditCardPaymentForm : Form
    {
        private const string ORDER_COMPLETE_TITLE = "訂購狀態";
        private const string ORDER_COMPLETE_MESSAGE = "訂購完成";
        private Model _model;
        private List<InputInspectingTextBox> _textBoxes;
        private List<InputInspectingDropDownList> _dropDownLists;
        private InputInspectorsCollection _inputInspectorsCollection;

        public CreditCardPaymentForm(Model modelData)
        {
            InitializeComponent();
            _model = modelData;
            // UI
            this.FormClosed += (sender, eventArguments) => _cardSecurityCodeField.Text = AppDefinition.EMPTY_STRING;
            _submitButton.Click += ClickSubmitButton;
            InitializeInputLimits();
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
        }

        /// <summary>
        /// Click submit button.
        /// </summary>
        private void ClickSubmitButton(object sender, EventArgs eventArguments)
        {
            if ( MessageBox.Show(this, ORDER_COMPLETE_MESSAGE, ORDER_COMPLETE_TITLE) == DialogResult.OK )
            {
                _model.SubmitOrder();
                this.Close();
            }
        }

        /// <summary>
        /// Initialize input limits.
        /// </summary>
        private void InitializeInputLimits()
        {
            _lastNameField.KeyPress += InputHelper.InputLettersOrWhiteSpaceOrBackSpace;
            _firstNameField.KeyPress += InputHelper.InputLettersOrWhiteSpaceOrBackSpace;
            _cardNumberFirstField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardNumberSecondField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardNumberThirdField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardNumberFourthField.KeyPress += InputHelper.InputNumbersOrBackSpace;
            _cardSecurityCodeField.KeyPress += InputHelper.InputNumbersOrBackSpace;
        }

        /// <summary>
        /// Initialize textbox inspectors for input inspecting textboxes.
        /// </summary>
        private void InitializeInputInspectingTextBoxesTextBoxInspectors()
        {
            _lastNameField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _firstNameField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
            _cardNumberFirstField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY | InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_OF_FULL_LENGTH);
            _cardNumberSecondField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY | InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_OF_FULL_LENGTH);
            _cardNumberThirdField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY | InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_OF_FULL_LENGTH);
            _cardNumberFourthField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY | InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_OF_FULL_LENGTH);
            _cardSecurityCodeField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY | InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_OF_FULL_LENGTH);
            _mailField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY | InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_MAIL);
            _addressField.AddTextBoxInspectors(InputInspectorTypeHelper.FLAG_TEXT_BOX_IS_NOT_EMPTY);
        }

        /// <summary>
        /// Initialize the input inspecting textboxes _textBoxes.
        /// </summary>
        private void InitializeInputInspectingTextBoxes()
        {
            _textBoxes = new List<InputInspectingTextBox>();
            _textBoxes.Add(_lastNameField);
            _textBoxes.Add(_firstNameField);
            _textBoxes.Add(_cardNumberFirstField);
            _textBoxes.Add(_cardNumberSecondField);
            _textBoxes.Add(_cardNumberThirdField);
            _textBoxes.Add(_cardNumberFourthField);
            _textBoxes.Add(_cardSecurityCodeField);
            _textBoxes.Add(_mailField);
            _textBoxes.Add(_addressField);
        }

        /// <summary>
        /// Initialize the handlers for the event TextBoxInspectorsCollectionChanged of input inspecting textboxes.
        /// </summary>
        private void InitializeInputInspectingTextBoxesTextBoxInspectorsCollectionChangedEventHandlers()
        {
            foreach ( InputInspectingTextBox textBox in _textBoxes )
            {
                textBox.TextBoxInspectorsCollectionChanged += () => UpdateErrorProviderAndSubmitButtonView(textBox, textBox.GetInputInspectorsError());
            }
        }

        /// <summary>
        /// Update the view of the error provider and the submit button.
        /// </summary>
        private void UpdateErrorProviderAndSubmitButtonView(Control control, string controlInputInspectorsError)
        {
            _errorProvider.SetError(control, controlInputInspectorsError);
            _submitButton.Enabled = _inputInspectorsCollection.AreAllValidInputInspectors();
        }

        /// <summary>
        /// Initialize drop-down list inspectors for input inspecting drop-down lists.
        /// </summary>
        private void InitializeInputInspectingDropDownListsDropDownListInspectors()
        {
            _cardDateMonthField.AddDropDownListInspectors(InputInspectorTypeHelper.FLAG_DROP_DOWN_LIST_IS_SELECTED);
            _cardDateYearField.AddDropDownListInspectors(InputInspectorTypeHelper.FLAG_DROP_DOWN_LIST_IS_SELECTED);
        }

        /// <summary>
        /// Initialize the input inspecting drop-down lists _dropDownLists.
        /// </summary>
        private void InitializeInputInspectingDropDownLists()
        {
            _dropDownLists = new List<InputInspectingDropDownList>();
            _dropDownLists.Add(_cardDateMonthField);
            _dropDownLists.Add(_cardDateYearField);
        }

        /// <summary>
        /// Initialize the handlers for the event DropDownListInspectorsCollectionChanged of input inspecting drop-down lists.
        /// </summary>
        private void InitializeInputInspectingDropDownListsDropDownListInspectorsCollectionChangedEventHandlers()
        {
            foreach ( InputInspectingDropDownList dropDownList in _dropDownLists )
            {
                dropDownList.DropDownListInspectorsCollectionChanged += () => UpdateErrorProviderAndSubmitButtonView(dropDownList, dropDownList.GetInputInspectorsError());
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
    }
}
