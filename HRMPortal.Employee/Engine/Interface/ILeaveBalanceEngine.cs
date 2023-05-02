using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Engine.Interface
{
    public interface ILeaveBalanceEngine
    {
        Task<LeaveBalance> GetLeaveBalanceById(int employeeId, int leaveBalanceId);
        Task<IEnumerable<LeaveBalance>> ListOfLeaveBalance(int employeeId);
        Task<LeaveBalance> AddLeaveBalance(int employeeId, LeaveBalance leaveBalance);
        Task<LeaveBalance> UpdateLeaveBalance(LeaveBalance leaveBalance);
        Task DeleteLeaveBalance( LeaveBalance leaveBalance);
    }
}
