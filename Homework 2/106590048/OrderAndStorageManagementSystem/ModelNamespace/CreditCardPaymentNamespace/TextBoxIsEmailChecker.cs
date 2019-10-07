using System.Net.Mail;

namespace OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace
{
    public class TextBoxIsEmailChecker : TextBoxChecker
    {
        private const string ERROR_TEXT_BOX_IS_NOT_EMAIL = "This field is not an email.";

        public TextBoxIsEmailChecker() : base()
        {
            /* Body intentionally empty */
        }

        // Protest on Dr.Smell
        public override bool IsValid()
        {
            try
            {
                var email = new MailAddress(_text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Protest on Dr.Smell
        public override string GetError()
        {
            return ERROR_TEXT_BOX_IS_NOT_EMAIL;
        }
    }
}
