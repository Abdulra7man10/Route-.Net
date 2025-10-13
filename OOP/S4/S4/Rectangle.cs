using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4
{
    class Rectangle
    {
        private int width;
        private int height;

        public Rectangle()
        {
            width = 0;
            height = 0;
        }

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Rectangle(int side)
        {
            width = side;
            height = side;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Width: {width}, Height: {height}");
        }
    }
}
