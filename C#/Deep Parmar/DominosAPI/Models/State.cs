using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Pincodes = new HashSet<Pincode>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Pincode> Pincodes { get; set; }
    }
}
