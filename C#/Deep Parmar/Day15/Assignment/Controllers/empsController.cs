using AutoMapper;
using Day15.Models;
using Day15.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class empsController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;

        public empsController(IEmployeeRepository employeeRepository)
        {
            _employee = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var Employee=_employee.GetEmployees();
            if (Employee == null)
            {
                return NotFound("Data Not Found");
            }

            return Ok(Employee);
        }

        [HttpGet("{empID}")]
        public IActionResult GetEmployee(int empID)
        {
            var Employee = _employee.GetEmployee(empID);
            if (Employee==null)
            {
                return NotFound($"Employee Which id is : {empID} Is Not Available");
            }
            return Ok(Employee);
        }

        [HttpGet("[Action]")]
        //public IActionResult GetEmployees([FromHeader(Name ="EmployeesId")] long[] EmpId)
        public IActionResult GetEmployees([FromBody] long[] EmpId)
        {
            var Employee = _employee.GetEmployees(EmpId);
            return Ok(Employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            var Employee=_employee.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + Employee.EmployeeId, Employee);
        }

        [HttpDelete("{empID}")]
        public IActionResult DeleteEmployee(int empID)
        {
            var Employee = _employee.GetEmployee(empID);
            if (Employee==null)
            {
                return NotFound($"Employee Which id is : {empID} Is Not Available");                
            }
            _employee.DeleteEmployee(Employee);
            return Ok();
        }

        [HttpPatch("{empID}")]
        public IActionResult UpdateEmployee(int empID,Employee employee)
        {
            var Employee = _employee.GetEmployee(empID);
            employee.EmployeeId = empID;
            if (Employee == null)
            {
                return NotFound($"Employee Which id is : {empID} Is Not Available");
            }
            return Ok(_employee.UpdateEmployee(employee));
        }

    }
}
