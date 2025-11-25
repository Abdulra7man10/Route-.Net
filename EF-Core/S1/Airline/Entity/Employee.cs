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

        public int AL_Id { get; set; } // FK to Airline
    }
}
