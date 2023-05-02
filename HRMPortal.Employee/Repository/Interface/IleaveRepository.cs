using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMPortal.Employee.Repository.Interface
{
    public interface IleaveRepository
    {
        public Task<Leave> AddLeave(Leave leave );
        public Task<Leave> UpdateLeave(Leave leave);
        public Task<IEnumerable<Leave>> GetLeaveHistory(int employeeId);
        public Task<Leave> GetSingleLeave(int id,int employeeId);

       
        public void DeleteLeave(Leave leave);
    }
}
