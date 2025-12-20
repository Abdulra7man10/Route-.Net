using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace PaymentA.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }

    [Table("CreditCardPayments")]
    public class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; }
    }

    [Table("CashPayments")]
    public class CashPayment : Payment
    {
        public string Currency { get; set; }
    }
}