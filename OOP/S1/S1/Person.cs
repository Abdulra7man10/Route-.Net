using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    internal struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        // functions
        public void Print() { Console.WriteLine($"Name: {Name}, Age: {Age}"); }
    }
}
