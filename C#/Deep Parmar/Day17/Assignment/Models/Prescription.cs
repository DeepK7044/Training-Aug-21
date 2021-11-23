using System;
using System.Collections.Generic;

#nullable disable

namespace Day17.Models
{
    public partial class Prescription
    {
        public int PreId { get; set; }
        public DateTime PreDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DrugsId { get; set; }
        public byte DayPart { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Drug Drugs { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
