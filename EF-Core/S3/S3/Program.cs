using Airline.Entity;
using Microsoft.EntityFrameworkCore;
using S3.Entity;
using System;
using System.Linq;

namespace Airline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AirlineContext context = new AirlineContext();

            /*#region a
            var newAirline = new AirLine
            {
                Name = "EgyptAir",
                Address = "Cairo",
                Contact_Person = "Ahmed Ali"
            };
            newAirline.Phones.Add(new Airline_Phone { Phone = "0123456789" });
            newAirline.Phones.Add(new Airline_Phone { Phone = "0113654789" });
            
            context.Airlines.Add(newAirline);
            context.SaveChanges();
            Console.WriteLine("Airline and Phones added successfully.");
            #endregion*/

            /*#region b
            var egyptAir = context.Airlines.FirstOrDefault(a => a.Name == "EgyptAir");

            if (egyptAir != null)
            {
                var newAircraft = new Aircraft
                {
                    Model = "Model01",
                    Capacity = 180,
                    Airline = egyptAir
                };

                context.Aircrafts.Add(newAircraft);
                context.SaveChanges();
                Console.WriteLine("Aircraft added successfully.");
            }
            #endregion*/

            /*#region c
            var newTransaction = new Transaction
            {
                Date = DateTime.Now,
                Amount = 5000,
                Description = "Tickets",
                Airline = context.Airlines.FirstOrDefault(a => a.Name == "EgyptAir")
            };

            context.Transactions.Add(newTransaction);
            context.SaveChanges();
            Console.WriteLine("Transaction added successfully.");
            #endregion*/

            /*#region d
            var employeesWorkinEgyptAir = context.Employees
                .Where(e => e.Airline.Name == "EgyptAir")
                .ToList();
            foreach (var emp in employeesWorkinEgyptAir)
            {
                Console.WriteLine($"Employee ID: {emp.Id}, Name: {emp.Name}, Position: {emp.Position}");
            }
            #endregion*/

            /*#region e
            var transcationsOfEgyptAir = context.Transactions
                .Where(t => t.Airline.Name == "EgyptAir")
                .ToList();
            foreach (var item in transcationsOfEgyptAir)
            {
                Console.WriteLine($"ID: {item.Id}, Description: {item.Description}, {item.Amount}");
            }
            #endregion*/

            /*#region f
            var totalNumberOfEmployeesInEachAirline = context.Airlines
                .Select(a => new
                {
                    AirlineName = a.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToList();
            foreach (var item in totalNumberOfEmployeesInEachAirline)
            {                 
                Console.WriteLine($"Airline: {item.AirlineName}, Total Employees: {item.EmployeeCount}");
            }
            #endregion*/

            /*#region g
            var aircraftModel01 = context.Aircrafts.FirstOrDefault(a => a.Model == "Model01");
            if (aircraftModel01 is not null)
            {
                aircraftModel01.Capacity = 200;
                context.SaveChanges();
                Console.WriteLine("Aircraft capacity updated successfully.");
            }
            #endregion*/

            /*#region h
            var transactionToDelete = context.Transactions.Where(t => t.Date.Year > 2020);

            context.Transactions.RemoveRange(transactionToDelete);

            context.SaveChanges();
            Console.WriteLine("Transactions deleted successfully.");
            #endregion*/

            /*#region i
            var newRoute = new Route
            {
                Origin = "Cairo",
                Destination = "Dubai",
                Distance = 2400,
                Classification = "International"
            };

            context.Routes.Add(newRoute);
            context.SaveChanges();
            Console.WriteLine("Route added successfully.");
            #endregion*/

            /*#region j
            var newAssignment = new FlightAssignment
            {
                Departure = DateTime.Now.AddHours(1),
                Arrival= DateTime.Now.AddHours(5),
                Route = context.Routes.FirstOrDefault(r => r.Origin == "Cairo" && r.Destination == "Dubai"),
                Aircraft = context.Aircrafts.FirstOrDefault(a => a.Model == "Model01"),
                Price = 3000,
                Num_Of_Passengers = 0
            };

            context.FlightAssignments.Add(newAssignment);
            context.SaveChanges();
            Console.WriteLine($"Flight assignment added successfully, with duration {newAssignment.DurationMinutes/60}.");
            #endregion*/

        }
    }
}