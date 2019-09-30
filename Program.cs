using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace sqlpractica3
{
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


Console.WriteLine("Reading data from table, press any key to continue...");
  
                  Console.ReadKey(true);

                    sql = "SELECT Id, Name, Location FROM Employees;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
 
                   {

                        
using (SqlDataReader reader = command.ExecuteReader())
                        
{
                           
 while (reader.Read())
                            
{
                                
Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            
}

                        }
                    }

        