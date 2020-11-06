using System;

namespace EmployeeADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository tool = new EmployeeRepository();
            tool.Connection();
          //  tool.GetEmployeeDetails();
            bool result = tool.UpdateEmployeeData("Rachel", 50000);
            Console.WriteLine(result?"Updated Successfully":"Update failed");
            tool.GetEmployeeDetails();
        }
    }
}
