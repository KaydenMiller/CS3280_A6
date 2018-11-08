using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Utilities;
using CS3280_Assignment6.ViewModels;

namespace CS3280_Assignment6.Models
{
    public class Aircraft
    {
        public int ID { get; set; }

        private Flight _flightInfo { get; set; }
        public int Flight_ID { get; set; }
        public int Flight_Number { get; set; }
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

            for (int seat = 0; seat < seats; seat++)
            {
                SeatViewModel viewModel = new SeatViewModel
                {
                    SeatID = seat,
                    SeatStatus = SeatStatus.Empty
                };

                Seats.Add(viewModel);
            }

            foreach (Passenger pass in Controllers.FlightController.GetAllPassengers())
            {
                AddPassenger(pass);
            }
        }

        public void AddPassenger(Passenger passenger)
        {
            Passengers.Add(passenger);
        }
    }
}