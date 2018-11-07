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

        private static void AddFlight(Flight flight)
        {
            _flightRepository.Add(flight);
        }

        private static IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.FindAll();
        }
    }
}
