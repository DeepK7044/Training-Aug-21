using System;
using System.Collections.Generic;

#nullable disable

namespace Day17.Models
{
    public partial class Object
    {
        public int ObjId { get; set; }
        public int TypeId { get; set; }
        public string ObjName { get; set; }

        public virtual ObjectMaster Type { get; set; }
    }
}
