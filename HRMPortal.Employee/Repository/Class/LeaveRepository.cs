using AutoMapper;
using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository.Class
{
    public class LeaveRepository : IleaveRepository
    {
		private readonly HRMPortalEmployeeContext _context;
		private readonly IMapper _mapper;

        public LeaveRepository(HRMPortalEmployeeContext context, IMapper mapper)
        {
			this._context = context;
			_mapper = mapper;
        }

        public  async Task<IEnumerable<Leave>> GetLeaveHistory(int employeeId)
        {
            return await _context.Leaves.Where(e=>e.EmployeeDetailId ==employeeId).ToListAsync();            
        }

        public async Task<Leave> AddLeave(Leave leave )
        {
            
            await _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();
            return leave;
            
        }

        public async Task<Leave> UpdateLeave(Leave leaveUpdate)
        {
			_context.Leaves.Update(leaveUpdate);
            await _context.SaveChangesAsync();
            return leaveUpdate;
           
        }

        public  async Task<Leave> GetSingleLeave(int leaveId,int employeeId)
        {
            return await _context.Leaves.Where(l => l.Id == leaveId && l.EmployeeDetailId ==employeeId).SingleOrDefaultAsync();            
        }

        public void DeleteLeave(Leave leave)
        {
			_context.Leaves.Remove(leave);
			_context.SaveChanges();
        }

       
    }
}
