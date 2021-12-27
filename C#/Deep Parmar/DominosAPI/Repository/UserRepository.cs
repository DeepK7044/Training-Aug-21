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
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DominosDatabaseContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<UserDTO> GetAllUsers()
        {
            try
            {
                var Users = _context.Users.Select(user => new UserDTO()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName=user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    EmailAddress=user.EmailAddress,
                    Dob=user.Dob,
                    Gender=user.Gender,
                    Address = _context.Addresses.SingleOrDefault(Address => Address.UserId == user.UserId).Address1,
                    Pincode = _context.Addresses.FirstOrDefault(address => address.UserId == user.UserId).PincodeId,
                    IsActive=user.IsActive
                });

                return Users;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public UserDTO GetUser(int UserId)
        {
            try
            {
                var User = _context.Users.Find(UserId);
                var UserDTO = _mapper.Map<UserDTO>(User);
                UserDTO.Address = _context.Addresses.FirstOrDefault(User => User.UserId == UserId).Address1;
                UserDTO.Pincode = _context.Addresses.FirstOrDefault(User => User.UserId == UserId).PincodeId;

                return UserDTO;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void AddUser(UserDTO entity)
        {
            try
            {                
                _context.Database.ExecuteSqlRaw($"Sp_AddEntityData @Choice=1,@FirstName='{entity.FirstName}',@LastName='{entity.LastName}',@PhoneNumber='{entity.PhoneNumber}',@Gender={entity.Gender},@Address='{entity.Address}',@Pincode={entity.Pincode},@EmailAddress='{entity.EmailAddress}',@Dob='{entity.Dob.ToString("yyyy-MM-dd")}',@IsActive=true");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveUser(User entity)
        {
            try
            {
                var ExistingUser = _context.Users.FirstOrDefault(User => User.UserId == entity.UserId);
                if (ExistingUser != null)
                {
                    ExistingUser.IsActive = false;
                    ExistingUser.DeletionTime = DateTime.Now;
                    Update(ExistingUser);
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

        public bool UpdateUser(int UserId, UserDTO entity)
        {
            try
            {
                var User = _context.Users.FirstOrDefault(User => User.UserId == UserId);
                var Address = _context.Addresses.FirstOrDefault(Address => Address.UserId == UserId);

                User.FirstName = entity.FirstName;
                User.LastName = entity.LastName;
                User.PhoneNumber = entity.PhoneNumber;
                User.Dob = entity.Dob;
                User.EmailAddress = entity.EmailAddress;
                User.Gender = entity.Gender;
                User.IsActive = true;
                User.ModificationTime = DateTime.Now;
                _context.Users.Update(User);
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
