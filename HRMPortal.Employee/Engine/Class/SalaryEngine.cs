using FluentValidation;
using HRMPortal.Employee.Engine.Interface;
using HRMPortal.Employee.Entity;
using HRMPortal.Employee.ErrorHandling;
using HRMPortal.Employee.Model;
using HRMPortal.Employee.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMPortal.Employee.Engine.Class
{
    public class SalaryEngine : Exception, ISalaryEngine
    {
      
        private readonly ISalaryRepository _salaryRepository;
       

        public SalaryEngine(ISalaryRepository salaryRepository)
        {
           
            this._salaryRepository = salaryRepository;
            Console.WriteLine("It is salary Engine");
        }
             

        public async Task<IEnumerable<Salary>> GetSalaryAsync()
        {
            return await _salaryRepository.GetSalaryAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaryByEmployeeIdAsysnc(int employeeId)
        {
            var result =  await _salaryRepository.GetSalaryByEmployeeIdAsysnc(employeeId);
            if (result.Count() <= 0)
            {
                throw new Exception($"EmployeeId {employeeId} not found in database");
            }
            return result;
        }

        public async Task<Salary> GetSalaryByIdAsysnc(int employeeId, int salaryId)
        {
            var result = await _salaryRepository.GetSalaryByIdAsysnc(employeeId, salaryId);

            if (result == null)
            {
                throw new Exception($"SalaryId {salaryId} not found in database");
            }
            return result;                         
        }
        public async Task<IEnumerable<Salary>> GetSalaryByBankDetailIdAsysnc(int bankDetailId)
        {
            var result = await _salaryRepository.GetSalaryByBankDetailIdAsysnc(bankDetailId);
            if (result.Count() <= 0)
            {
                throw new Exception($"BankDetailId {bankDetailId} not found in database");
            }
            return result;
        }
        
        public async Task<Salary> AddSalaryAsync(int employeeId, Salary salary)
        {
            if(salary == null)
            {
                throw new Exception("Salary Not Add Successfull");
            }
            if(salary.BankDetailId <=0)
            {
                throw new Exception("BankDetail Id Not Found");
            }
            else
            {
               return  await _salaryRepository.AddSalaryAsync(employeeId, salary);
            }
        }

        public void DeleteSalaryById(Salary salary)
        {
            _salaryRepository.DeleteSalaryById(salary);
        }

        public async Task<Salary> UpdateSalary(Salary salary)
        {
           return await _salaryRepository.UpdateSalary(salary);
        }
    }
}
