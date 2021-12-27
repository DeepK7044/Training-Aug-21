using AutoMapper;
using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class CartItemRepository:GenericRepository<Cart>,ICartItemRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public CartItemRepository(DominosDatabaseContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Vcart> GetCartItems(int UserId)
        {
            try
            {
                var CartItems = _context.Vcarts.Where(item => item.UserId == UserId).ToList();
                return CartItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddCartItems(Cart[] Cartitems, int UserId)
        {
            try
            {
                foreach (var Cartitem in Cartitems)
                {
                    Cartitem.UserId = UserId;
                    _context.Carts.Add(Cartitem);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }

    }
}
