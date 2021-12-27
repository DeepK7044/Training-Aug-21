using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Dob is required")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public byte Gender { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        public int Pincode { get; set; }

        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool? IsActive { get; set; }
    }
}
