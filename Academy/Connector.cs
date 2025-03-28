//#define OLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Data;

namespace Academy
{
    class Connector 
    {
        readonly string CONNECTION_STRING;// = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
        readonly SqlConnection connection;
        public Connector(string connection_string)
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["PV_319_Import"].ConnectionString;
            connection = new SqlConnection(CONNECTION_STRING);
            AllocConsole();
            Console.WriteLine(CONNECTION_STRING);
        }
        
        public DataTable Select(string columns, string tables, string condition = "")
        {
            // connection.Open();
            DataTable table = null;

            string cmd = $"SELECT {columns} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            cmd += ";";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                table = new DataTable();
                table.Load(reader);
#if OLD
                table = new DataTable();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    table.Columns.Add();
                }
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);
                } 
#endif
            }
            //int rowCount = table.Rows.Count;
            reader.Close();
            connection.Close();
            return table;
        }
        public List<string>Directions()
        {
            List<string> directions = new List<string>();
            string cmd = $"SELECT DISTINCT direction_name FROM Directions";
            SqlCommand command = new SqlCommand(cmd, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    directions.Add(reader["direction_name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error loading directions: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return directions;
        }
        

        ~Connector()
        {
            FreeConsole();
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }

    
}
