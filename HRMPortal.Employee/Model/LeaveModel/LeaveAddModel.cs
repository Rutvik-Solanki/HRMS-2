using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Models
{
    public class LeaveAddModel
    {
        public Guid RequestId { get; set; }
        public LeaveType? LeaveTypes { get; set; }

        public LeaveDuration? LeaveDuration { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string? Reason { get; set; }
		public int EmployeeDetailId { get;set; }
		public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }





    }
}
