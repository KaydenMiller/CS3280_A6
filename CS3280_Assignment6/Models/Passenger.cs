using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    public class Passenger
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Passenger(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
