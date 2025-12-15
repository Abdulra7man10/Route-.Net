using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SectionC_Inh.Models
{
    // Base Class
    // By default, EF Core maps this hierarchy to a single table named "Vehicles"
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Speed { get; set; }
    }

    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
    }

    public class Bus : Vehicle
    {
        public int Capacity { get; set; }
    }
}