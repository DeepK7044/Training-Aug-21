using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class PincodeRepository:GenericRepository<Pincode>,IPincodeRepository
    {
        private readonly DominosDatabaseContext _context;

        public PincodeRepository(DominosDatabaseContext context):base(context)
        {
            _context = context;
        }

        public List<Vpincode> GetPincodes()
        {
            try
            {
                var Pincodes=_context.Vpincodes.ToList();
                return Pincodes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Vpincode GetPincode(int Pincode)
        {
            try
            {
                var pincode = _context.Vpincodes.SingleOrDefault(pincode=>pincode.Pincode==Pincode);
                return pincode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddPincode(Pincode pincode)
        {
            try
            {
                _context.Pincodes.Add(pincode);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
