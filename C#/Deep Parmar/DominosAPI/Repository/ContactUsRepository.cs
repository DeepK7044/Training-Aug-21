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
    public class ContactUsRepository:GenericRepository<ContactU>,IContactUsRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public ContactUsRepository(DominosDatabaseContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ContactUsDTO> GetContacts()
        {
            var Contacts=_context.ContactUs.ToList();
            return _mapper.Map<List<ContactUsDTO>>(Contacts);
        }

        
    }
}
