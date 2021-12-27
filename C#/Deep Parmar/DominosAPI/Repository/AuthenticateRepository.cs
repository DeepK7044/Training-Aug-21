using DominosAPI.Authentication;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMailServiceRepository _mailService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticateRepository(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IMailServiceRepository mailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mailService = mailService;
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByEmailAsync(registerModel.Email);

            if (userExists != null)
            {
                return null;
            }

            var user = new ApplicationUser()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.Email,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            if (result.Succeeded)
            {
                var confirmEmailToken=await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{_configuration["AppUrl"]}/api/Authenticate/ConfirmEmail?userid={user.Id}&token={validEmailToken}";

                var request = new MailRequest();

                request.ToEmail = registerModel.Email;
                request.Subject = $"Hello {registerModel.FirstName},Please Confirm Your Email!";
                request.Body = $"<h1>You have Successfully Register yourSelf in Dominos!</h1>" +
                                $"<p><a href='{url}'>Click Here</a> To Verify Your Email</p>";

                try
                {
                    _mailService.SendEmailAsync(request);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;

        }
        public async Task<IdentityResult> RegisterAdmin(RegisterModel registerModel)
        {
            var adminExists = await _userManager.FindByEmailAsync(registerModel.Email);

            if (adminExists != null)
            {
                return null;
            }

            var admin = new ApplicationUser()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.Email,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber
            };

            var result = await _userManager.CreateAsync(admin, registerModel.Password);

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(admin, UserRoles.Admin);
            }

            if (result.Succeeded)
            {
                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(admin);
                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{_configuration["AppUrl"]}/api/Authenticate/ConfirmEmail?userid={admin.Id}&token={validEmailToken}";

                var request = new MailRequest();

                request.ToEmail = registerModel.Email;
                request.Subject = $"Hello {registerModel.FirstName},Please Confirm Your Email!";
                request.Body = $"<h1>You have Successfully Register yourSelf in Dominos!</h1>" +
                                $"<p><a href='{url}'>Click Here</a> To Verify Your Email</p>";

                try
                {
                    _mailService.SendEmailAsync(request);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Username);

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,loginModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer:_configuration["Jwt:ValidIssuer"],
                audience:_configuration["Jwt:ValidAudience"],
                expires:DateTime.Now.AddHours(1),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Confirm email
        public async Task<Response> ConfirmEmailAsync(string UserId,string Token)
        {
            var user =await _userManager.FindByIdAsync(UserId);
            if (user==null)
            {
                return new Response()
                {
                    Status="Error",
                    Message="Data Not Found."
                };
            }

            var decodedToken = WebEncoders.Base64UrlDecode(Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result=await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
            {
                return new Response()
                {
                    Status = "Success",
                    Message = "Email Confirmed Successfully"
                };
            }

            return new Response()
            {
                Status="Error",
                Message="Email Not Confirmed"
            };
        }
    }
}
