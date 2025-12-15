using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Airline_Phones")]
    public class Airline_Phone
    {
        [Key]
        [Column(Order = 1)]
        public int AL_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Phone { get; set; }
        [ForeignKey("AirlineId")]
        public virtual AirLine Airline { get; set; }
    }
}
