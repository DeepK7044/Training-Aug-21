using Day15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(int Id);

        List<Employee> GetEmployees(long[] EmpId);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);
    }
}
