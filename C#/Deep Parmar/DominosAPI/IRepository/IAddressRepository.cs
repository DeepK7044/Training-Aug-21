using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        bool AddEmployeeAddress(int EmpId, Address entity);
        bool AddUserAddress(int UserId, Address entity);
        List<AddressDTO> GetAddressOfEmployee(int EmpId);
        List<AddressDTO> GetAddressOfPizzaStore(int StoreId);
        List<AddressDTO> GetAddressOfUser(int UserId);
        bool UpdateAddress(int AddressId, Address entity);
    }
}
