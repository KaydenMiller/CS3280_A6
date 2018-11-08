using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Data_Access
{
    public class DataAccess
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private string _connectionString;

        public DataAccess()
        {
            _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Books.mdb";
        }

        public DataSet ExecuteSQLStatement(string SQL, ref int RetVal)
        {
            try
            {
                // Create new dataset
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(_connectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        // Open the connection to the database
                        conn.Open();

                        // Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(SQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        // Fill up the DataSet with data
                        adapter.Fill(ds);
                    }
                }
                
                // Set the number of values returned
                RetVal = ds.Tables[0].Rows.Count;

                // Return the DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string ExecuteScalarSQL(string SQL)
        {
            try
            {
                // Holds return value
                object obj;

                using (OleDbConnection conn = new OleDbConnection(_connectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        // Open the connection to the db
                        conn.Open();

                        // Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(SQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        // Execute the scalar SQL statement
                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                // See if object is null
                if (obj == null)
                {
                    return "";
                }
                else
                {
                    // Return the value
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public int ExecuteNonQuery(string SQL)
        {
            try
            {
                // Number of rows affected
                int NumRowsAffected;

                using (OleDbConnection conn = new OleDbConnection(_connectionString))
                {
                    // Open the connection to the database
                    conn.Open();

                    // Add the information for the selectcommand using the SQL statement and the connection object
                    OleDbCommand cmd = new OleDbCommand(SQL, conn);
                    cmd.CommandTimeout = 0;

                    // Execute the non query SQL statement
                    NumRowsAffected = cmd.ExecuteNonQuery();
                }

                // Return the number of row affected
                return NumRowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
