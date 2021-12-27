using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IPizzaStoreRepository : IGenericRepository<PizzaStore>
    {
        void AddPizzaStore(PizzaStoreDTO entity);
        IQueryable<object> GetAllPizzaStore(int Pincode);
        PizzaStoreDTO GetPizzaStore(int StoreId);
        IQueryable<PizzaStoreDTO> GetPizzaStores();
        bool UpdatePizzaStore(int StoreId, PizzaStoreDTO entity);
    }
}
