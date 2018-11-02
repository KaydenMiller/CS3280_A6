using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    public enum SeatStatus
    {
        Empty,
        Selected,
        Taken
    }

    public class Seat
    {
        public readonly int ID;

        public SeatStatus Status { get; set; } = SeatStatus.Empty;

        public Seat(int id, SeatStatus status)
        {
            ID = id;
            Status = status;
        }
    }
}