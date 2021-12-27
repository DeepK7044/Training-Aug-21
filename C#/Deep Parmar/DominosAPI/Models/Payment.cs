using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public int PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OfferId { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual Order Order { get; set; }
        public virtual PaymentType PaymentTypeNavigation { get; set; }
    }
}
