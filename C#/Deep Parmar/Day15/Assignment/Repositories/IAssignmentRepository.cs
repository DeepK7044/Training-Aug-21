using Day15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Repositories
{
    public interface IAssignmentRepository
    {
        Assignment CreateAssignment(int EmployeeId,Assignment assignment);

        List<Assignment> GetAssignments(int EmployeeId);

        Assignment GetAssignment(int EmployeeId,int AssignmentId); 
        
        Assignment UpdateAssignment(int EmployeeId,int AssignmentId,Assignment assignment);

    }
}
