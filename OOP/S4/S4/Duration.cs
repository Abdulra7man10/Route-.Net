using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4
{
    internal class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Duration() : this(0, 0, 0) { }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;

            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        private int ToTotalSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }

        private void Normalize()
        {
            if (Seconds >= 60)
            {
                Minutes += Seconds / 60;
                Seconds %= 60;
            }
            if (Minutes >= 60)
            {
                Hours += Minutes / 60;
                Minutes %= 60;
            }

            if (Seconds < 0)
            {
                int borrow = (Math.Abs(Seconds) + 59) / 60;
                Minutes -= borrow;
                Seconds += borrow * 60;
            }
            if (Minutes < 0)
            {
                int borrow = (Math.Abs(Minutes) + 59) / 60;
                Hours -= borrow;
                Minutes += borrow * 60;
            }

            if (Hours < 0)
                Hours = Minutes = Seconds = 0;
        }

        public override string ToString()
        {
            if (Hours > 0)
                return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
            else
                return $"Minutes :{Minutes}, Seconds :{Seconds}";
        }

        // Override Equals()
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;
            Duration other = (Duration)obj;
            return Hours == other.Hours &&
                   Minutes == other.Minutes &&
                   Seconds == other.Seconds;
        }

        // operator overloads
        public static Duration operator +(Duration d1, Duration d2)
        {
            int total = d1.ToTotalSeconds() + d2.ToTotalSeconds();
            return new Duration(total);
        }

        public static Duration operator +(Duration d, int seconds)
        {
            int total = d.ToTotalSeconds() + seconds;
            return new Duration(total);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            int total = d.ToTotalSeconds() + seconds;
            return new Duration(total);
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.ToTotalSeconds() + 60);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(d.ToTotalSeconds() - 60);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            int total = d1.ToTotalSeconds() - d2.ToTotalSeconds();
            return new Duration(total);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() > d2.ToTotalSeconds();
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() < d2.ToTotalSeconds();
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() >= d2.ToTotalSeconds();
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
        }

        public static bool operator true(Duration d)
        {
            return d.ToTotalSeconds() > 0;
        }

        public static bool operator false(Duration d)
        {
            return d.ToTotalSeconds() == 0;
        }

        public static explicit operator DateTime(Duration d)
        {
            DateTime today = DateTime.Now.Date;
            return today.AddHours(d.Hours).AddMinutes(d.Minutes).AddSeconds(d.Seconds);
        }
    }
}
