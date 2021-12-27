using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class AddressDTO
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        public int Pincode { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
