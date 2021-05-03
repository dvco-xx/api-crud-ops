using LMS.EmployeeData;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMS.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // We want to start by injecting the IEmployeeData interface into 
        // our controller by going to Startup.cs and configuring an AddSingleton to the services method

        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok( _employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);

            if (employee != null)
            {
                return Ok(_employeeData.GetEmployee(Id));
            }
            return NotFound($"The employee with Id: {Id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"The employee with Id: {Id} was not found.");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid Id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(Id);

            if (existingEmployee != null )
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}