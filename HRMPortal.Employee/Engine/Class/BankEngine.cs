using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Repository;
using System.Net.WebSockets;

namespace HRMPortal.Employee.Engine
{
    public class BankEngine : IBankEngine
    {
        private readonly IBankRepository bankRepository;

        public BankEngine(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public async Task <BankDetail> AddBankDetails(int EmplyoeeId, BankDetail bankDetail)
        {
           
            return await bankRepository.AddBankDetails( EmplyoeeId, bankDetail);
            /*if (result == null)
            {
                throw new Exception("Data Not Add");
            }*/

        }
        public async Task DeleteBankDetails(BankDetail bankDetail)
        {
            if(bankDetail == null)
            {
                throw new Exception("Data can not Deleted");
            }
            else
            {
               await bankRepository.DeleteBankDetails(bankDetail);
            }
            
        }

        public async Task<BankDetail> GetBankDetailById(int EmplyoeeId, int BankDetailId)
        {
            var result = await bankRepository.GetBankDetailById(EmplyoeeId,BankDetailId);
            if (result == null)
            {
                throw new Exception($"BankDetail {BankDetailId} Data Not Found");
            }
            else
            {
                return result;
            }
        }

        public async Task<IEnumerable<BankDetail>> GetBankDetails(int EmplyoeeId)
        {
            var result = await bankRepository.GetBankDetails( EmplyoeeId);
            if (result.Count() <=0) 
            {
                throw new Exception("Data Not Found");
            }
            else
            {
                return result;
            }
        }

        public async Task<BankDetail> UpdateBankDetails(BankDetail bankDetailsId)
        {

            return await bankRepository.UpdateBankDetails( bankDetailsId);
        }
    }
}
