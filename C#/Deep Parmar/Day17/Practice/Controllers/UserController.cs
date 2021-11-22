using JWTPractice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName},You are an {currentUser.Role}");
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName},You are a {currentUser.Role}");
        }

        [HttpGet("AdministratorAndSellers")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdministratorAndSellersEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName},You are a {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hii,You are on Public Property");
        }

        public UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username=userClaims.FirstOrDefault(o=>o.Type==ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
