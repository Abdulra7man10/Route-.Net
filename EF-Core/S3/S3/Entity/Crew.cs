using Airline.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace S3.Entity
{
    [Table("Crews")]
    public class Crew
    {
        public int AircraftId { get; set; }

        [StringLength(50)]
        public string CrewMaj_Pilot { get; set; }
        [StringLength(50)]
        public string Assis_Pilot { get; set; }
        [StringLength(50)]
        public string Host1 { get; set; }
        [StringLength(50)]
        public string Host2 { get; set; }

        public Aircraft Aircraft { get; set; } = null!;
    }
}
