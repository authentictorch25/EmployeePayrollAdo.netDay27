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
            // bool result = tool.UpdateEmployeeData("Rachel", 50000);
            //bool result = tool.UpdateEmployeeDataStoredProcedure("Rachel", 70000);
;           // Console.WriteLine(result?"Updated Successfully":"Update failed");
            // tool.GetEmployeeDetails();
            tool.GetEmployeeDetailsJoiningBetweenDate(Convert.ToDateTime("01 - 03 - 2016"));
        }
    }
}
