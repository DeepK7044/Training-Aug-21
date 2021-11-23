using Day17.Authentication;
using Day17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day17.Repositories
{
    public class LoginInfoRepository : ILoginInfoRepository
    {
        private readonly HospitalManagementSystemContext context;

        public LoginInfoRepository(HospitalManagementSystemContext hospitalManagementSystemContext)
        {
            context = hospitalManagementSystemContext;
        }
        public LoginInfo SignIn(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentNullException(nameof(loginModel));
            }

            var Password = AddSecurity.ConvertToEncrypt(loginModel.Password);
            var User = context.LoginInfos.SingleOrDefault(user => user.Username == loginModel.Username && user.Password == Password);
            return User;
        }


        public void SingUp(LoginInfo loginInfo)
        {
            if (loginInfo == null)
            {
                throw new ArgumentNullException(nameof(loginInfo));
            }
            context.LoginInfos.Add(loginInfo);
            context.SaveChanges();
        }
    }
}
