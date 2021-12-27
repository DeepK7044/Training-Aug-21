using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class ToppingDTO
    {
        public int ToppingId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
