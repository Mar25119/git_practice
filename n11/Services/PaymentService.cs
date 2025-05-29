using PaymentSystem.Interfaces;

namespace PaymentSystem.Services
{
    public class PaymentService
    {
        private readonly IPaymentProcessor _processor;
        private readonly IPaymentValidator _validator;

        public PaymentService(IPaymentProcessor processor, IPaymentValidator validator)
        {
            _processor = processor;
            _validator = validator;
        }

        public bool MakePayment(decimal amount)
        {
            if (_validator.ValidatePayment(amount))
            {
                return _processor.ProcessPayment(amount);
            }

            Console.WriteLine("Payment validation failed.");
            return false;
        }

        public bool MakeRefund(decimal amount)
        {
            return _processor.RefundPayment(amount);
        }
    }
}