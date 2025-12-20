using ProductA.Models;

namespace ProductA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductContext())
            {
                var b1 = new Book { Name = "C# Fundamentals", Author = "Anders Hejlsberg" };
                var e1 = new Electronics { Name = "Laptop", Brand = "Lenovo" };

                context.Books.Add(b1);
                context.Electronics.Add(e1);
                context.SaveChanges();
            }
        }
    }
}
