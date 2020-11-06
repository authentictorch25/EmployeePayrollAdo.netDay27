using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeADO.net
{
    public  class EmployeeRepository
    {
        //Initialising connection to avoid multiple reconnections
        public static SqlConnection connection { get; set; }

        /// <summary>
        /// Connects to the database.
        /// UC1--Creating a Connection
        /// </summary>
        public void Connection()
        {
            //Creating Connection to the database
            DBConnection con = new DBConnection();
            //Calling getConnection method from DBConnection
            connection = con.GetConnection();
            using(connection)
            {
                Console.WriteLine("Connection is established");
            }
            connection.Close();
        }
        /// <summary>
        /// Gets the employee details.
        /// --UC2 Fetching the employee records from the database
        /// </summary>
        public void GetEmployeeDetails()
        {
            //Establishing connection
            DBConnection con = new DBConnection();
            connection = con.GetConnection();
            //Creating model employee to map the details
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (connection)
                {
                    //Query to get the entries of the table
                    string query = @"select * from dbo.employeepayroll";
                    //COnverting to sqlcommand text
                    SqlCommand command = new SqlCommand(query, connection);
                    //Opening the connection to database
                    connection.Open();
                    //Executing the command and reading the files by executing query
                    SqlDataReader reader = command.ExecuteReader();
                    //Checking for null values in the row and if not then get details
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //mapping the details as per entry
                            model.id = reader.GetInt32(0);
                            model.name = reader.GetString(1);
                            model.start = reader.GetDateTime(2);
                            model.gender = reader.GetString(3);
                            model.phone_number = reader.GetString(4);
                            model.address = reader.GetString(5);
                            model.department = reader.GetString(6);
                            model.basic_pay = reader.GetDouble(7);
                            model.deductions = reader.GetInt32(8);
                            model.taxable_pay = reader.GetDouble(9);
                            model.income_tax = reader.GetDouble(10);
                            model.net_pay = reader.GetDouble(11);
                            Console.WriteLine(model.id + " " + model.name + " " + model.start + " " + model.gender + " "
                                + model.phone_number + " " + model.address + " " + model.department + " " + model.basic_pay + " " + model.deductions + " "
                                + model.taxable_pay + " " + model.income_tax + " " + model.net_pay + " ");
                        }                   
                    }
                    else
                    {
                        Console.WriteLine("NO DATA FOUND");
                    }
                    reader.Close();
                }
            }
            //Catching exception in case if any discrepancy
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //closing the connection
            finally
            {
                connection.Close();
            }
        }
    }
}
