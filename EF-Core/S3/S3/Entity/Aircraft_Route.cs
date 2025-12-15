using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Aircraft_Routes")]
    public class Aircraft_Route
    {
        [Key]
        [Column(Order = 1)]
        public int AC_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Route_Id { get; set; }

        public DateTime Departure { get; set; }

        public int Num_Of_Pass { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public DateTime Arrival { get; set; }
    }
}
