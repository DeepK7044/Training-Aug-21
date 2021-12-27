using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string Description { get; set; }
        public int PizzaTypeId { get; set; }
        public decimal? Rating { get; set; }
        public string ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal? ToppingCost { get; set; }
        public decimal UnitPrice { get; set; }
        public byte Quantity { get; set; }

    }
}
