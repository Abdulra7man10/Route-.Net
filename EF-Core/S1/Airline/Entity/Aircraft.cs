using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Aircrafts")]
    public class Aircraft
    {
        [Key]
        public int Id { get; set; }

        public int Capacity { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Maj_pilot { get; set; }

        [StringLength(50)]
        public string Assistant { get; set; }

        [StringLength(50)]
        public string Host1 { get; set; }

        [StringLength(50)]
        public string Host2 { get; set; }

        public int AL_Id { get; set; } // FK to Airline
    }
}
