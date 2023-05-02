using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Engine.Interface
{
    public interface ILeaveEngine
    {
        public Task<Leave> AddLeaveEngine(Leave leave,int employeeId);
        public Task<Leave> UpdateLeaveEngine(LeaveUpdateModel leaveUpdate, int leaveId, int employeeId);
        public Task<IEnumerable<Leave>> GetLeaveHistoryEngine(int employeeId);
        public Task <Leave> GetSingleLeaveEngine(int leaveId, int employeeId);

        
        public void DeleteLeaveEngine(Leave leave);
    }
}
