using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    internal class Point
    {
        // properties
        public int x { get; set; }
        public int y { get; set; }

        // constructors
        public Point(int _x = default, int _y = default)
        {
            x = _x;
            y = _y;
        }

        public Point(int number)
        {
            x = y = number;
        }

        // override to string function
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
