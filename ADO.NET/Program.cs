using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
#if INTRO
            //1) Берем строку подключения;
            //const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Console.WriteLine(CONNECTION_STRING);
            //2) Сщздаем подключение к серверу
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            // На данный момент подключение яволяется закрытыи мы его не открывали а только создали
            string cmd = "SELECT title,release_date,FORMATMESSAGE(N'%s %s',first_name,last_name) FROM Movies,Directors WHERE director = director_id";
            //3) Создаем команду которую нужно выполнить на сервере
            SqlCommand command = new SqlCommand(cmd, connection);
            //4) Получаем результаты выполнения команды
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int PADDING = 30;
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
#endif
            // Connector.Select("*","Directors");
            //Connector.Select("title,release_date, FORMATMESSAGE(N'%s %s', first_name,last_name)","Movies,Directors","director = director_id");
            //Connector.InsertDirector("George", "Martin");
           //Connector.Directors();
            //Connector.SelectMovis();
            //Connector.InsertDirector("Brian", "De Palma");
            //Connector.InsertMovies("Terminator 5 - Genesis", "2015-06-22", "1");
             string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
            Console.WriteLine(CONNECTION_STRING);
        }
    }
}
    