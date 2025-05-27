using System;

namespace PaymentSystem
{
    public interface IPaymentProcessor
    {
        void ProcessPayment();
        void RefundPayment();
    }

    public interface IPaymentValidator
    {
        bool ValidatePayment();
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment via PayPal...");
        }

        public void RefundPayment()
        {
            Console.WriteLine("Refunding via PayPal...");
        }
    }

    public class CreditCardProcessor : IPaymentProcessor, IPaymentValidator
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment...");
        }

        public void RefundPayment()
        {
            Console.WriteLine("Refunding credit card payment...");
        }

        public bool ValidatePayment()
        {
            Console.WriteLine("Validating credit card details...");
            return true; 
        }
    }

    public class CryptoCurrencyProcessor : IPaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing cryptocurrency payment...");
        }

        public void RefundPayment()
        {
            Console.WriteLine("Refunding cryptocurrency payment...");
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IPaymentValidator _paymentValidator;

        public PaymentService(IPaymentProcessor paymentProcessor, IPaymentValidator paymentValidator)
        {
            _paymentProcessor = paymentProcessor;
            _paymentValidator = paymentValidator;
        }

        public void MakePayment()
        {
            if (_paymentValidator.ValidatePayment())
            {
                _paymentProcessor.ProcessPayment();
            }
            else
            {
                Console.WriteLine("Payment validation failed.");
            }
        }

        public void Refund()
        {
            _paymentProcessor.RefundPayment();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor processor = new CreditCardProcessor();
            IPaymentValidator validator = new CreditCardProcessor();

            var paymentService = new PaymentService(processor, validator);
            paymentService.MakePayment();
            paymentService.Refund();
        }
    }
}
