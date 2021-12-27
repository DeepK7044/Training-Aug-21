using AutoMapper;
using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateRepository _authenticateRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IMailServiceRepository _mailService;

        public AuthenticateController(IAuthenticateRepository authenticateRepository,
                                        IUserRepository userRepository,IMapper mapper,
                                        IConfiguration configuration,
                                        IMailServiceRepository mailService)
        {
            _authenticateRepository = authenticateRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _mailService = mailService;
        }

        [HttpPost("Register/User")]
        public async Task<IActionResult> RegisterUser(UserDTO userDTO)
        {
            var registerModel = _mapper.Map<RegisterModel>(userDTO);
            var result=await _authenticateRepository.RegisterUser(registerModel);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already Exists.." });
            }
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed." });
            }

            _userRepository.AddUser(userDTO);
            return Ok(new Response { Status = "Success", Message = "User Created Successfully" });
        }

        [HttpPost("Register/Admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel registerModel)
        {
            var result = await _authenticateRepository.RegisterAdmin(registerModel);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Admin Already Exists.." });
            }
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Admin Creation Failed." });
            }

            return Ok(new Response { Status = "Success", Message = "Admin Created Successfully" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel,int otp)
        {
            if (otp==1234)
            {
                var result = await _authenticateRepository.Login(loginModel);

                if (string.IsNullOrEmpty(result))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Incorrect Username or Password!" });
                }

                return Ok(result);

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Incorrect OTP!" });
            }
        }

        [HttpGet("SendEmail")]
        public IActionResult SendOTPtoEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return BadRequest();
            }

            MailRequest request = new MailRequest();

            request.ToEmail = Email;
            request.Subject = "Your OTP For Login";
            request.Body = $"<h1>Your OTP is : 1234 </h1>";

            _mailService.SendEmailAsync(request);

            return Ok();
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            var result=await _authenticateRepository.ConfirmEmailAsync(userId, token);

            if (result.Status == "Success")
            {
                return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
            }

            return BadRequest(result);
        }
    }
}
