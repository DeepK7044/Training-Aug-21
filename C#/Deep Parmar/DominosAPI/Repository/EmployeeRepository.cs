using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(DominosDatabaseContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<EmployeeDTO> GetAllEmployees()
        {
            try
            {
                var employees = _context.Employees.Select(employee => new EmployeeDTO()
                {
                    EmployeeId=employee.EmployeeId,
                    Name = employee.Name,
                    PhoneNumber = employee.PhoneNumber,
                    Address = _context.Addresses.SingleOrDefault(Address => Address.EmployeeId == employee.EmployeeId).Address1,
                    Gender = employee.Gender,
                    Pincode=_context.Addresses.FirstOrDefault(address=>address.EmployeeId==employee.EmployeeId).PincodeId,
                    IsActive = employee.IsActive
                });

                return employees;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public EmployeeDTO GetEmployee(int EmpId)
        {
            try
            {
                var employee = _context.Employees.Find(EmpId);                
                var employeeDTO=_mapper.Map<EmployeeDTO>(employee);
                employeeDTO.Address = _context.Addresses.FirstOrDefault(Employee => Employee.EmployeeId == EmpId).Address1;
                employeeDTO.Pincode = _context.Addresses.FirstOrDefault(Employee => Employee.EmployeeId == EmpId).PincodeId;

                return employeeDTO;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public void AddEmployee(EmployeeDTO entity)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($"Sp_AddEntityData @Choice=3,@Name='{entity.Name}',@PhoneNumber='{entity.PhoneNumber}',@Gender={entity.Gender},@Address='{entity.Address}',@Pincode={entity.Pincode}");
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool RemoveEmployee(Employee entity)
        {
            try
            {
                var ExistingEmployee=_context.Employees.FirstOrDefault(Employee => Employee.EmployeeId == entity.EmployeeId);
                if (ExistingEmployee != null)
                {
                    ExistingEmployee.IsActive = false;
                    ExistingEmployee.DeletionTime = DateTime.Now;
                    Update(ExistingEmployee);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateEmployee(int EmpId,EmployeeDTO entity)
        {
            try
            {
                var Employee = _context.Employees.FirstOrDefault(employee => employee.EmployeeId == EmpId);
                var Address = _context.Addresses.FirstOrDefault(Address => Address.EmployeeId == EmpId);

                Employee.Name = entity.Name;
                Employee.PhoneNumber = entity.PhoneNumber;
                Employee.Gender = entity.Gender;
                Employee.IsActive = true;
                Employee.ModificationTime = DateTime.Now;
                _context.Employees.Update(Employee);
                _context.SaveChanges();


                Address.Address1 = entity.Address;
                Address.PincodeId = entity.Pincode;                
                _context.Addresses.Update(Address);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
