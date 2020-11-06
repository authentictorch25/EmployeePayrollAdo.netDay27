using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeADO.net
{
    public class EmployeeRepository
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
            using (connection)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //closing the connection
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Updates the employee data.
        /// </summary>
        /// --UC3 Updates salary of the employee
        /// returns bool value to identify
        /// <param name="name">The name.</param>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateEmployeeData(string name, double salary)
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
                    //Sql query to update records of the employess
                    string query = "Update dbo.employeepayroll set basic_pay = @parameter2 where name = @parameter1 ";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    //Aiinf values to the parameter given in the query
                    command.Parameters.AddWithValue("@parameter1", name);
                    command.Parameters.AddWithValue("@parameter2", 50000);
                    //returns the number of rows affected
                    var result = command.ExecuteNonQuery();
                    //returning the values
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateEmployeeDataStoredProcedure(string name, double salary)
        {
            //Establishing connection
            DBConnection con = new DBConnection();
            connection = con.GetConnection();
            
            try
            {
                using(connection)
                {                   
                    /// Pssing the stored procedure instead pf query
                    SqlCommand command = new SqlCommand("spUpdateSalary", connection);
                    // command text to have stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // adding values to the parameter
                    command.Parameters.AddWithValue("@salary", salary);
                    command.Parameters.AddWithValue("@name", name);
                    connection.Open();
                    //storing the bool result in result
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }   
        }
        public void GetEmployeeDetailsJoiningBetweenDate(DateTime date)
        {
            //Establishing connection
            DBConnection con = new DBConnection();
            connection = con.GetConnection();

            try
            {
                /// Using the connection established
                using (connection)
                {
                    /// Query to get the data from the table
                    string query = @"select * from dbo.employeepayroll where start between CAST(@parameter as date) 
                                    and CAST(getdate() as date)";
                    /// Impementing the command on the connection fetched database table
                    SqlCommand command = new SqlCommand(query, connection);
                    /// Binding the parameter to the formal parameters
                    command.Parameters.AddWithValue("@parameter", date);
                    /// Opening the connection to start mapping
                    connection.Open();
                    /// executing the sql data reader to fetch the records
                    SqlDataReader reader = command.ExecuteReader();
                    /// executing for not null
                    if (reader.HasRows)
                    {
                        EmployeeModel model = new EmployeeModel();
                        /// Moving to the next record from the table
                        /// Mapping the data to the employee model class object
                        while (reader.Read())
                        {
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
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
            }
            /// Catching any type of exception generated during the run time
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    
}
