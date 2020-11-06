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
                Console.WriteLine("Onnection is established");
            }
            connection.Close();
        }

    }
}
