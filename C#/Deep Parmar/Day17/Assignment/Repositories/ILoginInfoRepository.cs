using Day17.Authentication;
using Day17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17.Repositories
{
    public interface ILoginInfoRepository
    {
        void SingUp(LoginInfo loginInfo);

        LoginInfo SignIn(LoginModel loginModel);
    }
}
