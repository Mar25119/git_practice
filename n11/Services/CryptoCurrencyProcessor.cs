using PaymentSystem.Interfaces;

namespace PaymentSystem.Processors
{
    public class CryptoCurrencyProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Crypto payment of {amount:C}");
            return true;
        }

        public bool RefundPayment(decimal amount)
        {
            Console.WriteLine($"Refunding Crypto payment of {amount:C}");
            return true;
        }
    }
}