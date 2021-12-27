using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Offers = new HashSet<Offer>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
