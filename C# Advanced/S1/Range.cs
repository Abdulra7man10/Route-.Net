using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    public class Range<T> where T : IComparable<T>
    {
        public T Minimum { get; private set; }
        public T Maximum { get; private set; }
        public Range(T minimum, T maximum)
        {
            if (minimum.CompareTo(maximum) > 0)
            {
                throw new ArgumentException("Minimum value cannot be greater than the maximum value :(");
            }

            Minimum = minimum;
            Maximum = maximum;
        }

        public bool IsInRange(T value)
        {
            bool isGreaterOrEqualThanMin = value.CompareTo(Minimum) >= 0;

            bool isLessOrEqualThanMax = value.CompareTo(Maximum) <= 0;

            return isGreaterOrEqualThanMin && isLessOrEqualThanMax;
        }

        public T Length()
        {
            dynamic max = Maximum;
            dynamic min = Minimum;
            return max - min;
        }
    }
}
