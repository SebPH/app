// THIS IS WHERE REPETITIVE STEPS OR COMMONLY USED FIELDS ARE SPECIFIED

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TechTalk.SpecFlow;

namespace ComplexStateBDD.Scenarios.TestCaseOne
{
    [Binding, Scope(Feature = "TestCaseOne")]
    public class SharedSteps
    {
        // shared fields
        public Guid guid = Guid.NewGuid();
        public string name;
        public string dob;
        public string email;
        public string deparment;

        public SqlConnection conn;
        public SqlCommand command;
        public string sql;

        // shared methods
        public void DisplayDate()
        {
            Console.WriteLine(DateTime.Today.ToShortDateString());
        }

        public SqlConnection ConnectToDatabase()
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

        public void InitializeDatabase(SqlConnection conn, SqlCommand command, string sql)
        {
            try
            {
                // Create Schema Query
                sql = "CREATE SCHEMA Company";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Created Company Schema");

                // Create Table Query (Clients)
                sql = "CREATE TABLE Users (name VARCHAR(100), dob VARCHAR(100), email VARCHAR(100), department VARCHAR(100)";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Created Users Table");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public void CreateStoreProcedures(SqlConnection conn, SqlCommand command, string sql)
        {
            sql = "DROP PROCEDURE InsertIntoUsers";
            command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            Console.WriteLine("Store Procedure Dropped");

            // Creating Stored Procedures
            sql = "CREATE PROCEDURE InsertIntoUsers @name VARCHAR(100), @dob VARCHAR(100), @email VARCHAR(100), @department VARCHAR(100)\n";
            sql += "AS\n";
            sql += "INSERT INTO Users (name, dob, email, department) VALUES (@name, @dob, @email, @department)";
            command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            Console.WriteLine("Store Procedure Created");
        }
    }
}
