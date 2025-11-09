using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListGenerator listGenerator = new ListGenerator();
            #region Restriction Operators
            List<Product> productOutOfStock = listGenerator.GetProductList()
                .Where(p => p.UnitsInStock == 0)
                .ToList();
            #endregion
        }
    }
}
