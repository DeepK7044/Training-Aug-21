using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_13.Models
{
    public class OrderItems
    {

        public int OrderId{ get; set; }

        public Orders Order { get; set; }

        public int ToyId { get; set; }

        public Toys Toy { get; set; }

        public byte Quantity { get; set; }


    }
}
