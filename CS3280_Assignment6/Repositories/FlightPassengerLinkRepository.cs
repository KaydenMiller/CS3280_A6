using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    public class FlightPassengerLinkRepository : Repository<FlightPassengerLink>
    {
        public FlightPassengerLinkRepository(AdoNetContext context) : base(context)
        {

        }

        public IEnumerable<FlightPassengerLink> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Flight_Passenger_Link";

                return ToList(command);
            }
        }

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
