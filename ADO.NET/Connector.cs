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
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void DisplayMoviesWithDirectors()
        {
            string query = "SELECT title, release_date, FORMATMESSAGE(N'%s %s', first_name, last_name) AS director FROM Movies INNER JOIN Directors ON director = director_id";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int PADDING = 25;
                        Console.WriteLine("==============================================");
                        Console.Write("Название".PadRight(PADDING));
                        Console.Write("Дата выхода".PadRight(PADDING));
                        Console.WriteLine("Режиссёр".PadRight(PADDING));
                        Console.WriteLine("==============================================");

                        while (reader.Read())
                        {
                            Console.Write(reader["title"].ToString().PadRight(PADDING));
                            Console.Write(Convert.ToDateTime(reader["release_date"]).ToString("yyyy-MM-dd").PadRight(PADDING));
                            Console.WriteLine(reader["director"].ToString().PadRight(PADDING));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
                }
            }
        }

        public static void InsertMovie(string title, DateTime releaseDate, string directorFirstName, string directorLastName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    int directorId = GetOrCreateDirector(connection, directorFirstName, directorLastName);

                    string cmd = "INSERT INTO Movies (title, release_date, director) VALUES (@Title, @ReleaseDate, @DirectorId)";

                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                        command.Parameters.AddWithValue("@DirectorId", directorId);

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine($"Фильм '{title}' успешно добавлен!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при добавлении фильма: {ex.Message}");
                }
            }
        }

        private static int GetOrCreateDirector(SqlConnection connection, string firstName, string lastName)
        {
            string cmd = "SELECT director_id FROM Directors WHERE first_name = @FirstName AND last_name = @LastName";
            string insertcmd = "INSERT INTO Directors (first_name, last_name) OUTPUT INSERTED.director_id VALUES (@FirstName, @LastName)";

            using (SqlCommand checkCommand = new SqlCommand(cmd, connection))
            {
                checkCommand.Parameters.AddWithValue("@FirstName", firstName);
                checkCommand.Parameters.AddWithValue("@LastName", lastName);
                object result = checkCommand.ExecuteScalar();
                if (result != null&& int.TryParse(result.ToString(),out int directorid)) return directorid;
            }

            using (SqlCommand command = new SqlCommand(insertcmd, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                return (int)command.ExecuteScalar();
            }
        }
    }
}
