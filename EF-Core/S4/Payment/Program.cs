using Payment.Models;

namespace Payment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PaymentContext())
            {
                // 1. Add a Credit Card Payment
                var cc = new CreditCardPayment
                {
                    Amount = 1000,
                    CardNumber = "1234-5678-9012-3456"
                };

                // 2. Add a Cash Payment
                var cash = new CashPayment
                {
                    Amount = 50,
                    Currency = "USD"
                };

                // 3. Add default
                var pay = new Payment
                {
                    Amount = 500
                };

                context.CreditCardPayments.Add(cc);
                context.CashPayments.Add(cash);
                context.Payments.Add(pay);
                context.SaveChanges();

                Console.WriteLine("Added Payments using TPT (3 separate tables).");
            }
        }
    }
}
