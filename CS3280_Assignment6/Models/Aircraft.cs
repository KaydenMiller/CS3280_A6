using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3280_Assignment6.Utilities;

namespace CS3280_Assignment6.Models
{
    public class Aircraft
    {
        public int ID { get; set; }

        public Flight FlightInfo { get; set; }
        public List<Passenger> Passengers { get; set; }

        public int TotalSeats { get; }
        public int Columns { get; set; }
        public int Aisles { get; set; }

        public List<Seat> Seats { get; private set; } = new List<Seat>();

        public Aircraft(Flight flight, int seats, int cols, int aisles)
        {
            FlightInfo = flight;
            TotalSeats = seats;
            Columns = cols;
            Aisles = aisles;

            CreateSeats(seats);
        }

        public void AddPassenger(Passenger passenger)
        {
            Passengers.Add(passenger);
        }
        
        private void CreateSeats(int seatsToCreate)
        {
            for (int seat = 0; seat < seatsToCreate; seat++)
            {
                Seats.Add(new Seat(seat, SeatStatus.Empty));
            }
        }
        public OperationResult UpdateSeat(int id, SeatStatus status)
        {
            var query =
                from seat in Seats
                where seat.ID == id
                select seat;

            if (query != Enumerable.Empty<Seat>())
            {
                query.ToList()[0].Status = status;
                return new OperationResult()
                {
                    Result = OperationResultValue.Success
                };
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Result = OperationResultValue.Failure;
                result.AddMessage($"The query for seat ID: {id} returned an empty Enumerable.");

                return result;
            }
        }
    }
}