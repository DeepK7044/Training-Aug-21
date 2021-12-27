using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public byte Quantity { get; set; }

        public virtual User User { get; set; }
    }
}
