using HRMPortal.Employee.Entity;

namespace HRMPortal.Employee.Engine
{
    public interface IBankEngine
    {
        Task<IEnumerable<BankDetail>> GetBankDetails(int EmplyoeeId);
        Task<BankDetail> GetBankDetailById(int EmplyoeeId, int BankDetailId);
        Task <BankDetail>AddBankDetails(int EmplyoeeId, BankDetail bankDetail);
        Task<BankDetail> UpdateBankDetails(BankDetail bankDetail);

        Task DeleteBankDetails(BankDetail bankDetail);
       
    }
}
