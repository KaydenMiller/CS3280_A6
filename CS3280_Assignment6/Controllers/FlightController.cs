using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Repositories;
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.Controllers
{
    public static class FlightController
    {
        private static FakeFlightRepository _flightRepository = new FakeFlightRepository();
        private static FakePassengerRepository _fakePassengerRepository = new FakePassengerRepository();

        // Flight Methods
        public static void AddFlight(Flight flight)
        {
            _flightRepository.Add(flight);
        }

        public static IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.FindAll();
        }

        // Passenger Methods
        public static void AddPassenger(Passenger passenger)
        {
            _fakePassengerRepository.Add(passenger);
        }

        public static IEnumerable<Passenger> GetAllPassengers()
        {
            return _fakePassengerRepository.FindAll();
        }
    }
}
