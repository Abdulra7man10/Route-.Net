using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Entity
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Duration { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int top_Id { get; set; } // FK Column
    }
}
