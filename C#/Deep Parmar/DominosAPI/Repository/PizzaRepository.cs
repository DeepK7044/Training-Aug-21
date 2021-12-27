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
    public class PizzaRepository:GenericRepository<Pizza>,IPizzaRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public PizzaRepository(DominosDatabaseContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PizzaDTO> GetAllPizzas()
        {
            try
            {
                var Pizzas = _context.Pizzas.ToList();
                return _mapper.Map<List<PizzaDTO>>(Pizzas);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public PizzaDTO GetPizza(int PizzaId)
        {
            try
            {
                var Pizza = _context.Pizzas.FirstOrDefault(pizza=>pizza.Id==PizzaId);
                return _mapper.Map<PizzaDTO>(Pizza);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PizzaDTO> GetPizzasByCategoryId(int CategoryId)
        {
            try
            {
                var Pizzas = _context.Pizzas.Where(pizzas => pizzas.CategoryId == CategoryId);
                return _mapper.Map<List<PizzaDTO>>(Pizzas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PizzaDTO GetPizzaByCategoryId(int CategoryId,int PizzaId)
        {
            try
            {
                var pizza = _context.Pizzas.SingleOrDefault(pizza => pizza.CategoryId == CategoryId && pizza.Id==PizzaId);
                return _mapper.Map<PizzaDTO>(pizza);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Delete(Pizza entity)
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

        public bool UpdatePizza(int PizzaId,Pizza entity)
        {
            try
            {
                var ExistingPizza=_context.Pizzas.FirstOrDefault(Pizza => Pizza.Id == PizzaId);                
                ExistingPizza.ImageUrl = entity.ImageUrl;
                ExistingPizza.PizzaType = entity.PizzaType;
                ExistingPizza.PizzaTypeId = entity.PizzaTypeId;
                ExistingPizza.PizzaName = entity.PizzaName;
                ExistingPizza.UnitPrice = entity.UnitPrice;
                ExistingPizza.Rating = entity.Rating;
                ExistingPizza.Description = entity.Description;
                ExistingPizza.CategoryId = entity.CategoryId;
                ExistingPizza.IsActive = true;
                ExistingPizza.ModificationTime = DateTime.Now;

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PizzaDTO> GetPizzas(string PizzaName)
        {
            try
            {
                var Pizzas = _context.Pizzas.Where(pizza => pizza.PizzaName.Contains(PizzaName)).ToList();
                return _mapper.Map<List<PizzaDTO>>(Pizzas);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
