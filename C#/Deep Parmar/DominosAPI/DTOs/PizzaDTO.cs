using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string PizzaType { get; set; }
        public int PizzaTypeId { get; set; }
        public string PizzaName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Rating { get; set; }
        public int CategoryId { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
