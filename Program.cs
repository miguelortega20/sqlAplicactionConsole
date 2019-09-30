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
            try
            {
                Console.WriteLine("Connect to SQL Server and demo Create, Read, Update and Delete operations.");

                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";   // update me
                builder.UserID = "sa";              // update me
                builder.Password = "Aabbcc12";      // update me
                builder.InitialCatalog = "master";

                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");

                    // Create a sample database
                    Console.Write("Dropping and creating database 'SampleDB' ... ");
                    String sql = "DROP DATABASE IF EXISTS [SampleDB]; CREATE DATABASE [SampleDB]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }

                    // Create a Table and insert some sample data
                    Console.Write("Creating sample table with data, press any key to continue...");
                    Console.ReadKey(true);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("USE SampleDB; ");
                    sb.Append("CREATE TABLE Employees ( ");
                    sb.Append(" Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                    sb.Append(" Name NVARCHAR(50), ");
                    sb.Append(" Location NVARCHAR(50) ");
                    sb.Append("); ");
                    sb.Append("INSERT INTO Employees (Name, Location) VALUES ");
                    sb.Append("(N'Jared', N'Australia'), ");
                    sb.Append("(N'Nikita', N'India'), ");
                    sb.Append("(N'Tom', N'Germany'); ");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }

                } // fin conecition
            } //fin try
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);
        }
    }
}
