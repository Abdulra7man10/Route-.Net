using Airline.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace S3.Entity
{
    [Table("FlightAssignments")]
    [PrimaryKey(nameof(AircraftId), nameof(RouteId))]
    public class FlightAssignment
    {
        // Composite Key (AircraftId + RouteId)
        [ForeignKey(nameof(Aircraft))]
        public int AircraftId { get; set; }
        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }


        // Relationship Attributes
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int? Num_Of_Passengers { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public double DurationMinutes
        {
            get { return (Arrival - Departure).TotalMinutes; }
        }


        // Navigations
        [InverseProperty(nameof(Aircraft.FlightAssignments))]
        public Aircraft Aircraft { get; set; } = null!;

        [InverseProperty(nameof(Route.FlightAssignments))]
        public Route Route { get; set; } = null!;
    }
}
