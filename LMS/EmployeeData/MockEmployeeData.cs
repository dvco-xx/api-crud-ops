using LMS.Models;
using System;
using System.Collections.Generic;
using LMS.EmployeeData;
using System.Linq;

namespace LMS.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        // we create/hardcode a couple of employees by creating a list of employees
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee One"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(Guid Id)
        {
            return employees.SingleOrDefault(x => x.Id == Id);
        }
    }
}
