using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class PizzaStoreDTO
    {
        public int StoreId { get; set; }

        [Required(ErrorMessage = "StoreName is required")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "TableCapacity is required")]
        public byte TableCapacity { get; set; }

        [Required(ErrorMessage = "ChairCapacity is required")]
        public byte ChairCapacity { get; set; }

        [Required(ErrorMessage = "ContactNumber is required")]
        public string ContactNumber { get; set; }

        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        public int Pincode { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public decimal? Rating { get; set; }
        public bool Status { get; set; }
    }
}
