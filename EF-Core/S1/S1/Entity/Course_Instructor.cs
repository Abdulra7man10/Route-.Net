using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entity
{
    [Table("Course_Instructor")]
    public class Course_Instructor
    {
        [Key]
        [Column(Order = 1)]
        public int Course_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Inst_Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Evaluation { get; set; }
    }
}
