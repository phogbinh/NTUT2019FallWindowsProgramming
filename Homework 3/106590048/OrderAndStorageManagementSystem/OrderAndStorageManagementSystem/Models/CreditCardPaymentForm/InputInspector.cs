namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public abstract class InputInspector
    {
        // Protest on Dr.Smell
        public abstract bool IsValid();

        // Protest on Dr.Smell
        public abstract string GetError();
    }
}
