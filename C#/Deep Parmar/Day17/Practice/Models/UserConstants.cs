using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTPractice.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Username="KamleshParmar",
                EmailAddress="abc@gmail.com",
                Password="abc2000",
                GivenName="Kamlesh",
                Surname="Parmar",
                Role="Administrator"
            },
            new UserModel()
            {
                Username="DeepParmar",
                EmailAddress="abc@gmail.com",
                Password="abc2000",
                GivenName="Deep",
                Surname="Parmar",
                Role="Seller"
            }
        };
    }
}
