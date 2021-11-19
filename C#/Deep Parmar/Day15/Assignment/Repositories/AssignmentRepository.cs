using Day15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly EmployeeDataContext _context;

        public AssignmentRepository(EmployeeDataContext employeeDataContext)
        {
            _context=employeeDataContext;
        }

        public List<Assignment> GetAssignments(int EmployeeId)
        {
            var assignments=_context.Assignments.Where(assignment => assignment.EmployeesId == EmployeeId).ToList();
            return assignments;
        }

        public Assignment GetAssignment(int EmployeeId, int AssignmentId)
        {
            var assignments=_context.Assignments.SingleOrDefault(assignment => assignment.EmployeesId == EmployeeId && assignment.AssignmentId==AssignmentId);
            return assignments;
        }

        public Assignment CreateAssignment(int EmployeeId, Assignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentNullException(nameof(assignment));
            }
            assignment.EmployeesId = EmployeeId;
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
            return assignment;
        }

        public Assignment UpdateAssignment(int EmployeeId, int AssignmentId, Assignment assignment)
        {
            if (assignment==null)
            {
                throw new ArgumentNullException(nameof(assignment));
            }
            var existingAssignments = _context.Assignments.SingleOrDefault(assignment => assignment.EmployeesId == EmployeeId && assignment.AssignmentId==AssignmentId);
            if(existingAssignments == null)
            {
                return existingAssignments;
            }
            existingAssignments.AssignmentName = assignment.AssignmentName;
            _context.SaveChanges();
            return assignment;
        }
    }
}
