using System.Net.Mail;

namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public class TextBoxIsMailInspector : TextBoxInspector
    {
        private const string ERROR_TEXT_BOX_IS_NOT_MAIL = "This field is not an email.";

        public TextBoxIsMailInspector() : base()
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
            return ERROR_TEXT_BOX_IS_NOT_MAIL;
        }
    }
}
