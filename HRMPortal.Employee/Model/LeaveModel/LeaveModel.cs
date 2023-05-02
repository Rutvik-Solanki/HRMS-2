using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;
using TestHRMS.Enums;

namespace HRMPortal.Employee.Models
{
    public class LeaveModel : BaseEntity
    {
        public int Id { get; set; }
        public Guid RequestId { get; set; }
        public LeaveType? LeaveTypes { get; set; }
        public LeaveDuration? LeaveDuration { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? TotalDays { get; set; }
        public string? Reason { get; set; }
        public LeaveStatus? LeaveStatus { get; set; }
		public int EmployeeDetailId { get; set; }
	}
}
