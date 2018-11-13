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
    public class FakePassengerRepository : IRepository<Passenger>
    {
        private List<Passenger> _passengers = new List<Passenger>();

        public FakePassengerRepository()
        {
            Add(new Passenger(0, "Kayden", "Miller"));
            Add(new Passenger(1, "Joshua", "Brown"));
            Add(new Passenger(2, "Ethan", "McArthur"));
            Add(new Passenger(3, "Kaycee", "Brown"));
        }

        public void Add(Passenger item)
        {
            _passengers.Add(item);
        }

        public IEnumerable<Passenger> Find(Expression<Func<Passenger, bool>> predicate)
        {
            List<Passenger> flightOutput = new List<Passenger>();

            foreach (Passenger flight in _passengers)
            {
                if (predicate.Compile().Invoke(flight))
                    flightOutput.Add(flight);
            }

            return flightOutput;
        }

        public IEnumerable<Passenger> FindAll()
        {
            return _passengers;
        }

        public Passenger FindByID(int id)
        {
            var query =
                from passenger in _passengers
                where passenger.ID == id
                select passenger;

            return query.ElementAt(0);
        }

        public void Remove(Passenger item)
        {
            if (_passengers.Contains(item))
            {
                _passengers.Remove(item);
            }
        }
    }
}
