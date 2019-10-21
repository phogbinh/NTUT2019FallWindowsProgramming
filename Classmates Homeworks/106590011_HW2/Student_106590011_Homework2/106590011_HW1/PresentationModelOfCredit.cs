using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_System
{
    public class PresentationModelOfCreditCardSystem
    {
        public const string NAME1 = "_name1";
        public const string NAME2 = "_name2";
        public const string CREDIT1 = "_credit1";
        public const string CREDIT2 = "_credit2";
        public const string CREDIT3 = "_credit3";
        public const string CREDIT4 = "_credit4";
        public const string MONTH = "_month";
        public const string YEAR = "_year";
        public const string PASSWORD = "_password";
        public const string MAIL = "_mail";
        public const string ADDRESS = "_address";
        // Set error and determine weather the object is going to set error
        public void SetErrorToObject(ref ErrorProvider errorProvider, Object sender, Object compare, bool statement)
        {
            const string ERROR_STRING = "Error";
            const string EMPTY_STRING = "";
            if (sender == compare as Object)
            {
                if (statement)
                    SetError(errorProvider, sender as Control, EMPTY_STRING);
                else
                    SetError(errorProvider, sender as Control, ERROR_STRING);
            }
        }

        // Set error to _errorProvider
        private void SetError(ErrorProvider errorProvider, Control sender, string message)
        {
            errorProvider.SetError(sender, message);
        }

        // Check if exist any errors
        public bool CheckErrorProvider(ref ErrorProvider errorProvider)
        {
            foreach (Control c in errorProvider.ContainerControl.Controls)
                if (errorProvider.GetError(c) != "")
                    return false;
            return true;
        }

        // Retain input only numbers
        public void PressKeyTextBoxOnlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        // Retain input only alphabetic
        public void PressKeyTextBoxOnlyAlphabet(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
