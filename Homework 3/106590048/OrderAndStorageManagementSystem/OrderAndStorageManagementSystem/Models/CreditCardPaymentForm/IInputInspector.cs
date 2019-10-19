namespace OrderAndStorageManagementSystem.Models.CreditCardPaymentForm
{
    public interface IInputInspector
    {
        // Protest on Dr.Smell
        bool IsValid();

        // Protest on Dr.Smell
        string GetError();
    }
}
