using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static S3.Program;

namespace S3
{
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> blist, Func<Book, string> fPtr)
        {
            Console.WriteLine("--------------------------------------");
            foreach (Book B in blist)
            {
                Console.WriteLine(fPtr(B));
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
