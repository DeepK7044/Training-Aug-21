using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DominosDatabaseContext context;

        public GenericRepository(DominosDatabaseContext _context)
        {
            context = _context;
        }
        public virtual void Add(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return context.Set<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public virtual T GetById(int id)
        {
            try
            {
                return context.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public virtual void Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
