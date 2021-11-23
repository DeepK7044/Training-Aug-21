using Day17.Authentication;
using Day17.Models;
using Day17.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILoginInfoRepository _Login;
        private readonly AddToken _token;

        public AuthenticateController(ILoginInfoRepository loginInfoRepository, AddToken token)
        {
            _Login = loginInfoRepository;
            _token = token;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok("Hii");
        }

        //[AllowAnonymous]
        [HttpPost("User/SignUp")]
        public IActionResult UserSignup([FromBody] RegisterModel registerModel)
        {
            if (registerModel == null)
            {
                throw new ArgumentNullException(nameof(registerModel));
            }

            LoginInfo userData = new LoginInfo()
            {
                Username = registerModel.Username,
                Password = AddSecurity.ConvertToEncrypt(registerModel.Password),
                EmailAddress = registerModel.EmailAddress,
                GivenName = registerModel.Name,
                Surname = registerModel.Surname,
                Role = Role.User
            };

            _Login.SingUp(userData);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentNullException(nameof(loginModel));
            }

            var Person = _Login.SignIn(loginModel);
            if (Person != null)
            {
                string token = _token.GenrateToken(Person);
                return Ok(token);
            }
            return NotFound("User Not Found.");
        }
    }
}
