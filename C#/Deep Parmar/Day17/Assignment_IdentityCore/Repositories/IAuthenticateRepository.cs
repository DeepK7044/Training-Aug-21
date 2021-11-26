using Day17Assignment.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17Assignment.Repositories
{
    public interface IAuthenticateRepository
    {
        Task<IdentityResult> RegisterUser(RegisterModel registerModel);

        Task<IdentityResult> RegisterAdmin(RegisterModel registerModel);

        Task<string> Login(LoginModel loginModel);
    }
}
