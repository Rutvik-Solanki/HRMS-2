using HRMPortal.Employee.DBContext;
using HRMPortal.Employee.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly HRMPortalEmployeeContext context;

        public BankRepository(HRMPortalEmployeeContext context)
        {
            this.context = context;
        }

        public async Task<BankDetail> AddBankDetails(int EmployeeId, BankDetail bankDetail)
        {
            bankDetail.EmployeeDetail = await context.EmployeeDetail.FirstOrDefaultAsync(e => e.Id == EmployeeId);
            bankDetail.EmployeeDetailId = EmployeeId;
            await context.BankDetail.AddAsync(bankDetail);
            await context.SaveChangesAsync();
            return bankDetail;
        }
        public async Task DeleteBankDetails(BankDetail bankDetail)
        {
             context.BankDetail.Remove(bankDetail);
             await context.SaveChangesAsync();
             
        }

        public  async Task<BankDetail> GetBankDetailById(int EmplyoeeId, int BankDetailId)
        {
            return await context.BankDetail.Where(b => b.EmployeeDetailId == EmplyoeeId).FirstOrDefaultAsync(e => e.Id == BankDetailId);
        }


        public async Task<IEnumerable<BankDetail>> GetBankDetails(int EmplyoeeId)
        {
            return await context.BankDetail.Where(b => b.EmployeeDetailId== EmplyoeeId).ToListAsync();
        }

        public async Task<BankDetail> UpdateBankDetails(BankDetail bankDetail)
        {
            //return await context.BankDetail.Update(bankDetailsId);
           context.BankDetail.Update(bankDetail);
           context.SaveChanges();
            return bankDetail;
        }
    }
}
