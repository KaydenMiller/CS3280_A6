using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Models;

namespace CS3280_Assignment6.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private List<Flight> _flights = new List<Flight>();

        public void Add(Flight item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> Find(Expression<Func<Flight, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> FindAll()
        {
            throw new NotImplementedException();
        }

        public Flight FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Flight item)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight item)
        {
            throw new NotImplementedException();
        }
    }
}
