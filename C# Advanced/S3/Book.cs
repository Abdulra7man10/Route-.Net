using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            this.ISBN = _ISBN;
            this.Title = _Title;
            this.Authors = _Authors;
            this.PublicationDate = _PublicationDate;
            this.Price = _Price;
            Console.WriteLine($"Book '{_Title}' created.");
        }

        public override string ToString()
        {
            string authors = Authors != null ? string.Join(", ", Authors) : "N/A";
            return $"Title: {Title}\nISBN: {ISBN}\nAuthors: {authors}\nPublished: {PublicationDate.ToShortDateString()}\nPrice: {Price:C}";
        }

        // (case a)
        public static string GetBookISBNStatic(Book book)
        {
            return book.ISBN;
        }

        // (case b)
        public static string GetBookPublicationDateStatic(Book book)
        {
            return book.PublicationDate.ToString();
        }
    }
}
