using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Address
    {
        public Address()
        {
            InverseEmployee = new HashSet<Address>();
            InverseStore = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public int PincodeId { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Address Employee { get; set; }
        public virtual Pincode Pincode { get; set; }
        public virtual Address Store { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Address> InverseEmployee { get; set; }
        public virtual ICollection<Address> InverseStore { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
