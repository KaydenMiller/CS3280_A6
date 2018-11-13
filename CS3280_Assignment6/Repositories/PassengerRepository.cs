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
    class PassengerRepository : Repository<Passenger>
    {
        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="adoNetContext"></param>
        public PassengerRepository(AdoNetContext adoNetContext) : base (adoNetContext)
        {

        }

        /// <summary>
        /// Gets a passenger by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Passenger> Get(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Passenger WHERE Passenger_ID = @Passenger_ID";
                command.Parameters.Add(new OleDbParameter("Passenger_ID", id));

                return ToList(command);
            }
        }

        /// <summary>
        /// Gets all passengers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Passenger> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Passenger";

                return ToList(command);
            }
        }

        /// <summary>
        /// Maps the data from a record to an entitiy for use within the application
        /// </summary>
        /// <param name="record"></param>
        /// <param name="entity"></param>
        protected override void Map(IDataRecord record, Passenger entity)
        {
            entity.ID = (int)record["Passenger_ID"];
            entity.FirstName = (string)record["First_Name"];
            entity.LastName = (string)record["Last_Name"];
        }
    }
}
