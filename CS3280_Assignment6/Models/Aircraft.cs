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
    public class Aircraft
    {
        public int ID { get; set; }

        private Flight _flightInfo { get; set; }
        public int Flight_ID { get; set; }
        public string Flight_Number { get; set; }
        public string Aircraft_Type { get; set; }

        public List<Passenger> Passengers { get; set; }

        public int TotalSeats { get; }
        public int Columns { get; set; }
        public int Aisles { get; set; }

        public List<SeatViewModel> Seats { get; private set; } = new List<SeatViewModel>();

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

        public void LoadPassengers()
        {
            var query =
                    from passenger in FlightController.GetAllPassengers()
                    join link in FlightController.GetAllLinks() on passenger.ID equals link.Passenger_ID
                    where link.Flight_ID == _flightInfo.Flight_ID
                    select passenger;

            Passengers.AddRange(query);
        }

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