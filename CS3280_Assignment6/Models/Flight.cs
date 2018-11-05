using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    public class Flight
    {
        public int Flight_ID { get; set; }
        public int Flight_Number { get; set; }
        public string Aircraft_Type { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
