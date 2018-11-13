using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Controllers;
using CS3280_Assignment6.Utilities;
using CS3280_Assignment6.ViewModels;

namespace CS3280_Assignment6.Models
{
    /// <summary>
    /// Data class to repressent all data assciated with an aircraft and flight
    /// </summary>
    public class Aircraft
    {
        /// <summary>
        /// Represents the id of this object
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Basic flight info provided by the database
        /// </summary>
        private Flight _flightInfo { get; set; }
        /// <summary>
        /// The flight ID
        /// </summary>
        public int Flight_ID { get; set; }
        /// <summary>
        /// The FlightNumber
        /// </summary>
        public string Flight_Number { get; set; }
        /// <summary>
        /// The AircraftType
        /// </summary>
        public string Aircraft_Type { get; set; }

        /// <summary>
        /// All passengers on this flight
        /// </summary>
        public List<Passenger> Passengers { get; set; }

        // The following 3 properties are for formating of the aircraft control and as of yet are arbatrary values (mostly)
        /// <summary>
        /// The total seats this aircraft has
        /// </summary>
        public int TotalSeats { get; }
        /// <summary>
        /// The total number of columns of seats on this aircraft
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// The number of walking aisles
        /// </summary>
        public int Aisles { get; set; }

        /// <summary>
        /// A list of all seat viewModels for display within the custom seatingGrid control
        /// </summary>
        public List<SeatViewModel> Seats { get; private set; } = new List<SeatViewModel>();

        /// <summary>
        /// Aircraft constructor
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="seats"></param>
        /// <param name="cols"></param>
        /// <param name="aisles"></param>
        public Aircraft(Flight flight, int seats, int cols, int aisles)
        {
            Passengers = new List<Passenger>();

            _flightInfo = flight;
            Flight_ID = _flightInfo.Flight_ID;
            Flight_Number = _flightInfo.Flight_Number;
            Aircraft_Type = _flightInfo.Aircraft_Type;

            TotalSeats = seats;
            Columns = cols;
            Aisles = aisles;

            LoadPassengers();
            List<int> filledSeats = GetFilledSeats().ToList();

            for (int seat = 0; seat < seats; seat++)
            {
                SeatViewModel viewModel = new SeatViewModel
                {
                    SeatID = seat + 1
                };

                bool seatIsFilled = false;
                foreach (int filledSeatID in filledSeats)
                {
                    if (filledSeatID == viewModel.SeatID)
                    {
                        seatIsFilled = true;
                        break;
                    }
                }

                if (seatIsFilled)
                    viewModel.SeatStatus = SeatStatus.Taken;
                else
                    viewModel.SeatStatus = SeatStatus.Empty;

                Seats.Add(viewModel);
            }
        }

        /// <summary>
        /// Loads the passengers into the list of passengers for this aircraft from based on the passenger flight link in the database
        /// </summary>
        public void LoadPassengers()
        {
            var query =
                    from passenger in FlightController.GetAllPassengers()
                    join link in FlightController.GetAllLinks() on passenger.ID equals link.Passenger_ID
                    where link.Flight_ID == _flightInfo.Flight_ID
                    select passenger;

            Passengers.AddRange(query);
        }

        /// <summary>
        /// Determines the passengers seat number
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        public string GetPassengerSeatID(Passenger passenger)
        {
            if (Passengers == null || passenger == null)
                return "";

            var query =
                from pass in Passengers
                where pass.FirstName == passenger.FirstName &&
                    pass.LastName == passenger.LastName
                select pass;

            Passenger foundPassenger = query.ToList()[0];

            var linkQuery =
                    from passLink in FlightController.GetAllLinks()
                    where passLink.Passenger_ID == foundPassenger.ID
                    select passLink;

            return linkQuery.ToList()[0].Seat_Number.ToString();
        }

        /// <summary>
        /// Which seats on this aircraft are filled
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetFilledSeats()
        {
            var query =
                from passenger in FlightController.GetAllPassengers()
                join link in FlightController.GetAllLinks() on passenger.ID equals link.Passenger_ID
                where link.Flight_ID == _flightInfo.Flight_ID
                select link;

            List<int> filledSeats = new List<int>();
            foreach (FlightPassengerLink link in query)
            {
                filledSeats.Add(link.Seat_Number);
            }
            return filledSeats;
        }
    }
}