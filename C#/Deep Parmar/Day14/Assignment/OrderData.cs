using Day14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14
{
    public class OrderData
    {
        public int CustomerId{ get; set; }

        public int AddressID{ get; set; }

        public List<int> ToyId { get; set; }


    }
}
