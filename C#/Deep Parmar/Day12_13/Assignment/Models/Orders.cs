using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_13.Models
{
    public class Orders
    {
        public int OrdersId { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }

        public int DiscountAmount { get; set; }

        public int NetAmount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
