using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        public int BD_Year { get; set; }
        public int BD_Month { get; set; }
        public int BD_Day { get; set; }

        // 1-M (Total)
        [InverseProperty(nameof(Airline.Employees))]
        public AirLine Airline { get; set; } = null!;
        [ForeignKey("Airline")]
        public int AL_Id { get; set; }


        // MultiValued

        public virtual ICollection<Emp_Qualification> Qualifications { get; set; } = new List<Emp_Qualification>();
    }
}
