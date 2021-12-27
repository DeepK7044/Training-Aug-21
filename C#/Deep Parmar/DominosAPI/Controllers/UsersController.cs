using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _User;

        public UsersController(IUserRepository userRepository)
        {
            _User = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var Users = _User.GetAllUsers();
            if (Users == null)
            {
                return NotFound();
            }
            return Ok(Users);
        }

        [HttpGet("{UserId}")]
        public IActionResult GetUser(int UserId)
        {
            var User = _User.GetUser(UserId);
            if (User == null)
            {
                return NotFound($"User Which id is : {UserId} Is Not Available");
            }
            return Ok(User);
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO User)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            _User.AddUser(User);
            return Ok();
        }

        [HttpDelete("{UserId}")]
        public IActionResult RemoveUser(int UserId)
        {
            var User = _User.GetById(UserId);
            if (User != null)
            {
                var Result = _User.RemoveUser(User);
                if (Result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing User Failed." });
            }
            return NotFound($"User Which id is : {UserId} Is Not Available");
        }

        [HttpPut("{UserId}")]
        public IActionResult UpdateUser(int UserId, UserDTO UserDTO)
        {
            if (UserDTO == null)
            {
                throw new ArgumentNullException(nameof(UserDTO));
            }
            var UserExists = _User.GetById(UserId);
            if (UserExists != null)
            {
                var Result = _User.UpdateUser(UserId, UserDTO);
                if (Result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Updation Failed." });
            }
            return NotFound($"User Which id is : {UserId} Is Not Available");
        }
    }
}
