using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class PizzaStore
    {
        public PizzaStore()
        {
            Reviews = new HashSet<Review>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public byte TableCapacity { get; set; }
        public byte ChairCapacity { get; set; }
        public string ContactNumber { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public decimal? Rating { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
