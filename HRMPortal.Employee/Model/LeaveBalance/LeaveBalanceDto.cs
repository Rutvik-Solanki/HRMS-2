using HRMPortal.Employee.Enums;

namespace HRMPortal.Employee.Model
{
    public class LeaveBalanceDto
    {
        public int LeaveBalanceId { get; set; }
        public LeaveType LeaveType { get; set; }
        public double TotalLeave { get; set; }
    }
}
    