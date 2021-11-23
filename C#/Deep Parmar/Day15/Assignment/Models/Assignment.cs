using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.Models
{
    public class Assignment
    {
        [Key]
        public long AssignmentId { get; set; }

        [ForeignKey("EmployeesId")]
        public Employee Employee { get; set; }
        public int EmployeesId { get; set; }

        public string ActionReasonCode { get; set; }
        public DateTime ActualTerminationDate { get; set; }
        public string AssignmentCategory { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentNumber { get; set; }
        public DateTime AssignmentProjectedEndDate { get; set; }
        public string AssignmentStatus { get; set; }
        public long AssignmentStatusTypeId { get; set; }
        public long BusinessUnitId { get; set; }
        public DateTime CreationDate { get; set; }
        public string DefaultExpenseAccount { get; set; }
        public long DepartmentId { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public string EndTime { get; set; }
        public string Frequency { get; set; }
        public string FullPartTime { get; set; }
        public long GradeId { get; set; }
        public long GradeLadderID { get; set; }
        public long JobId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public long LegalEntityId { get; set; }
        public long LocationId { get; set; }
        public long ManagerAssignmentId { get; set; }
        public long ManagerId { get; set; }

        public bool Status { get; set; }

    }
}
