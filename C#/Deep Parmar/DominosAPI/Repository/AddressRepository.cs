using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class AddressRepository:GenericRepository<Address>,IAddressRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(DominosDatabaseContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AddressDTO> GetAddressOfUser(int UserId)
        {
            try
            {
                var UserAddresses = _context.Addresses.Where(address=>address.UserId==UserId)
                .Select(Address => new AddressDTO()
                {
                    AddressId=Address.AddressId,
                    Address=Address.Address1,
                    Pincode=Address.PincodeId,
                    City=_context.Vpincodes.SingleOrDefault(Pincode=>Pincode.Pincode==Address.PincodeId).CityName,
                    State=_context.Vpincodes.SingleOrDefault(Pincode=>Pincode.Pincode==Address.PincodeId).StateName,
                    Country=_context.Vpincodes.SingleOrDefault(Pincode=>Pincode.Pincode==Address.PincodeId).CountryName,
                    UserId =Address.UserId
                }).ToList();

                return UserAddresses;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<AddressDTO> GetAddressOfEmployee(int EmpId)
        {
            try
            {
                var EmployeeAddresses = _context.Addresses.Where(address => address.EmployeeId == EmpId)
                .Select(Address => new AddressDTO()
                {
                    AddressId = Address.AddressId,
                    Address = Address.Address1,
                    Pincode = Address.PincodeId,
                    City = _context.Vpincodes.SingleOrDefault(Pincode => Pincode.Pincode == Address.PincodeId).CityName,
                    State = _context.Vpincodes.SingleOrDefault(Pincode => Pincode.Pincode == Address.PincodeId).StateName,
                    Country = _context.Vpincodes.SingleOrDefault(Pincode => Pincode.Pincode == Address.PincodeId).CountryName,
                    EmployeeId=Address.EmployeeId
                }).ToList();

                return EmployeeAddresses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AddressDTO> GetAddressOfPizzaStore(int StoreId)
        {
            try
            {
                var PizzaStoreAddresses = _context.Addresses.Where(address => address.StoreId == StoreId)
                .Select(Address => new AddressDTO()
                {
                    AddressId = Address.AddressId,
                    Address = Address.Address1,
                    Pincode = Address.PincodeId,
                    City = _context.Vpincodes.SingleOrDefault(Pincode => Pincode.Pincode == Address.PincodeId).CityName,
                    State = _context.Vpincodes.SingleOrDefault(Pincode => Pincode.Pincode == Address.PincodeId).StateName,
                    Country = _context.Vpincodes.SingleOrDefault(Pincode => Pincode.Pincode == Address.PincodeId).CountryName,
                    StoreId=Address.StoreId
                }).ToList();

                return PizzaStoreAddresses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddUserAddress(int UserId,Address entity)
        {
            try
            {
                entity.UserId = UserId;
                _context.Addresses.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                throw;
            }            
        }

        public bool AddEmployeeAddress(int EmpId, Address entity)
        {
            try
            {
                entity.EmployeeId = EmpId;
                _context.Addresses.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAddress(int AddressId, Address entity)
        {
            try
            {
                var ExistingAddress = _context.Addresses.FirstOrDefault(address => address.AddressId == AddressId);
                ExistingAddress.Address1 = entity.Address1;
                ExistingAddress.PincodeId = entity.PincodeId;
                ExistingAddress.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Delete(Address entity)
        {
            try
            {
                entity.IsActive = false;
                Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
