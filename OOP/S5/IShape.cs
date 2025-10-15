using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5
{
    public interface IShape
    {
        double Area { get; }

        void DisplayShapeInfo();
    }

    public interface ICircle : IShape
    {
        double Radius { get; }
    }

    public interface IRectangle : IShape
    {
        double Width { get; }
        double Height { get; }
    }
}
