using HRMPortal.Employee.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRMPortal.Employee.Models
{
    public class LeaveUpdateModel
    {
        public Guid RequestId { get; set; }
        public LeaveType? LeaveTypes { get; set; }

        public LeaveDuration? LeaveDuration { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string? Reason { get; set; }

        public int UpdatedBy { get; set; }
        public int EmployeeDetailId { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
