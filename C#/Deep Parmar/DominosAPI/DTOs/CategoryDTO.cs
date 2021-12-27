using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
