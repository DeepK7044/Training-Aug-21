using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Vcart
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int PizzaId { get; set; }
        public int CategoryId { get; set; }
        public string PizzaName { get; set; }
        public string Description { get; set; }
        public string PizzaType { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public byte Quantity { get; set; }
        public decimal? Rating { get; set; }
        public bool? IsActive { get; set; }
    }
}
