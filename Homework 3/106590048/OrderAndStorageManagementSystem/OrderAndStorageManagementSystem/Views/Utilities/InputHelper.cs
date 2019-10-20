using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views.Utilities
{
    public static class InputHelper
    {
        /// <summary>
        /// Constrain a textbox to solely input letters, white space, or back space.
        /// </summary>
        public static void InputLettersOrWhiteSpaceOrBackSpace(object sender, KeyPressEventArgs eventArguments)
        {
            eventArguments.Handled = !char.IsLetter(eventArguments.KeyChar) && !char.IsWhiteSpace(eventArguments.KeyChar) && !IsBackSpace(eventArguments.KeyChar);
        }

        /// <summary>
        /// Constrain a textbox to solely input numbers or back space.
        /// </summary>
        public static void InputNumbersOrBackSpace(object sender, KeyPressEventArgs eventArguments)
        {
            eventArguments.Handled = !char.IsDigit(eventArguments.KeyChar) && !IsBackSpace(eventArguments.KeyChar);
        }

        /// <summary>
        /// Return true if the key is back space.
        /// </summary>
        private static bool IsBackSpace(char key)
        {
            return key == ( char )Keys.Back;
        }
    }
}
