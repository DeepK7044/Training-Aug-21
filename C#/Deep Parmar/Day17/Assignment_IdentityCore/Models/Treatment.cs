using System;
using System.Collections.Generic;

#nullable disable

namespace Day17Assignment.Models
{
    public partial class Treatment
    {
        public int TrtId { get; set; }
        public DateTime TrtDate { get; set; }
        public int DeptId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
