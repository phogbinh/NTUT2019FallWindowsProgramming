using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views.Utilities
{
    public static class InputHelper
    {
        // Protest on Dr.Smell
        public static void InputLettersOrWhiteSpaceOrBackSpace(object sender, KeyPressEventArgs eventArguments)
        {
            eventArguments.Handled = !char.IsLetter(eventArguments.KeyChar) && !char.IsWhiteSpace(eventArguments.KeyChar) && !IsBackSpace(eventArguments.KeyChar);
        }

        // Protest on Dr.Smell
        public static void InputNumbersOrBackSpace(object sender, KeyPressEventArgs eventArguments)
        {
            eventArguments.Handled = !char.IsDigit(eventArguments.KeyChar) && !IsBackSpace(eventArguments.KeyChar);
        }

        // Protest on Dr.Smell
        private static bool IsBackSpace(char key)
        {
            return key == ( char )Keys.Back;
        }
    }
}
