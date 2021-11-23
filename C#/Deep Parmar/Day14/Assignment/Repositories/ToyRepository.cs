using Day14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Repositories
{
    public class ToyRepository : IToyRepository
    {
        private ToyManufacturingCompanyContext _context;
        public ToyRepository(ToyManufacturingCompanyContext ToyContext)
        {
            _context = ToyContext;
        }

        public Toys GetToy(int Id)
        {
            return _context.Toys.SingleOrDefault(Toy => Toy.ToysId == Id);
        }

        public List<Toys> GetToys()
        {
            return _context.Toys.ToList();
        }

        public List<Toys> SearchToy(string ToyName)
        {
            var Toy = _context.Toys.FromSqlRaw($"sp_ProductList {ToyName}").ToList();
            return Toy;
        }
    }
}
