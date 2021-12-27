using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface ICartItemRepository : IGenericRepository<Cart>
    {
        void AddCartItems(Cart[] Cartitems, int UserId);
        List<Vcart> GetCartItems(int UserId);
    }
}
