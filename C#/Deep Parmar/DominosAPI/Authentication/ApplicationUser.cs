﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(25)]
        public string FirstName{ get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName{ get; set; }
    }
}
