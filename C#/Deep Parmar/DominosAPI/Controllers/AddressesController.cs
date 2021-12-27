using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _Address;
        private readonly IEmployeeRepository _employee;
        private readonly IUserRepository _user;

        public AddressesController(IAddressRepository address,IEmployeeRepository employee,IUserRepository user)
        {
            _Address = address;
            _employee = employee;
            _user = user;
        }

        [HttpGet]
        [Route("~/api/Users/{UserId}/Addresses")]
        public IActionResult GetUserAddress(int UserId)
        {
            var Address = _Address.GetAddressOfUser(UserId);
            if (Address==null)
            {
                return NotFound($"Address Of User Which id is : {UserId} Is Not Available");
            }
            return Ok(Address);
        }

        [HttpGet]
        [Route("~/api/Employees/{EmpId}/Addresses")]
        public IActionResult GetEmployeeAddress(int EmpId)
        {
            var Address = _Address.GetAddressOfEmployee(EmpId);
            if (Address == null)
            {
                return NotFound($"Address Of Employee Which id is : {EmpId} Is Not Available");
            }
            return Ok(Address);
        }

        [HttpGet]
        [Route("~/api/PizzaStores/{StoreId}/Addresses")]
        public IActionResult GetPizzaStoresAddress(int StoreId)
        {
            var Address = _Address.GetAddressOfPizzaStore(StoreId);
            if (Address == null)
            {
                return NotFound($"Address Of PizzaStores Which id is : {StoreId} Is Not Available");
            }
            return Ok(Address);
        }

        [HttpPost]
        [Route("~/api/Users/{UserId}/Addresses")]
        public IActionResult AddUserAddress(int UserId,Address address)
        {
            var User = _user.GetById(UserId);
            if (User==null)
            {
                return NotFound($"User Which id is : {UserId} Is Not Available");
            }
            if (address==null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            var Address = _Address.AddUserAddress(UserId,address);
            if (Address)
            {
                return Ok(new Response { Status = "Success", Message = "UserAddress Created Successfully" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "UserAddress Creation Failed." });            
        }

        [HttpPost]
        [Route("~/api/Employees/{EmpId}/Addresses")]
        public IActionResult AddEmployeeAddress(int EmpId, Address address)
        {
            var Employee = _employee.GetById(EmpId);
            if (Employee == null)
            {
                return NotFound($"Employee Which id is : {EmpId} Is Not Available");
            }
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            var Address = _Address.AddEmployeeAddress(EmpId, address);
            if (Address)
            {
                return Ok(new Response { Status = "Success", Message = "EmployeeAddress Created Successfully" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "EmployeeAddress Creation Failed." });
        }

        [HttpPut("{AddressId}")]
        public IActionResult UpdateAddress(int AddressId, Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            var addressExists = _Address.GetById(AddressId);
            if (addressExists == null)
            {
                return NotFound($"Address Which id is : {AddressId} Is Not Available");
            }
            var result = _Address.UpdateAddress(AddressId,address);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{AddressId}")]
        public IActionResult DeleteCategory(int AddressId)
        {
            var Address = _Address.GetById(AddressId);
            if (Address == null)
            {
                return NotFound($"Address Which id is : {AddressId} Is Not Available");
            }
            var Result = _Address.Delete(Address);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing Address Failed." });
        }
    }
}
