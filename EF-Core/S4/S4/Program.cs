using Airline.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Airline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AirlineContext context = new AirlineContext();

            #region A: Loading Related Data

            /*#region 1
            var egyptAirWithAircraftsAndRoutes = context.Airlines // Eager Loading
                .Include(a => a.Aircrafts)
                .ThenInclude(a => a.FlightAssignments)
                .ThenInclude(fa => fa.Route)
                .FirstOrDefault(a => a.Name == "EgyptAir");


            Console.WriteLine($"Airline: {egyptAirWithAircraftsAndRoutes.Name}");
            foreach (var aircraft in egyptAirWithAircraftsAndRoutes.Aircrafts)
            {
                Console.WriteLine($"\tAircraft Model: {aircraft.Model}, Capacity: {aircraft.Capacity}");
                if (aircraft.FlightAssignments.Any())
                {
                    foreach (var flightAssignment in aircraft.FlightAssignments)
                    {
                        Console.WriteLine($"\t\tFlight Aircraft ID: {flightAssignment.AircraftId}, Route: {flightAssignment.Route.Origin} to {flightAssignment.Route.Destination}");
                    }
                }
                else
                {
                       Console.WriteLine("\t\tNo Flight Assignments for this aircraft.");
                }
            }
            #endregion*/

            /*#region 2
            var airlinesWithEmployeesAndTheirQualifications = context.Airlines // Eager Loading
                .Include(a => a.Employees)
                .ThenInclude(e => e.Qualifications)
                .ToList();
            foreach (var airline in airlinesWithEmployeesAndTheirQualifications)
            {
                Console.WriteLine($"Airline: {airline.Name}");
                foreach (var employee in airline.Employees)
                {
                    Console.WriteLine($"\tEmployee: {employee.Name}");
                    foreach (var qualification in employee.Qualifications)
                    {
                        Console.WriteLine($"\t\tQualification: {qualification.Qualification}");
                    }
                }
            }
            #endregion*/

            /*#region 3
            var airlines = context.Airlines;
            foreach (var airline in airlines)
            {
                var airlinesWithTransactionsBiggerThan10K = context.Entry(airline).Collection(a => a.Transactions)
                    .Query()
                    .Where(t => t.Amount > 10000)
                    .ToList();
                
                Console.WriteLine($"Airline: {airline.Name}");
                if (airline.Transactions.Any())
                {
                    foreach (var trans in airline.Transactions)
                    {
                        Console.WriteLine($"\tTransaction Amount: {trans.Amount}, Desc.: {trans.Description}");
                    }
                }
                else
                {
                       Console.WriteLine("\tNo Transactions greater than 10,000 for this airline.");
                }
            }
            #endregion*/

            /*#region 4
            var routes = context.Routes.Select(r => new
            {
                Origin = r.Origin,
                Destination = r.Destination,
                AircraftModel = r.FlightAssignments.Select(fa => fa.Aircraft.Model).FirstOrDefault()
            })
            .ToList();

            foreach (var route in routes)
            {
                Console.WriteLine($"Route: {route.Origin} to {route.Destination}");
                if (route.AircraftModel is not null)
                {
                    Console.WriteLine($"\tAircraft Model: {route.AircraftModel}");
                }
                else
                {
                    Console.WriteLine("\tNo Aircraft assigned to this route.");
                }
            }
            #endregion*/

            /*#region 5
            var aircraftsWithAirlineAndPhones = context.Aircrafts
                .Include(ac => ac.Airline)
                .ThenInclude(a => a.Phones)
                .ToList();
            foreach (var aircraft in aircraftsWithAirlineAndPhones)
            {
                Console.WriteLine($"Aircraft Model: {aircraft.Model}, Capacity: {aircraft.Capacity}");
                Console.WriteLine($"\tAirline: {aircraft.Airline.Name}");
                foreach (var phone in aircraft.Airline.Phones)
                {
                    Console.WriteLine($"\t\tPhone: {phone.Phone}");
                }
            }
            #endregion*/

            #endregion


            #region B: Join Operators

            /*#region 1
            var employeesWithAirlineNames = context.Employees.Join(context.Airlines,
                e => e.AL_Id,
                a => a.Id,
                (e, a) => new
                {
                    EmployeeID = e.Id,
                    EmployeeName = e.Name,
                    EmployeePosition = e.Position,
                    AirlineName = a.Name
                }).ToList();

            foreach (var emp in employeesWithAirlineNames)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.EmployeeName}, Position: {emp.EmployeePosition}, Airline: {emp.AirlineName}");
            }
            #endregion*/

            /*#region 2
            var routesWithModelAndAirlineName = context.Routes
                .Join(context.FlightAssignments,
                r => r.Id,
                fa => fa.RouteId,
                (r, fa) => new { Route = r, FlightAssignment = fa })
                .Join(context.Aircrafts,
                fa => fa.FlightAssignment.AircraftId,
                ac => ac.Id,
                (fa, ac) => new { fa.Route, Aircraft = ac })
                .Join(context.Airlines,
                ac => ac.Aircraft.AL_Id,
                a => a.Id,
                (ac, a) => new
                {
                    RouteOrigin = ac.Route.Origin,
                    RouteDestination = ac.Route.Destination,
                    AircraftModel = ac.Aircraft.Model,
                    AirlineName = a.Name
                }).ToList();

            foreach (var item in routesWithModelAndAirlineName)
            {
                Console.WriteLine($"Route: {item.RouteOrigin} to {item.RouteDestination}, Aircraft Model: {item.AircraftModel}, Airline: {item.AirlineName}");
            }

            #endregion*/

            /*#region 3
            var groupAirlineAircrafts = context.Airlines
                .GroupJoin(context.Aircrafts,
                a => a.Id,
                ac => ac.AL_Id,
                (a, acs) => new
                {
                    AirLine = a,
                    Aircrafts = acs
                }).ToList();

            foreach (var airline in groupAirlineAircrafts)
            {
                Console.WriteLine($"Airline: {airline.AirLine.Name}");
                foreach (var aircraft in airline.Aircrafts)
                {
                    Console.WriteLine($"\tAircraft Model: {aircraft.Model}, Capacity: {aircraft.Capacity}");
                }
            }
            #endregion*/

            /*#region 4
            var transactionsWithAirlineNamesLessThan20K = context.Transactions
                .Join(context.Airlines,
                t => t.AL_Id,
                a => a.Id,
                (t, a) => new
                {
                    TransactionId = t.Id,
                    TransactionAmount = t.Amount,
                    TransactionDescription = t.Description,
                    AirlineName = a.Name
                })
                .Where(ta => ta.TransactionAmount < 20000);

            foreach (var trans in transactionsWithAirlineNamesLessThan20K)
            {
                Console.WriteLine($"TID: {trans.TransactionId}, TAmount: {trans.TransactionAmount}, TDesc: {trans.TransactionDescription}, Airline Name: {trans.AirlineName}");
            }
            #endregion*/

            #endregion


            #region C: Inheritance Mapping

            #region 1
            #endregion

            #region 2
            #endregion

            #region 3
            #endregion

            #endregion

        }
    }
}