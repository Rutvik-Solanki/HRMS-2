using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Enums;
using HRMPortal.Employee.Model;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Processor.Interface
{
    public interface ILeaveBalancePrecessor
    {
        Task<LeaveBalance> GetLeaveBalanceById(int employeeId,int leaveBalanceId);
        Task<IEnumerable<LeaveBalance>> ListOfLeaveBalance(int employeeId);   
        Task<AddLeaveBalanceDto> AddLeaveBalance(int employeeId, AddLeaveBalanceDto addLeaveBalanceDto);
        Task<UpdateLeaveBalanceDto> UpdateLeaveBalance(int employeeId, int leaveBalanceId, UpdateLeaveBalanceDto updateLeaveBalanceDto);
        Task DeleteLeaveBalance(int employeeId, int leaveBalanceId);
    }
}   
