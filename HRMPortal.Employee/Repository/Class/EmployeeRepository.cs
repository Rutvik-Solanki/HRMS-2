using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HRMPortal.Employee.Repository.Class
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
		private readonly HRMPortalEmployeeContext _context;

		public EmployeeRepository(HRMPortalEmployeeContext context)
        {
			this._context = context;
		}
        public async Task<IEnumerable<EmployeeDetail>> GetAllEmployees()
        {
			_context.EmployeeDetail.ToList();
            return _context.EmployeeDetail;
        }

        public async Task<EmployeeDetail> GetEmployeeById(int emplyeeId)
        {
           return await _context.EmployeeDetail.FirstOrDefaultAsync(e=>e.Id== emplyeeId);
        }
        public async Task<EmployeeDetail> AddEmployee(EmployeeDetail employeeDetail)
        {
            await _context.EmployeeDetail.AddAsync(employeeDetail);
            await _context.SaveChangesAsync();
            return employeeDetail;
            
        }
        public async Task<EmployeeDetail> UpdateEmployee(EmployeeDetail employeeDetail)
        {
			_context.EmployeeDetail.Update(employeeDetail);
            await _context.SaveChangesAsync();
            return employeeDetail;
        }
        public async Task<bool> DeleteEmployee(EmployeeDetail employeeDetail)
        {
			_context.EmployeeDetail.Remove(employeeDetail);
             await _context.SaveChangesAsync();
             return true;
                
        }
    }
}
