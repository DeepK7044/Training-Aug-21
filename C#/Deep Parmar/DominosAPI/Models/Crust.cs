using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Crust
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
