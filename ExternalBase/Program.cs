using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ExternalBase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connector.Select("*","Disciplines");
            int? Last_name= Connector.ScalarValue("Teachers", "teacher_id", "last_name", "Ковтун") as int?;
             Console.WriteLine(Last_name.HasValue ? $"{Last_name}" : "Нету");
      


        }
    }
}
