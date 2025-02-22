﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class City
    {
        public City()
        {
            Pincodes = new HashSet<Pincode>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Pincode> Pincodes { get; set; }
    }
}
