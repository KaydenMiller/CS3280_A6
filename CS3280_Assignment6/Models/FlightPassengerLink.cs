using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    public class FlightPassengerLink
    {
        /// <summary>
        /// Flight ID
        /// </summary>
        public int Flight_ID { get; set; }
        /// <summary>
        /// Passenger ID
        /// </summary>
        public int Passenger_ID { get; set; }
        /// <summary>
        /// Seat Number
        /// </summary>
        public int Seat_Number { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public FlightPassengerLink()
        {
            
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="seatNumber"></param>
        public FlightPassengerLink(int flightID, int passengerID, int seatNumber)
        {
            Flight_ID = flightID;
            Passenger_ID = passengerID;
            Seat_Number = seatNumber;
        }
    }
}
