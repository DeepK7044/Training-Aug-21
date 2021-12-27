using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Payments = new HashSet<Payment>();
        }

        public int OfferId { get; set; }
        public string OfferUrl { get; set; }
        public string OfferTitle { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxDiscount { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string Description { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
