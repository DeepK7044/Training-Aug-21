using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var Employees = _employeeRepository.GetAllEmployees();
            if (Employees ==null)
            {
                return NotFound();
            }
            return Ok(Employees);
        }

        [HttpGet("{EmpId}")]
        public IActionResult GetEmployee(int EmpId)
        {
            var Employee = _employeeRepository.GetEmployee(EmpId);
            if (Employee == null)
            {
                return NotFound($"Employee Which id is : {EmpId} Is Not Available");
            }
            return Ok(Employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _employeeRepository.AddEmployee(employee);
            return Ok();
        }

        [HttpDelete("{EmpId}")]
        public IActionResult RemoveEmployee(int EmpId)
        {
            var employee = _employeeRepository.GetById(EmpId);
            if (employee != null)
            {
                var Result=_employeeRepository.RemoveEmployee(employee);
                if (Result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing Employee Failed." });
            }
            return NotFound($"Employee Which id is : {EmpId} Is Not Available");
        }

        [HttpPut("{EmpID}")]
        public IActionResult UpdateEmployee(int EmpId,EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                throw new ArgumentNullException(nameof(employeeDto));
            }
            var employeeExists = _employeeRepository.GetById(EmpId);
            if (employeeExists != null)
            {
                var Result = _employeeRepository.UpdateEmployee(EmpId,employeeDto);
                if (Result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Employee Updation Failed." });
            }
            return NotFound($"Employee Which id is : {EmpId} Is Not Available");
        }
    }
}
