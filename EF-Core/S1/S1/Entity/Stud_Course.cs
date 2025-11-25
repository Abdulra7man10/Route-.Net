using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entity
{
    [Table("Stud_Course")]
    public class Stud_Course
    {

        [Key]
        [Column(Order = 1)]
        public int Stud_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Course_Id { get; set; }

        public int Grade { get; set; }
    }
}
