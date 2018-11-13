using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Models
{
    /// <summary>
    /// Status of the seat
    /// </summary>
    public enum SeatStatus
    {
        Empty,
        Taken
    }

    /// <summary>
    /// Seat data class
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Seat ID my only be set once
        /// </summary>
        public readonly int ID;

        /// <summary>
        /// Current seat Status
        /// </summary>
        public SeatStatus Status { get; set; } = SeatStatus.Empty;

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public Seat(int id, SeatStatus status)
        {
            ID = id;
            Status = status;
        }
    }
}