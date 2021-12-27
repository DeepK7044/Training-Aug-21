using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Pincode
    {
        public Pincode()
        {
            Addresses = new HashSet<Address>();
        }

        public int Pincode1 { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
