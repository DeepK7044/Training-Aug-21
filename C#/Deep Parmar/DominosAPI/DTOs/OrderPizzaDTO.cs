using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class OrderPizzaDTO
    {
        public int PizzaId { get; set; }
        public int Size { get; set; }
        public int PizzaTypeId { get; set; }
        public int CrustId { get; set; }
        public byte Quantity { get; set; }
        public List<int> Toppings { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
