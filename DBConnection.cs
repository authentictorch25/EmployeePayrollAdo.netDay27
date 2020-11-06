using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace EmployeeADO.net
{
    /// <summary>
    /// To make a connection to the database
    /// </summary>
    public class DBConnection
    {
        //Connection string which stores the address of the database
        public string con = @"Data Source=LAPTOP-V5IRNHKS\SQLEXPRESS;Initial Catalog=employee_payroll;User ID=akash;Password=akash2507;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            //Establishing connection using Sqlconnection class
            SqlConnection connection = new SqlConnection(con);
            return connection;
        }
    }
}
