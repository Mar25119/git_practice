using PaymentSystem.Interfaces;
using System;
using System.Collections.Generic;
namespace PaymentSystem.Processors
{
    public class CreditCardProcessor : IPaymentProcessor, IPaymentValidator
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Credit Card payment of {amount:C}");
            return true;
        }

        public bool RefundPayment(decimal amount)
        {
            Console.WriteLine($"Refunding Credit Card payment of {amount:C}");
            return true;
        }

        public bool ValidatePayment(decimal amount)
        {
            Console.WriteLine("Validating credit card payment...");
            return amount > 0 && amount <= 10000;
        }
    }
}