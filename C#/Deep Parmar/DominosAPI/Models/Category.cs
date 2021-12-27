using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
