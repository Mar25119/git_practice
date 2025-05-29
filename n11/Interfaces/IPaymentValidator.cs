namespace PaymentSystem.Interfaces
{
    public interface IPaymentValidator
    {
        bool ValidatePayment(decimal amount);
    }
}