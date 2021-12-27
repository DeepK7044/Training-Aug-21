using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IPizzaRepository : IGenericRepository<Pizza>
    {
        List<PizzaDTO> GetAllPizzas();
        PizzaDTO GetPizza(int PizzaId);
        List<PizzaDTO> GetPizzas(string PizzaName);
        PizzaDTO GetPizzaByCategoryId(int CategoryId, int PizzaId);
        List<PizzaDTO> GetPizzasByCategoryId(int CategoryId);
        bool UpdatePizza(int PizzaId, Pizza entity);
    }
}
