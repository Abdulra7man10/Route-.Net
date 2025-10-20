using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6.Third
{
    public abstract class Discount
    {

        public abstract string Name { get; }
        public abstract decimal CalculateDiscount(decimal price, int quantity);
    }

    public class PercentageDiscount : Discount
    {
        private readonly decimal _percentage;

        public override string Name => $"Percentage ({_percentage}%)";

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity <= 0) return 0m;
            return price * quantity * (_percentage / 100m);
        }
    }

    public class FlatDiscount : Discount
    {
        private readonly decimal _flatAmount;

        public override string Name => $"Flat Discount (${_flatAmount:N2})";

        public FlatDiscount(decimal flatAmount)
        {
            _flatAmount = flatAmount;
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity > 0)
            {
                return _flatAmount;
            }
            return 0m;
        }
    }

    /// <summary>
    /// Implements the specific BuyOneGetOne logic defined in the requirements.
    /// Formula: Discount Amount = (Price / 2) * (Quantity / 2)
    /// </summary>
    public class BuyOneGetOneDiscount : Discount
    {
        public override string Name => "Buy One Get One (50% off on pairs)";

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            if (quantity > 1)
            {
                int pairs = quantity / 2;

                return (price / 2m) * pairs;
            }
            return 0m;
        }
    }

    public class NoDiscount : Discount
    {
        public override string Name => "No Discount Applied";
        public override decimal CalculateDiscount(decimal price, int quantity) => 0m;
    }

}
