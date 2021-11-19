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
    [Route("emps/{empID}/child/assignments")]
    [ApiController]
    public class assignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository _assignment;

        public assignmentsController(IAssignmentRepository assignmentRepository)
        {
            _assignment=assignmentRepository;
        }

        [HttpPost]
        public IActionResult CreateAssignments(int empID,Assignment assignment)
        //For Create an Assignment for Perticular EmpID 
        {
            assignment.EmployeesId = empID;
            var Assignments = _assignment.CreateAssignment(empID,assignment);
            return Ok(Assignments);
        }

        [HttpGet]
        public IActionResult GetAssignments(int empID)
        //For Get All Assignment for Perticular EmpID 
        {
            var Assignments = _assignment.GetAssignments(empID);
            if (Assignments == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(Assignments);
        }

        [HttpGet("{AssignmentID}")]
        public IActionResult GetAssignment(int empID, int AssignmentID)
        //For Get an Assignment for Perticular empID
        {
            var Assignment = _assignment.GetAssignment(empID, AssignmentID);
            if (Assignment == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(Assignment);
        }

        [HttpPatch("{AssignmentID}")]
        public IActionResult UpdateAssignment(int empID,int AssignmentID, Assignment assignment)
        //For Get an Assignment for Perticular empID,AssignmentID
        {
            var Assignment = _assignment.UpdateAssignment(empID, AssignmentID, assignment);
            if (Assignment == null)
            {
                return NotFound("Data Not Avaialable");
            }
            return Ok(Assignment);
        }
    }
}
