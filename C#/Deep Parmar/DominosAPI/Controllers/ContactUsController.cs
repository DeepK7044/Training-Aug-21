using DominosAPI.Authentication;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository _ContactUs;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _ContactUs  = contactUsRepository;
        }

        [Authorize(Roles =UserRoles.Admin)]
        [HttpGet]
        public IActionResult GetAllContects()
        {
            var contactUs = _ContactUs.GetContacts();
            if (contactUs == null)
            {
                return NotFound();
            }
            return Ok(contactUs);
        }

        [HttpPost]
        public IActionResult AddContactUs(ContactU contactUs)
        {
            if (contactUs == null)
            {
                throw new ArgumentNullException(nameof(contactUs));
            }
            _ContactUs.Add(contactUs);
            return Ok(new Response { Status = "Success", Message = "ContactUs Created Successfully" });
        }
    }
}
