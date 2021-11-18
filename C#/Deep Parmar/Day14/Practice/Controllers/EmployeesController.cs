using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;     
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet("{Id}")]
        public IActionResult GetEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);

            if (employee==null)
            {
                return NotFound($"Employee Which id : {Id}  Not Available");
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);            
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);

            if (employee == null)
            {
                return NotFound($"Employee Which id : {Id}  Not Available");
            }
            _employeeData.DeleteEmployee(employee);
            return Ok();
        }

        [HttpPatch("{Id}")]
        public IActionResult DeleteEmployee(Guid Id,Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(Id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee Which id : {Id}  Not Available");
            }

            employee.Id = existingEmployee.Id;
            return Ok(_employeeData.EditEmployee(employee));
        }
    }
}
