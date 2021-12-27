using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Country
    {
        public Country()
        {
            Pincodes = new HashSet<Pincode>();
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Pincode> Pincodes { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
