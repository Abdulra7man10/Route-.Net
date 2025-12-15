using Airline.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Entity
{
    [Table("Routes")]
    public class Route
    {
        [Key]
        public int Id { get; set; }

        public int Distance { get; set; }

        [StringLength(50)]
        public string Destination { get; set; }

        [StringLength(50)]
        public string Origin { get; set; }

        [StringLength(50)]
        public string Classification { get; set; }

        [InverseProperty(nameof(FlightAssignment.Route))]
        public virtual ICollection<FlightAssignment> FlightAssignments { get; set; } = new List<FlightAssignment>();
    }
}
