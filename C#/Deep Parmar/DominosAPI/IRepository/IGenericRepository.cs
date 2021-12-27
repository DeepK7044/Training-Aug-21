using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        bool Delete(T entity);

    }
}
