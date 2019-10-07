namespace OrderAndStorageManagementSystem.ModelNamespace.CreditCardPaymentNamespace
{
    public abstract class InputInspector
    {
        // Protest on Dr.Smell
        public abstract bool IsValid();

        // Protest on Dr.Smell
        public abstract string GetError();
    }
}
