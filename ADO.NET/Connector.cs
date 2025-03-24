using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET
{
    static class Connector
    {
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static readonly SqlConnection connection;
        static Connector()
        {
            connection = new SqlConnection(CONNECTION_STRING);
            //Статический конструктор нужен только для инициализации статических полей класа;
        }
        public static void Directors()
        {
            Select("*", "Directors");
        }
        public static void SelectMovis()
        {
            Connector.Select("title,release_date, FORMATMESSAGE(N'%s %s', first_name,last_name)", "Movies,Directors", "director = director_id");
        }
        public static void Select(string colums, string tables, string condition = null)
        {
            const int PADDING = 30;
            //string cmd = "SELECT title,release_date,FORMATMESSAGE(N'%s %s',first_name,last_name) FROM Movies,Directors WHERE director = director_id";
            string cmd = $"SELECT {colums}FROM {tables}";
            if (condition != null) cmd += $" WHERE {condition}";
            cmd += ";";
            //3) Создаем команду которую нужно выполнить на сервере
            SqlCommand command = new SqlCommand(cmd, connection);
            //4) Получаем результаты выполнения команды
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            //5) Обрабатывание результата запроса
            if (reader.HasRows)
            {
                Console.WriteLine("==============================================");
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader.GetName(i).PadRight(PADDING));
                Console.WriteLine();
                Console.WriteLine("===============================================");
                while (reader.Read())
                {
                    // Console.WriteLine($"{reader[0].ToString().PadRight(15)}{reader[1].ToString().PadRight(12)}{reader[2].ToString().PadRight(20)}");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i].ToString().PadRight(PADDING));
                    }
                    Console.WriteLine();
                }
            }
            reader.Close();
            connection.Close();
        }
        public static void InsertDirector(string first_name,string last_name)
        {
            string cmd = $" INSERT Directors(first_name,last_name) VALUES (N' {first_name}', '{last_name}')";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
