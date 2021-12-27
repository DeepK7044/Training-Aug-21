using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class PizzaOrderTopping
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int? ToppingId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
