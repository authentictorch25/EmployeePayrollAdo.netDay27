using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeADO.net
{
    /// <summary>
    /// Class containing model to map the entries of the database
    /// </summary>
    class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public string gender { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public double basic_pay { get; set; }
        public int deductions { get; set; }
        public double taxable_pay { get; set; }
        public double income_tax { get; set; }
        public double net_pay { get; set; }
    }
}
