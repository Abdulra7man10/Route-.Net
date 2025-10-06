using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2
{
    internal class Rectangle
    {
        private double _width;
        private double _height;

        public double width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: Width cannot be negative!");
                }
                else
                {
                    _width = value;
                }
            }
        }

        public double height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: Height cannot be negative!");
                }
                else
                {
                    _height = value;
                }
            }
        }

        public double Area
        {
            get { return width * height; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Width: {width}");
            Console.WriteLine($"Height: {height}");
            Console.WriteLine($"Area: {Area}");
        }
    }
}
