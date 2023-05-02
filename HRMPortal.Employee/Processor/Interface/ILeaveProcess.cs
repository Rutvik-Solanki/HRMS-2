using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Processor.Interface
{
    public interface ILeaveProcess
    {
       public Task<LeaveModel> AddLeaveProcess(LeaveAddModel leave,int employeeId);
        public Task<LeaveModel> UpdateLeaveProcess(LeaveUpdateModel leave,int leaveId,int employeeId);
        public Task<IEnumerable<LeaveModel>> GetLeaveHistoryProcess(int employeeId);

        public Task<LeaveModel> GetSingleLeaveProcess(int leaveId,int employeeId);

        
        public Task<bool> DeleteLeaveProcess(int leaveId, int employeeId);
    }
}
