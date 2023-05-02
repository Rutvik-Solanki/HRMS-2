using AutoMapper;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model.SalaryModel;
using HRMPortal.Employee.Processor.Interface;
using System.Collections.Generic;

namespace HRMPortal.Employee.Processor.Class
{
    public class SalaryProcessor : ISalaryProcessor
    {
        private readonly ISalaryEngine _salaryEngine;
        private readonly IMapper _mapper;

        public SalaryProcessor(ISalaryEngine salaryEngine, IMapper mapper)
        {
            this._salaryEngine = salaryEngine ?? throw new ArgumentNullException(nameof(salaryEngine));
            this._mapper = mapper;
            Console.WriteLine("It is salary Processor");
        }

        public async Task<IEnumerable<Salary>> GetSalaryAsync()
        {
            
           return await _salaryEngine.GetSalaryAsync();
        }

        public async Task<IEnumerable<SalaryDto>> GetSalaryByEmployeeIdAsysnc(int employeeId)
        {
            return _mapper.Map<IEnumerable<SalaryDto>>(await _salaryEngine.GetSalaryByEmployeeIdAsysnc(employeeId));
        }

        public async Task<SalaryDto> GetSalaryByIdAsysnc(int employeeId, int salaryId)
        {
            return _mapper.Map<SalaryDto>(await _salaryEngine.GetSalaryByIdAsysnc(employeeId,salaryId));
        }

        public async Task<IEnumerable<Salary>> GetSalaryByBankDetailIdAsysnc(int bankDetailId)
        {
            return await _salaryEngine.GetSalaryByBankDetailIdAsysnc(bankDetailId);
        }

       
        public async Task<SalaryAddUpdateDto> AddSalaryAsync(int employeeId, SalaryAddUpdateDto salaryAddUpdateDto)
        {
            return _mapper.Map<SalaryAddUpdateDto>(await _salaryEngine.AddSalaryAsync(employeeId, _mapper.Map<Salary>(salaryAddUpdateDto)));
        }


        public async Task<SalaryAddUpdateDto> UpdateSalary(int employeeId, int salaryId, SalaryAddUpdateDto salaryAddUpdateDto)
        {
            var salaryid = await _salaryEngine.GetSalaryByIdAsysnc(employeeId, salaryId);
            if (salaryid != null)
            {

                return _mapper.Map<SalaryAddUpdateDto>(await _salaryEngine.UpdateSalary(_mapper.Map(salaryAddUpdateDto, salaryid)));
            }
            return null;
        }
      
        public async Task<bool> DeleteSalaryById(int employeeId,int salaryId)
        {
            var delete =  await _salaryEngine.GetSalaryByIdAsysnc(employeeId, salaryId);
            if (delete != null)
            {
                _salaryEngine.DeleteSalaryById(_mapper.Map<Salary>(delete));
                return true;
            }
            return false;
        }
    }
}
