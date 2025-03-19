using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ADO.NET
{
    class Connector
    {
        private readonly string _connectionString;

        public Connector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DisplayMoviesWithDirectors()
        {
            string cmd = "SELECT title,release_date,FORMATMESSAGE(N'%s %s',first_name,last_name) FROM Movies,Directors WHERE director = director_id";
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            int PADDING = 30;
            Console.WriteLine("==============================================");
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader.GetName(i).PadRight(PADDING));
            Console.WriteLine();
            Console.WriteLine("===============================================");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i].ToString().PadRight(PADDING));
                }
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
    }
}
