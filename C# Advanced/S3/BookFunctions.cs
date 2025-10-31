using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return $"[Title]: {B.Title}";
        }

        public static string GetAuthors(Book B)
        {
            string authors = B.Authors != null ? string.Join(", ", B.Authors) : "No Authors Listed";
            return $"[Authors]: {authors}";
        }

        public static string GetPrice(Book B)
        {
            return $"[Price]: {B.Price:C}";
        }
    }

}
