using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    public class FlightPassengerLink
    {
        public int Flight_ID { get; set; }
        public int Passenger_ID { get; set; }
        public int Seat_Number { get; set; }

        public FlightPassengerLink()
        {

        }

        public FlightPassengerLink(int flightID, int passengerID, int seatNumber)
        {
            Flight_ID = flightID;
            Passenger_ID = passengerID;
            Seat_Number = seatNumber;
        }
    }
}
