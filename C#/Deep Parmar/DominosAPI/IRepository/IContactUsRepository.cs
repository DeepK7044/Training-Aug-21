using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IContactUsRepository : IGenericRepository<ContactU>
    {
        List<ContactUsDTO> GetContacts();
    }
}
