using AutoMapper;
using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository.Class
{
    public class LeaveBalanceRepository : ILeaveBalanceRepository
    {
        private readonly HRMPortalEmployeeContext _context;
        private readonly IMapper _mapper;

        public LeaveBalanceRepository(HRMPortalEmployeeContext context, IMapper mapper)
        {
			_context = context;
            _mapper = mapper;
        }
        public async Task<LeaveBalance> GetLeaveBalanceById(int employeeId, int leaveBalanceId)
        {
            return await _context.LeaveBalance.Where(e=>e.EmployeeDetailId==employeeId).FirstOrDefaultAsync((c => c.Id == leaveBalanceId));
        }
        public async Task<IEnumerable<LeaveBalance>> ListOfLeaveBalance(int employeeId)
        {
            return await _context.LeaveBalance.Where(e=>e.EmployeeDetailId ==employeeId).ToListAsync();
        }
        public async Task<LeaveBalance> AddLeaveBalance(int employeeId, LeaveBalance leaveBalance)
        {
            leaveBalance.EmployeeDetail = await _context.EmployeeDetail.FirstOrDefaultAsync(e => e.Id == employeeId);
            leaveBalance.EmployeeDetailId = employeeId;
            await _context.LeaveBalance.AddAsync(leaveBalance);
            await _context.SaveChangesAsync();
            return leaveBalance;
        }
        public async Task<LeaveBalance> UpdateLeaveBalance(LeaveBalance leaveBalance)
        {
			_context.LeaveBalance.Update(leaveBalance);
            await _context.SaveChangesAsync();
            return leaveBalance;
        }

        public async Task DeleteLeaveBalance(LeaveBalance leaveBalance)
        {
			_context.LeaveBalance.Remove(leaveBalance);
            await _context.SaveChangesAsync();
        }
    }
}
