using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            Payments = new HashSet<Payment>();
            Reviews = new HashSet<Review>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int DeliveryEmpId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Employee DeliveryEmp { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
