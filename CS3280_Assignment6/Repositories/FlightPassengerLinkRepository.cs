using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    /// <summary>
    /// Repository for flight links
    /// </summary>
    public class FlightPassengerLinkRepository : Repository<FlightPassengerLink>
    {
        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="context"></param>
        public FlightPassengerLinkRepository(AdoNetContext context) : base(context)
        {

        }

        /// <summary>
        /// Gets all flightlinks from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FlightPassengerLink> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Flight_Passenger_Link";

                return ToList(command);
            }
        }

        /// <summary>
        /// Maps the data from a record to an entitiy for use within the application
        /// </summary>
        /// <param name="record"></param>
        /// <param name="entity"></param>
        protected override void Map(IDataRecord record, FlightPassengerLink entity)
        {
            entity.Flight_ID = (int)record["Flight_ID"];
            entity.Passenger_ID = (int)record["Passenger_ID"];
            int seatNumber;
            int.TryParse((string)record["Seat_Number"], out seatNumber);
            entity.Seat_Number = seatNumber;
        }
    }
}
