using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class PizzaSize
    {
        public int SizeId { get; set; }
        public string Name { get; set; }
        public byte Serves { get; set; }
        public decimal? Price { get; set; }
    }
}
