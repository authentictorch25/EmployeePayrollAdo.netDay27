using System;

namespace EmployeeADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository tool = new EmployeeRepository();
            tool.Connection();
            tool.GetEmployeeDetails();
        }
    }
}
