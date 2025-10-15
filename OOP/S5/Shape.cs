using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5
{
    public class Circle : ICircle
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Radius => _radius;
        public double Area => Math.PI * _radius * _radius;

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Shape Type: Circle");
            Console.WriteLine($"Radius: {Radius:F2}");
            Console.WriteLine($"Area: {Area:F2}");
        }
    }

    public class Rectangle : IRectangle
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double Width => _width;
        public double Height => _height;
        public double Area => _width * _height;

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Shape Type: Rectangle");
            Console.WriteLine($"Width: {Width:F2}");
            Console.WriteLine($"Height: {Height:F2}");
            Console.WriteLine($"Area: {Area:F2}");
        }
    }
}
