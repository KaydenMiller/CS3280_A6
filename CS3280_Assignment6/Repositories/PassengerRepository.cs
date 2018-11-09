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
        public PassengerRepository(AdoNetContext adoNetContext) : base (adoNetContext)
        {

        }

        public IEnumerable<Passenger> Get(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Passenger WHERE Passenger_ID = @Passenger_ID";
                command.Parameters.Add(new OleDbParameter("Passenger_ID", id));

                return ToList(command);
            }
        }

        public IEnumerable<Passenger> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Passenger";

                return ToList(command);
            }
        }

        protected override void Map(IDataRecord record, Passenger entity)
        {
            entity.ID = (int)record["Passenger_ID"];
            entity.FirstName = (string)record["First_Name"];
            entity.LastName = (string)record["Last_Name"];
        }
    }
}
