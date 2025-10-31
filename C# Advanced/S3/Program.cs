using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3
{
    internal class Program
    {
        public delegate string BookPropertyStringAccessor(Book book);

        static void Main(string[] args)
        {
            /*#region Book
            Book myBook = new Book(
                _ISBN: "978-0321127199",
                _Title: "C# Essentials",
                _Authors: new[] { "Jane Doe", "John Smith" },
                _PublicationDate: new DateTime(2023, 10, 26),
                _Price: 59.99m
            );

            Console.WriteLine("\n--- Book Details ---");
            Console.WriteLine(myBook.ToString());
            Console.WriteLine("--------------------\n");

            // a
            BookPropertyStringAccessor fPtr_a = Book.GetBookISBNStatic;
            string isbn_a = fPtr_a(myBook);
            Console.WriteLine($"a. User-Defined Delegate (ISBN): {isbn_a}");

            // b
            Func<Book, DateTime> fPtr_b = Book.GetBookPublicationDateStatic;
            DateTime pubDate_b = fPtr_b(myBook);
            Console.WriteLine($"b. BCL Delegate (Pub. Date): {pubDate_b.ToShortDateString()}");

            // c
            BookPropertyStringAccessor fPtr_c = delegate (Book b)
            {
                return $"ISBN via Anonymous Method: {b.ISBN}";
            };
            string isbn_c = fPtr_c(myBook);
            Console.WriteLine($"c. Anonymous Method (ISBN): {isbn_c}");

            // d
            Func<Book, DateTime> fPtr_d = b =>
            {
                return b.PublicationDate;
            };
            DateTime pubDate_d = fPtr_d(myBook);
            Console.WriteLine($"d. Lambda Expression (Pub. Date): {pubDate_d.ToShortDateString()}");

            #endregion*/

            #region BookFunctions & LibraryEngine
            Book myBook = new Book(
                _ISBN: "978-0321127199",
                _Title: "C# Essentials",
                _Authors: new[] { "Jane Doe", "John Smith" },
                _PublicationDate: new DateTime(2023, 10, 26),
                _Price: 59.99m
            );
            Book anotherBook = new Book(
                _ISBN: "978-0134685991",
                _Title: "Data Structures in C#",
                _Authors: new[] { "Alice Johnson" },
                _PublicationDate: new DateTime(2020, 5, 15),
                _Price: 75.50m
            );

            List<Book> bookList = new List<Book> { myBook, anotherBook };

            // A
            BookPropertyStringAccessor userDefinedAccessor = BookFunctions.GetTitle;
            Func<Book, string> fPtr_a = new Func<Book, string>(userDefinedAccessor);

            Console.WriteLine("A. User-Defined Delegate (Points to BookFunctions.GetTitle):");
            LibraryEngine.ProcessBooks(bookList, fPtr_a);


            // B
            Func<Book, string> fPtr_b = BookFunctions.GetAuthors;

            Console.WriteLine("\nB. BCL Delegate (Points to BookFunctions.GetAuthors):");
            LibraryEngine.ProcessBooks(bookList, fPtr_b);

            // C
            Func<Book, string> fPtr_c = delegate (Book b)
            {
                return $"[ISBN via Anonymous Method]: {b.ISBN}";
            };

            Console.WriteLine("\nC. Anonymous Method (Inline logic for ISBN):");
            LibraryEngine.ProcessBooks(bookList, fPtr_c);


            // D
            Func<Book, string> fPtr_d = b =>
            {
                return $"[Pub. Date via Lambda Expression]: {b.PublicationDate.ToShortDateString()}";
            };

            Console.WriteLine("\nD. Lambda Expression (Inline logic for Publication Date):");
            LibraryEngine.ProcessBooks(bookList, fPtr_d);
            #endregion
        }
    }
}
