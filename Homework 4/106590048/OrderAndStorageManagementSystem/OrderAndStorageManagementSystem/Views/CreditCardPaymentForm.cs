using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.PresentationModels;
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

        public CreditCardPaymentForm(Model modelData)
        {
            InitializeComponent();
            _model = modelData;
            // UI
            this.FormClosed += (sender, eventArguments) => _cardSecurityCodeField.Text = AppDefinition.EMPTY_STRING;
            _submitButton.Click += ClickSubmitButton;
            InitializeInputLimits();
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
    }
}
