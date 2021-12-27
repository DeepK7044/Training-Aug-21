using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int? StoreId { get; set; }
        public int? PizzaId { get; set; }
        public int? OrderId { get; set; }
        public decimal? Rating { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual Order Order { get; set; }
        public virtual PizzaStore Store { get; set; }
        public virtual User User { get; set; }
    }
}
