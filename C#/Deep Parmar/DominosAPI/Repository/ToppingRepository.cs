using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class ToppingRepository: GenericRepository<Topping>, IToppingRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public ToppingRepository(DominosDatabaseContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ToppingDTO> GetToppings()
        {
            try
            {
                var Toppings = _context.Toppings.ToList();
                return _mapper.Map<List<ToppingDTO>>(Toppings);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public override bool Delete(Topping entity)
        {
            try
            {
                entity.IsActive = false;
                entity.DeletionTime = DateTime.Now;
                Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ToppingDTO GetTopping(int toppingId)
        {
            try
            {
                var Topping = _context.Toppings.SingleOrDefault(topping => topping.ToppingId == toppingId);
                return _mapper.Map<ToppingDTO>(Topping);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateToppings(int toppingId, Topping entity)
        {
            try
            {
                var ExistingTopping = _context.Toppings.FirstOrDefault(toppings => toppings.ToppingId == toppingId);
                ExistingTopping.Name = entity.Name;
                ExistingTopping.Price = entity.Price;
                ExistingTopping.ModificationTime = DateTime.Now;
                ExistingTopping.IsActive = true;
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
