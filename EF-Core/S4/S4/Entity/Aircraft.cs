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
    [Table("Aircrafts")]
    public class Aircraft
    {
        [Key]
        public int Id { get; set; }

        public int Capacity { get; set; }

        public string Model { get; set; }

        [StringLength(50)]
        public string? Maj_pilot { get; set; }

        [StringLength(50)]
        public string? Assistant { get; set; }

        [StringLength(50)]
        public string? Host1 { get; set; }

        [StringLength(50)]
        public string? Host2 { get; set; }

        // 1-M (Total)
        [InverseProperty(nameof(Airline.Aircrafts))]
        public AirLine Airline { get; set; } = null!;
        [ForeignKey("Airline")]
        public int AL_Id { get; set; }

        // (1-1) Both Total
        public Crew Crew { get; set; } = null!;

        // M-M 
        [InverseProperty(nameof(FlightAssignment.Aircraft))]
        public virtual ICollection<FlightAssignment> FlightAssignments { get; set; } = new List<FlightAssignment>();
    }
}
