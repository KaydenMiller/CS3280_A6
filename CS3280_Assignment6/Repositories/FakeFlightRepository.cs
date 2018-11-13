using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.Repositories
{
    /// <summary>
    /// Used for testing
    /// </summary>
    public class FakeFlightRepository : IRepository<Flight>
    {
        private List<Flight> _flights = new List<Flight>();

        public FakeFlightRepository()
        {
            Add(new Flight(0, "121", "Boeing 747"));
            Add(new Flight(1, "122", "Commerical Jet"));
            Add(new Flight(2, "453", "Not good at names"));
            Add(new Flight(3, "422", "Special Jet 42"));
        }

        public void Add(Flight item)
        {
            _flights.Add(item);
        }

        public IEnumerable<Flight> Find(Expression<Func<Flight, bool>> predicate)
        {
            List<Flight> flightOutput = new List<Flight>();
            
            foreach (Flight flight in _flights)
            {
                if (predicate.Compile().Invoke(flight))
                    flightOutput.Add(flight);
            }

            return flightOutput;
        }

        public IEnumerable<Flight> FindAll()
        {
            return _flights;
        }

        public Flight FindByID(int id)
        {
            var query =
                from flight in _flights
                where flight.Flight_ID == id
                select flight;

            return query.ElementAt(0);
        }

        public void Remove(Flight item)
        {
            if (_flights.Contains(item))
            {
                _flights.Remove(item);
            }
        }
    }
}
