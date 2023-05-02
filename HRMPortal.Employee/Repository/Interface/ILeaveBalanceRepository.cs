using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Repository.Interface
{
    public interface ILeaveBalanceRepository
    {
        Task<LeaveBalance> GetLeaveBalanceById(int employeeId,int leaveBalanceId);
        Task<IEnumerable<LeaveBalance>> ListOfLeaveBalance(int employeeId);
        Task<LeaveBalance> AddLeaveBalance(int employeeId, LeaveBalance leaveBalance);
        Task<LeaveBalance> UpdateLeaveBalance(LeaveBalance leaveBalance);
        Task DeleteLeaveBalance( LeaveBalance leaveBalance);
    }
}
