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
    public static class FlightController
    {
        private static readonly string _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source = " + Directory.GetCurrentDirectory() + "\\ReservationSystem.mdb";

        private static AdoNetContext adoContext = new AdoNetContext(_connectionString);

        private static FlightRepository _flightRepository = new FlightRepository(adoContext);
        private static PassengerRepository _passengerRepository = new PassengerRepository(adoContext);
        private static FlightPassengerLinkRepository _flightLinkRepo = new FlightPassengerLinkRepository(adoContext);
        //private static FakePassengerRepository _fakePassengerRepository = new FakePassengerRepository();

        // Flight Methods
        public static void AddFlight(Flight flight)
        {
            _flightRepository.Add(flight);
        }

        public static IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.GetAll();
        }

        // Passenger Methods
        public static void AddPassenger(Passenger passenger)
        {
            //_passengerRepository.Add(passenger);
        }

        public static IEnumerable<Passenger> GetAllPassengers()
        {
            return _passengerRepository.GetAll();
        }

        // Flight Passenger Link Methods
        public static IEnumerable<FlightPassengerLink> GetAllLinks()
        {
            return _flightLinkRepo.GetAll();
        }
    }
}
