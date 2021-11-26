using System;
using System.Collections.Generic;

#nullable disable

namespace Day17Assignment.Models
{
    public partial class ObjectMaster
    {
        public ObjectMaster()
        {
            Objects = new HashSet<Object>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
