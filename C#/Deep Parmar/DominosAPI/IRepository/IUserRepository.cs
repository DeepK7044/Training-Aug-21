using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void AddUser(UserDTO entity);
        IQueryable<UserDTO> GetAllUsers();
        UserDTO GetUser(int UserId);
        bool RemoveUser(User entity);
        bool UpdateUser(int UserId, UserDTO entity);
    }
}
