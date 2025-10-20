using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S6.First
{
    public class Point3D : ICloneable, IComparable<Point3D>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() : this(0, 0, 0) { }

        public Point3D(int x, int y) : this(x, y, 0) { }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Point3D other = (Point3D)obj;
            return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
        }

        public override int GetHashCode()
        {
            return X ^ Y ^ Z;
        }
        public static bool operator ==(Point3D p1, Point3D p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.Equals(p2);
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !(p1 == p2);
        }

        public int CompareTo(Point3D other)
        {
            if (this.X > other?.X)
                return 1;
            else if (this.X < other?.X)
                return -1;
            else
                if (this.Y > other?.Y)
                    return 1;
                else if (this.Y < other?.Y)
                    return -1;
                else
                    return 0;
        }


        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
