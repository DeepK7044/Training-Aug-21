using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class OfferDTO
    {
        
        public int OfferId { get; set; }

        [Required]
        public string OfferUrl { get; set; }

        [Required]
        public string OfferTitle { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxDiscount { get; set; }
        public byte? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }

        [Required]
        public string Description { get; set; }
        public string PaymentType { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }

        public bool? IsActive { get; set; }
    }
}
