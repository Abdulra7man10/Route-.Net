using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2
{
    internal struct Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public double distnanceP() 
        {
            return Math.Abs(x - y);
        }
        public override string ToString()
        {
            return $"X: {x}, Y: {y}";
        }
    }
}
