using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository.Class
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly HRMPortalEmployeeContext _context;

        public SalaryRepository(HRMPortalEmployeeContext context)
        {
            this._context = context;
            
            Console.WriteLine("It is salary Repository");
        }      

        public async Task<IEnumerable<Salary>> GetSalaryAsync()
        {
            return await _context.Salary.ToListAsync();
        }       
           
        public async Task<Salary> GetSalaryByIdAsysnc(int employeeId, int salaryId)
        {
            return await _context.Salary.FirstOrDefaultAsync(s => s.Id == salaryId && s.EmployeeDetailId == employeeId);
        }

        public async Task<IEnumerable<Salary>> GetSalaryByEmployeeIdAsysnc(int employeeId)
        {
            return await _context.Salary.Where(e => e.EmployeeDetailId == employeeId).ToListAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaryByBankDetailIdAsysnc(int bankDetailId)
        {
            return await _context.Salary.Where(b => b.BankDetailId == bankDetailId).ToListAsync();
        }

        public async Task<Salary> AddSalaryAsync(int employeeId, Salary salary)
        {
           salary.EmployeeDetail = await _context.EmployeeDetail.FirstOrDefaultAsync(e => e.Id == employeeId);
           salary.EmployeeDetail.Id= employeeId;
           await _context.Salary.AddAsync(salary);
           await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<Salary> UpdateSalary(Salary salary)
        {
             _context.Salary.Update(salary);
             await _context.SaveChangesAsync();
            return salary;
        }

        public void DeleteSalaryById(Salary salary)
        {
             _context.Salary.Remove(salary);
             _context.SaveChanges();           
        }
    }
}
