using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entity
{
    [Table("Departments")]
    public class Department
    {
        
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Hiring_Date { get; set; }

        public int Ins_Id { get; set; } // FK Column
    }
}
