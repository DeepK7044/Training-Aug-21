using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IPincodeRepository : IGenericRepository<Pincode>
    {
        bool AddPincode(Pincode pincode);
        Vpincode GetPincode(int Pincode);
        List<Vpincode> GetPincodes();
    }
}
