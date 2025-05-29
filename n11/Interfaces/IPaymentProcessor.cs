namespace PaymentSystem.Interfaces
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
        bool RefundPayment(decimal amount);
    }
}