using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Airlines")]
    public class AirLine
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Contact_Person { get; set; }

        // MultiValued 
        public virtual ICollection<Airline_Phone> Phones { get; set; } = new List<Airline_Phone>();


        // 1-M (Total)
        [InverseProperty(nameof(Employee.Airline))]
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();


        // 1-M (Total)
        [InverseProperty(nameof(Transaction.Airline))]
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();


        // 1-M (Total)
        [InverseProperty(nameof(Aircraft.Airline))]
        public virtual ICollection<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();
    }
}
