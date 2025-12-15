using SectionC_Inh.Models;

namespace SectionC_Inh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VehicleContext())
            {
                // 1.Car
                var myCar = new Car
                {
                    Model = "BMW",
                    Speed = 240,
                    NumberOfDoors = 4
                };

                // 2.Bus
                var myBus = new Bus
                {
                    Model = "Mercedes Bus",
                    Speed = 120,
                    Capacity = 50
                };

                context.Vehicles.Add(myCar);
                context.Vehicles.Add(myBus);
                context.SaveChanges();

                Console.WriteLine("Added Car and Bus to the single 'Vehicles' table.");
            }
        }
    }
}
