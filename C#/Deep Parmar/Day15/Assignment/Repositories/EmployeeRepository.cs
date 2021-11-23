using Day15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDataContext _context;

        public EmployeeRepository(EmployeeDataContext employeeDataContext)
        {
            _context = employeeDataContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            if (employee==null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            var Employee = _context.Employees.SingleOrDefault(emp => emp.EmployeeId == employee.EmployeeId);
            if (employee!=null)
            {
                Employee.Status = false; //For SoftDelete From Database
                var Assignment=_context.Assignments.SingleOrDefault(employee => employee.EmployeesId == Employee.EmployeeId);
                if (Assignment!=null)
                {
                    Assignment.Status = false;
                }
                _context.SaveChanges();
            }            
        }

        public Employee GetEmployee(int Id)
        {           
            return _context.Employees.SingleOrDefault(Employee => Employee.EmployeeId == Id);
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();         
        }

        public List<Employee> GetEmployees(long[] EmployeesId)
        {
            List<Employee> Employee = new List<Employee>();
            foreach (var EmpId in EmployeesId)
            {
                var employee= _context.Employees.SingleOrDefault(Employee => Employee.EmployeeId == EmpId);
                if (employee != null)
                {
                    Employee.Add(employee);
                }
            }
            return Employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var existingEmployee=_context.Employees.SingleOrDefault(emp=>emp.EmployeeId==employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.CitizenshpId = employee.CitizenshpId;
                existingEmployee.FirstName = employee.FirstName;
                _context.SaveChanges();
                return (existingEmployee);
            }

            return employee;
        }
    }
}
