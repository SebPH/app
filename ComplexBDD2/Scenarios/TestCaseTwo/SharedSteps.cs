using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TechTalk.SpecFlow;

namespace ComplexStateBDD.Scenarios.TestCaseTwo
{
    [Binding, Scope(Feature = "TestCaseTwo")]
    public class SharedSteps
    { 
        // shared fields
        public Guid guid = Guid.NewGuid();

        public string name;
        public string dob;
        public string email;
        public string deparment;

        public SqlConnection conn = ConnectToDatabase();
        public SqlCommand command = null;
        public string sql = "";

        // shared functions
        public void DisplayDate()
        {
            Console.WriteLine(DateTime.Today.ToShortDateString());
        }

        public static SqlConnection ConnectToDatabase()
        {
            string connectionString = @"Data Source=ARL1WK-01733;Initial Catalog=Testing;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Connected to Database");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Something went wrong with exeption: " + ex.Message.ToString());
            }
            return conn;
        }

        public static void InitializeDatabase(SqlConnection conn, SqlCommand command, string sql)
        {
            try
            {
                // Create Schema Query
                sql = "CREATE SCHEMA Profiles";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Created Profiles Schema");

                // Create Table Query (Clients)
                sql = "CREATE TABLE Clients (client_id INT PRIMARY KEY, name VARCHAR(100), email VARCHAR(100), phone VARCHAR(100), funds INT)";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Created Clients Table");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
