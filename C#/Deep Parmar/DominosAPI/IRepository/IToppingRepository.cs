using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IToppingRepository : IGenericRepository<Topping>
    {
        ToppingDTO GetTopping(int toppingId);
        List<ToppingDTO> GetToppings();
        bool UpdateToppings(int toppingId, Topping entity);
    }
}
