using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Emp_Qualifications")]
    public class Emp_Qualification
    {
        [Key]
        [Column(Order = 1)]
        public int Emp_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Qualification { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee emp { get; set; }
    }
}
