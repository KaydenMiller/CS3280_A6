using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Repositories;
using CS3280_Assignment6.Models;
using System.IO;

namespace CS3280_Assignment6.Controllers
{
    /// <summary>
    /// Controller for the Flights within this program
    /// </summary>
    public static class FlightController
    {
        private static readonly string _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source = " + Directory.GetCurrentDirectory() + "\\ReservationSystem.mdb";

        /// <summary>
        /// The context class for ADO.NET
        /// </summary>
        private static AdoNetContext adoContext = new AdoNetContext(_connectionString);

        // Repositories of data
        private static FlightRepository _flightRepository = new FlightRepository(adoContext);
        private static PassengerRepository _passengerRepository = new PassengerRepository(adoContext);
        private static FlightPassengerLinkRepository _flightLinkRepo = new FlightPassengerLinkRepository(adoContext);

        // Flight Methods
        /// <summary>
        /// Will add a flight
        /// </summary>
        /// <param name="flight"></param>
        public static void AddFlight(Flight flight)
        {
            _flightRepository.Add(flight);
        }

        /// <summary>
        /// Will retrieve all flights
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.GetAll();
        }

        // Passenger Methods
        /// <summary>
        /// Will add a passenger
        /// </summary>
        /// <param name="passenger"></param>
        public static void AddPassenger(Passenger passenger)
        {
            //_passengerRepository.Add(passenger);
        }

        /// <summary>
        /// Will Get all passengers
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Passenger> GetAllPassengers()
        {
            return _passengerRepository.GetAll();
        }

        // Flight Passenger Link Methods
        /// <summary>
        /// Will get all flight passenger links
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<FlightPassengerLink> GetAllLinks()
        {
            return _flightLinkRepo.GetAll();
        }
    }
}
