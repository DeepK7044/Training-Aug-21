using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public byte Gender { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
