using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        void AddEmployee(EmployeeDTO employee);
        bool RemoveEmployee(Employee entity);
        IQueryable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployee(int EmpId);
        bool UpdateEmployee(int EmpId, EmployeeDTO entity);
    }
}
