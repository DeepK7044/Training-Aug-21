using Day14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Repositories
{
    public interface IToyRepository
    {
        List<Toys> GetToys();

        Toys GetToy(int Id);

        List<Toys> SearchToy(string ToyName);
    }
}
