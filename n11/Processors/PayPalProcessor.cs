using PaymentSystem.Interfaces;

namespace PaymentSystem.Processors
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
            return true;
        }

        public bool RefundPayment(decimal amount)
        {
            Console.WriteLine($"Refunding PayPal payment of {amount:C}");
            return true;
        }
    }
}