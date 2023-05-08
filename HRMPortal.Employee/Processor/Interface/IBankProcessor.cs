using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Processor
{
    public interface IBankProcessor
    {
        Task<IEnumerable<BankDetailDto>> GetBankDetails(int EmplyoeeId);
        Task<BankDetailDto> GetBankDetailById(int EmplyoeeId, int BankDetailId);
        Task <BankDetailDto>AddBankDetails(int EmplyoeeId,BankDetail bankDetail);
        Task<BankDetailDto> UpdateBankDetails(int EmplyoeeId, int bankDetailId, BankDetailDto bankDetailDto);

        Task DeleteBankDetails(int EmplyoeeId, int BankDetailId);
    }
}
