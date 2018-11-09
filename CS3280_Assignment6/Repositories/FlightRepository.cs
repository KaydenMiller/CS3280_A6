using CS3280_Assignment6.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    public class FlightRepository : Repository<Flight>
    {
        public FlightRepository(AdoNetContext context) : base (context)
        {

        }

        public void Add(Flight flight)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Flights (Flight_ID, Flight_Number, Aircraft_Type) VALUES(@Flight_ID, @Flight_Number, @Aircraft_Type)";
                command.Parameters.AddRange(new OleDbParameter[]
                {
                    new OleDbParameter("Flight_ID", flight.Flight_ID),
                    new OleDbParameter("Flight_Number", flight.Flight_Number),
                    new OleDbParameter("Aircraft_Type", flight.Aircraft_Type)
                });
                command.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Flight WHERE Flight_ID = @Flight_ID";
                command.Parameters.Add(new OleDbParameter("Flight_ID", id));
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Flight> Get(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Flight WHERE Flight_ID = @Flight_ID";
                command.Parameters.Add(new OleDbParameter("Flight_ID", id));

                return ToList(command);
            }
        }

        public IEnumerable<Flight> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Flight";

                return ToList(command);
            }
        }

        protected override void Map(IDataRecord record, Flight entity)
        {
            entity.Flight_ID = (int)record["Flight_ID"];
            entity.Flight_Number = (string)record["Flight_Number"];
            entity.Aircraft_Type = (string)record["Aircraft_Type"];
        }
    }
}
