using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    // Abstract
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("Books")]
    public class Book : Product
    {
        public string Author { get; set; }
    }

    [Table("Electronics")]
    public class Electronics : Product
    {
        public string Brand { get; set; }
    }
}