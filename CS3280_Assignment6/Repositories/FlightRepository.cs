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
    /// <summary>
    /// Flight repository
    /// </summary>
    public class FlightRepository : Repository<Flight>
    {
        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="context"></param>
        public FlightRepository(AdoNetContext context) : base (context)
        {

        }

        /// <summary>
        /// Adds a flight
        /// </summary>
        /// <param name="flight"></param>
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

        /// <summary>
        /// removes a flight by id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Flight WHERE Flight_ID = @Flight_ID";
                command.Parameters.Add(new OleDbParameter("Flight_ID", id));
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets a flight by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Flight> Get(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Flight WHERE Flight_ID = @Flight_ID";
                command.Parameters.Add(new OleDbParameter("Flight_ID", id));

                return ToList(command);
            }
        }

        /// <summary>
        /// Gets all flights from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flight> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Flight";

                return ToList(command);
            }
        }

        /// <summary>
        /// Maps the data from a record to an entitiy for use within the application
        /// </summary>
        /// <param name="record"></param>
        /// <param name="entity"></param>
        protected override void Map(IDataRecord record, Flight entity)
        {
            entity.Flight_ID = (int)record["Flight_ID"];
            entity.Flight_Number = (string)record["Flight_Number"];
            entity.Aircraft_Type = (string)record["Aircraft_Type"];
        }
    }
}
