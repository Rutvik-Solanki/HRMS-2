using AutoMapper;
using HRMPortal.Employee.Engine;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.Models;

namespace HRMPortal.Employee.Processor
{
    public class BankProcessor : IBankProcessor
    {
        private readonly IBankEngine Bankengine;
        private readonly IMapper mapper;

        public BankProcessor(IBankEngine Bankengine,IMapper mapper)
        {
            this.Bankengine = Bankengine;
            this.mapper = mapper;
        }

        public async Task <BankDetailDto> AddBankDetails(int EmplyoeeId, BankDetail bankDetail)
        {
           return mapper.Map<BankDetailDto>(await Bankengine.AddBankDetails(EmplyoeeId, mapper.Map<BankDetail>(bankDetail)));
        }

        public async Task DeleteBankDetails(int EmplyoeeId, int BankDetailId)
        {
            var x = await Bankengine.GetBankDetailById(EmplyoeeId, BankDetailId);
            await Bankengine.DeleteBankDetails(mapper.Map<BankDetail>(x));
        }
        
        public   async Task<BankDetailDto> GetBankDetailById(int EmplyoeeId, int BankDetailId)
        {
            return mapper.Map<BankDetailDto> (await Bankengine.GetBankDetailById(EmplyoeeId, BankDetailId));
        }

        public async Task<IEnumerable<BankDetailDto>> GetBankDetails(int EmplyoeeId)
        {
            return mapper.Map<IEnumerable<BankDetailDto>>(await Bankengine.GetBankDetails(EmplyoeeId)); 
        }

        public async Task <BankDetailDto> UpdateBankDetails(int EmplyoeeId, int bankDetailId,BankDetailDto bankDetailDto)
        {
            var x = await Bankengine.GetBankDetailById(EmplyoeeId, bankDetailId);
            if( x!= null)
            {
                return mapper.Map<BankDetailDto>(await Bankengine.UpdateBankDetails(mapper.Map(bankDetailDto, x)));
            }
            //return Bankengine.UpdateBankDetails(bankDetailsId);
            return null;
        }
    }
}
