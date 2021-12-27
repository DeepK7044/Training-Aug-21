using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Vpincode
    {
        public int Pincode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
