using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entity
{
    [Table("Instructors")]
    public class Instructor
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Bouns { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Hour_Rate { get; set; }

        public int Dep_Id { get; set; } // FK Column
    }
}
