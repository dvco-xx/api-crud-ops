using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees(); // returns a list of all employees

        Employee GetEmployee(Guid Id); // to fetch a single employee by Id

        Employee AddEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
