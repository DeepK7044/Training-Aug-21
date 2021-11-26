using System;
using System.Collections.Generic;

#nullable disable

namespace Day17Assignment.Models
{
    public partial class Department
    {
        public Department()
        {
            HealthcareAssistants = new HashSet<HealthcareAssistant>();
            Treatments = new HashSet<Treatment>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<HealthcareAssistant> HealthcareAssistants { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
