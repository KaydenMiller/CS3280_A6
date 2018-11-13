using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    public class Flight
    {
        /// <summary>
        /// Flight ID
        /// </summary>
        public int Flight_ID { get; set; }

        /// <summary>
        /// Flight number
        /// </summary>
        public string Flight_Number { get; set; }

        /// <summary>
        /// Aircraft type
        /// </summary>
        public string Aircraft_Type { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Flight()
        {

        }

        /// <summary>
        /// Full contstructor
        /// </summary>
        /// <param name="flight_id"></param>
        /// <param name="flight_number"></param>
        /// <param name="aircraft_type"></param>
        public Flight(int flight_id, string flight_number, string aircraft_type)
        {
            Flight_ID = flight_id;
            Flight_Number = flight_number;
            Aircraft_Type = aircraft_type;
        }
    }
}
