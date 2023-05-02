using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;

namespace HRMPortal.Employee.Model
{
    public class UpdateLeaveBalanceDto : BaseEntity
    {
        public LeaveType LeaveType { get; set; }
        public double TotalLeave { get; set; }
    }
}
