using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6.Third
{
    public abstract class User
    {
        public string Name { get; }
        public User(string name) { Name = name; }
        public abstract Discount GetDiscount();
    }

    public class RegularUser : User
    {
        public RegularUser(string name) : base(name) { }
        public override Discount GetDiscount() => new PercentageDiscount(5m);
    }

    public class PremiumUser : User
    {
        public PremiumUser(string name) : base(name) { }
        public override Discount GetDiscount() => new FlatDiscount(100m);
    }

    public class GuestUser : User
    {
        public GuestUser(string name) : base(name) { }
        public override Discount GetDiscount() => new NoDiscount();
    }
}
