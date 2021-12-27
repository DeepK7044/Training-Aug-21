using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public int PizzaTypeId { get; set; }
        public int CrustId { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual PizzaSize Size { get; set; }
    }
}
